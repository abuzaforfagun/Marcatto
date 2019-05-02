using Marcatto.Model;
using Microsoft.EntityFrameworkCore;

namespace Marcatto.Preseistance
{
    public class MarcattoDbContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<PaymentOption> PaymentOptions { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public MarcattoDbContext(DbContextOptions<MarcattoDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<User>()
        //        .HasIndex(u => u.UserId)
        //        .IsUnique();
        //}
    }
}
