using FinanzberaterHenno.Contracts;
using Finanzknabe.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Finanzknabe.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding
            var robin = new User { Id = 1, FirstName = "Robin", LastName = "Olde Meule" };
            modelBuilder.Entity<User>().HasData
            (
                robin,
                new User { Id = 2, FirstName = "Kara", LastName = "Schmich" }
            );
        }

    }
}
