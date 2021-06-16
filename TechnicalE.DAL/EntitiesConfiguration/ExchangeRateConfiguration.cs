using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalE.Entities;

namespace TechnicalE.DAL.EntitiesConfiguration
{
    public class ExchangeRateConfiguration: IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder.ToTable("ExchangeRates");

            builder.HasKey(x => x.Id);

            builder.HasOne(e => e.CurrencyFrom)
                .WithMany(e => e.ExchangeRatesFrom)
                .HasForeignKey(e => e.IdFromCurrency)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.CurrencyTo)
                .WithMany(e => e.ExchangeRatesTo)
                .HasForeignKey(e => e.IdToCurrency)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
