using FinanzberaterHenno.Contracts;
using Finanzknabe.Contracts;
using Finanzknabe.Dal.Extensions;
using Finanzknabe.Data;
using Microsoft.AspNetCore.Components.Forms;
using System.IO;

namespace FinanzberaterHenno.Dal.TransactionImpoter
{
    abstract public class TransactionImporterBase
    {
        private AppDbContext DbContext { get; }

        public TransactionImporterBase(AppDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public abstract Task<List<Transaction>> GetTransactions(IBrowserFile importPath);

        protected async Task<List<string[]>> ReadoutCSV(IBrowserFile importPath)
        {
            var transactions = new List<string[]>();
            using (var reader = new StreamReader(importPath.OpenReadStream(long.MaxValue)))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var elements = line.Split(';');

                    var trimmedElements = new string[elements.Length];
                    for (var i = 0; i < trimmedElements.Length; i++)
                    {
                        trimmedElements[i] = elements[i].Trim().Trim('"');
                    }

                    transactions.Add(trimmedElements);
                }

                return transactions;
            }
        }

        protected BankAccount GetBankAccount(string iban) => this.DbContext.GetBankAccount(iban);

        protected Recipient GetOrCreateRecipient(ICollection<Transaction> quedTransactions, string name)
        {
            var existingRecipient = quedTransactions.FirstOrDefault(x => x.Recipient.Name == name)?.Recipient;
            existingRecipient ??= this.DbContext.GetRecipientOrDefault(name);

            return existingRecipient is not null ? existingRecipient : new Recipient(name);
        }
    }
}
