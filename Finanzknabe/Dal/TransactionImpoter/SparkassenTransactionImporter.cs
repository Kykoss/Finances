using FinanzberaterHenno.Contracts;
using Finanzknabe.Dal.Extensions;
using Finanzknabe.Data;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace FinanzberaterHenno.Dal.TransactionImpoter
{

    public class SparkassenTransactionImporter : TransactionImporterBase
    {
        public SparkassenTransactionImporter(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async override Task<List<Transaction>> GetTransactions(IBrowserFile importPath)
        {
            var firstLine = true;
            var transactions = new List<Transaction>();
            foreach (var entry in await this.ReadoutCSV(importPath))
            {
                if (firstLine)
                {
                    firstLine = false;
                    continue;
                }

                // Only use booked transactions
                if (entry[16] != "Umsatz gebucht")
                {
                    continue;
                }

                var originAccount = this.GetBankAccount(entry[0]);
                var date = DateOnly.Parse(entry[1]);
                var amount = double.Parse(entry[14]);
                var debitor = entry[11];
                var purpose = entry[4];
                var paymentType = this.GetPaymentType(entry[3]);
                var recipientName = paymentType != PaymentType.PayPal ? debitor : purpose;
                var recipient = this.GetOrCreateRecipient(transactions, recipientName);
                transactions.Add(new Transaction(originAccount, date, recipient, amount, debitor, purpose, paymentType));
            }

            return transactions;
        }

        private PaymentType GetPaymentType(string bookingText) =>
            bookingText switch
            {
                "KARTENZAHLUNG" => PaymentType.DebitCard,
                "FOLGELASTSCHRIFT" or "ERSTLASTSCHRIFT" or "SEPA-ELV-LASTSCHRIFT" or "EINMAL LASTSCHRIFT" => PaymentType.DirectBooking,
                "DAUERAUFTRAG" => PaymentType.PermanentDebit,
                "LOHN  GEHALT" or "GUTSCHR. UEBERWEISUNG" => PaymentType.IncomingCredit,
                "BARGELDAUSZAHLUNG" => PaymentType.CashPayout,
                "ENTGELTABSCHLUSS" or "ABSCHLUSS" => PaymentType.MonthClosing,
                _ => PaymentType.Unknown,
            };
    }
}
