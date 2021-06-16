using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TechnicalE.DAL.EntitiesConfiguration;
using TechnicalE.Entities;

namespace TechnicalE.DAL.SQL
{
    public class TechnicalEvDbContext : DbContext
    {
        public TechnicalEvDbContext(DbContextOptions<TechnicalEvDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CurrencyConfiguration());
            builder.ApplyConfiguration(new ExchangeRateConfiguration());
            builder.ApplyConfiguration(new PersonConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new PurchaseTransactionConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
        }
        
        public DbSet<Currency> Currency { get; set; }
        public DbSet<ExchangeRate> ExchangeRate { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<PurchaseTransaction> PurchaseTransaction { get; set; }
    }
}
