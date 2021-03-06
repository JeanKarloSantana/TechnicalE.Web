// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechnicalE.DAL.SQL;

namespace TechnicalE.DAL.Migrations
{
    [DbContext(typeof(TechnicalEvDbContext))]
    [Migration("20210616052803_Create_DB_With_Tbl_Currency_ExchangeRate_Country_User_Person_PurchaseTransaction")]
    partial class Create_DB_With_Tbl_Currency_ExchangeRate_Country_User_Person_PurchaseTransaction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TechnicalE.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ISOCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TechnicalE.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCountry")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCountry");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("TechnicalE.Entities.ExchangeRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Buy")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IdFromCurrency")
                        .HasColumnType("int");

                    b.Property<int>("IdToCurrency")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Sell")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdFromCurrency");

                    b.HasIndex("IdToCurrency");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("TechnicalE.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("TechnicalE.Entities.PurchaseTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BuyRateLog")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdExchangeRate")
                        .HasColumnType("int");

                    b.Property<int>("IdPerson")
                        .HasColumnType("int");

                    b.Property<int>("IdTransaction")
                        .HasColumnType("int");

                    b.Property<decimal>("PurchasedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RateLog")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SellRateLog")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdExchangeRate");

                    b.HasIndex("IdPerson");

                    b.ToTable("PurchaseTransactions");
                });

            modelBuilder.Entity("TechnicalE.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TechnicalE.Entities.Currency", b =>
                {
                    b.HasOne("TechnicalE.Entities.Country", "Country")
                        .WithMany("Currency")
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("TechnicalE.Entities.ExchangeRate", b =>
                {
                    b.HasOne("TechnicalE.Entities.Currency", "CurrencyFrom")
                        .WithMany("ExchangeRatesFrom")
                        .HasForeignKey("IdFromCurrency")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TechnicalE.Entities.Currency", "CurrencyTo")
                        .WithMany("ExchangeRatesTo")
                        .HasForeignKey("IdToCurrency")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CurrencyFrom");

                    b.Navigation("CurrencyTo");
                });

            modelBuilder.Entity("TechnicalE.Entities.PurchaseTransaction", b =>
                {
                    b.HasOne("TechnicalE.Entities.ExchangeRate", "ExchangeRate")
                        .WithMany("PurchaseTransaction")
                        .HasForeignKey("IdExchangeRate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnicalE.Entities.Person", "Person")
                        .WithMany("PurchaseTransaction")
                        .HasForeignKey("IdPerson")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExchangeRate");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("TechnicalE.Entities.User", b =>
                {
                    b.HasOne("TechnicalE.Entities.Person", "Person")
                        .WithOne("User")
                        .HasForeignKey("TechnicalE.Entities.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("TechnicalE.Entities.Country", b =>
                {
                    b.Navigation("Currency");
                });

            modelBuilder.Entity("TechnicalE.Entities.Currency", b =>
                {
                    b.Navigation("ExchangeRatesFrom");

                    b.Navigation("ExchangeRatesTo");
                });

            modelBuilder.Entity("TechnicalE.Entities.ExchangeRate", b =>
                {
                    b.Navigation("PurchaseTransaction");
                });

            modelBuilder.Entity("TechnicalE.Entities.Person", b =>
                {
                    b.Navigation("PurchaseTransaction");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
