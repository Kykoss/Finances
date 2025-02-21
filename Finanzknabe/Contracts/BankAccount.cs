using System.ComponentModel.DataAnnotations;

namespace Finanzknabe.Contracts
{
    public class BankAccount
    {
        [Key]
        public string Iban { get; set; }

        public User Owner { get; set; }

        public BankAccount()
        {
        }

        public BankAccount(string iban, User owner)
        {
            this.Iban = iban;
            this.Owner = owner;
        }
    }
}
