using FinanzberaterHenno.Contracts;
using Finanzknabe.Contracts;
using Finanzknabe.Data;

namespace Finanzknabe.Dal.Extensions
{
    public static class AppDbContextExtension
    {
        public static BankAccount GetBankAccount(this AppDbContext dbContext, string iban)
        {
            var originAccount = dbContext.BankAccounts.FirstOrDefault(x => x.Iban == iban);
            if (originAccount is null)
            {
                throw new ArgumentException("Unknown orgin bank account. Please make sure to register your bank account beforehand!");
            }

            return originAccount;
        }

        public static Recipient? GetRecipientOrDefault(this AppDbContext dbContext, string name)
            => dbContext.Recipients.FirstOrDefault(x => x.Name == name);
    }
}
