using BankApp.MVC.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.MVC.Infrastructures.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        //public interface IEntityTypeConfiguration<TEntity> where TEntity : class

        //We have implemented the method inside the interface
        //and we will write fluentAPI inside the method
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.AccountNumber).IsRequired();

            builder.Property(x => x.Balance).HasColumnType("decimal(18,4)");
            builder.Property(x => x.Balance).IsRequired();
        }
    }
}
