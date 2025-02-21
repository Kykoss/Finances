using FinanzberaterHenno.Contracts;
using Microsoft.AspNetCore.Components.Forms;
using System.IO;

namespace FinanzberaterHenno.Dal.TransactionImpoter
{
    abstract public class TransactionImporterBase
    {
        IBrowserFile myImportFile;

        public TransactionImporterBase(IBrowserFile importPath)
        {
            myImportFile = importPath;
        }

        public abstract Task<List<Transaction>> GetTransactions();

        protected async Task<List<string[]>> ReadoutCSV()
        {
            var transactions = new List<string[]>();
            using (var reader = new StreamReader(this.myImportFile.OpenReadStream(long.MaxValue)))
            {
                string line;
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
    }
}
