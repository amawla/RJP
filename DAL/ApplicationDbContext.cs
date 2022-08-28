using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CustomersModel> Customers { get; set; }
        public DbSet<AccountsModel> Accounts { get; set; }
        public DbSet<TransactionsModel> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AccountsModel>().Property(c => c.Account_Id).IsRequired();
            builder.Entity<AccountsModel>().Property(c => c.Balance).IsRequired();
            builder.Entity<AccountsModel>().Property(c => c.Customer_Id).IsRequired();
            builder.Entity<AccountsModel>().Property(c => c.Account_No).IsRequired();

            builder.Entity<TransactionsModel>().Property(c => c.Account_Id).IsRequired();
            builder.Entity<TransactionsModel>().Property(c => c.Transaction_Date).IsRequired();
            builder.Entity<TransactionsModel>().Property(c => c.Description).IsRequired();
            builder.Entity<TransactionsModel>().Property(c => c.Transaction_Type).IsRequired().HasMaxLength(500);
            builder.Entity<TransactionsModel>().Property(c => c.Transaction_No).IsRequired();

            builder.Entity<CustomersModel>().Property(c => c.FName).IsRequired().HasMaxLength(500);
            builder.Entity<CustomersModel>().Property(c => c.LName).HasMaxLength(500);
            builder.Entity<CustomersModel>().Property(c => c.Address).IsRequired().HasMaxLength(500);
            builder.Entity<CustomersModel>().Property(c => c.Email).IsRequired().HasMaxLength(500);
            builder.Entity<CustomersModel>().Property(c => c.Phone_Number).IsRequired().HasMaxLength(500);
        }



        public override int SaveChanges()
        {

            return base.SaveChanges();
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {

            return base.SaveChangesAsync(cancellationToken);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
