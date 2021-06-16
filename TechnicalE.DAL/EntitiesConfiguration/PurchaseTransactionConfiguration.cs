using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalE.Entities;

namespace TechnicalE.DAL.EntitiesConfiguration
{
    public class PurchaseTransactionConfiguration : IEntityTypeConfiguration<PurchaseTransaction>
    {
        public void Configure(EntityTypeBuilder<PurchaseTransaction> builder)
        {
            builder.ToTable("PurchaseTransactions");

            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Person)
                .WithMany(p => p.PurchaseTransaction)
                .HasForeignKey(p => p.IdPerson);

            builder.HasOne(p => p.ExchangeRate)
                .WithMany(p => p.PurchaseTransaction)
                .HasForeignKey(p => p.IdExchangeRate);
        }
    }
}
