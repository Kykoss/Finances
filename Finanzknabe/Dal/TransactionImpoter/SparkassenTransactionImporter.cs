using FinanzberaterHenno.Contracts;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanzberaterHenno.Dal.TransactionImpoter
{
    public class SparkassenTransactionImporter(IBrowserFile importPath) : TransactionImporterBase(importPath)
    {
        public async override Task<List<Transaction>> GetTransactions()
        {
            var firstLine = true;
            var transactions = new List<Transaction>();
            foreach (var entry in await this.ReadoutCSV())
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

                transactions.Add(new Transaction(DateOnly.Parse(entry[1]), double.Parse(entry[14]), entry[11], entry[4], this.GetPaymentType(entry[3])));
            }

            return transactions;
        }

        private PaymentType GetPaymentType(string bookingText) =>
            bookingText switch
            {
                "KARTENZAHLUNG" => PaymentType.DebitCard,
                "FOLGELASTSCHRIFT" or "ERSTLASTSCHRIFT" or "SEPA-ELV-LASTSCHRIFT" or "EINMAL LASTSCHRIFT" => PaymentType.DirectBooking,
                "DAUERAUFTRAG" => PaymentType.PermanentDebit,
                "LOHN  GEHALT" or "GUTSCHR. UEBERWEISUNG" => PaymentType.IncommingCredit,
                "BARGELDAUSZAHLUNG" => PaymentType.CashPayout,
                "ENTGELTABSCHLUSS" or "ABSCHLUSS" => PaymentType.MonthClosing,
                _ => PaymentType.Unknown,
            };
    }
}
