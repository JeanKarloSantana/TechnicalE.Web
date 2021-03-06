USE [master]
GO
/****** Object:  Database [TechnicalEvDb]    Script Date: 6/21/2021 5:28:32 AM ******/
CREATE DATABASE [TechnicalEvDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TechnicalEvDb', FILENAME = N'D:\Program Files\MicrosoftSqlServer\MSSQL15.MSSQLSERVER\MSSQL\DATA\TechnicalEvDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TechnicalEvDb_log', FILENAME = N'D:\Program Files\MicrosoftSqlServer\MSSQL15.MSSQLSERVER\MSSQL\DATA\TechnicalEvDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TechnicalEvDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TechnicalEvDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TechnicalEvDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TechnicalEvDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TechnicalEvDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TechnicalEvDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TechnicalEvDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TechnicalEvDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET RECOVERY FULL 
GO
ALTER DATABASE [TechnicalEvDb] SET  MULTI_USER 
GO
ALTER DATABASE [TechnicalEvDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TechnicalEvDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TechnicalEvDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TechnicalEvDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TechnicalEvDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TechnicalEvDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TechnicalEvDb', N'ON'
GO
ALTER DATABASE [TechnicalEvDb] SET QUERY_STORE = OFF
GO
USE [TechnicalEvDb]
GO
/****** Object:  Schema [Chains]    Script Date: 6/21/2021 5:28:32 AM ******/
CREATE SCHEMA [Chains]
GO
/****** Object:  Table [Chains].[Sizes]    Script Date: 6/21/2021 5:28:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Chains].[Sizes](
	[ChainID] [int] NULL,
	[width] [decimal](10, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/21/2021 5:28:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 6/21/2021 5:28:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ISOCode] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 6/21/2021 5:28:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[IdCountry] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExchangeRates]    Script Date: 6/21/2021 5:28:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExchangeRates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdFromCurrency] [int] NOT NULL,
	[IdToCurrency] [int] NOT NULL,
	[Buy] [decimal](18, 2) NOT NULL,
	[Sell] [decimal](18, 2) NOT NULL,
	[Update] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ExchangeRates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 6/21/2021 5:28:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseTransactions]    Script Date: 6/21/2021 5:28:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseTransactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPerson] [int] NOT NULL,
	[IdTransactionType] [int] NOT NULL,
	[IdExchangeRate] [int] NOT NULL,
	[PurchasedAmount] [decimal](18, 2) NOT NULL,
	[BuyRateLog] [decimal](18, 2) NOT NULL,
	[SellRateLog] [decimal](18, 2) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_PurchaseTransactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/21/2021 5:28:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Currencies_IdCountry]    Script Date: 6/21/2021 5:28:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_Currencies_IdCountry] ON [dbo].[Currencies]
(
	[IdCountry] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExchangeRates_IdFromCurrency]    Script Date: 6/21/2021 5:28:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_ExchangeRates_IdFromCurrency] ON [dbo].[ExchangeRates]
(
	[IdFromCurrency] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExchangeRates_IdToCurrency]    Script Date: 6/21/2021 5:28:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_ExchangeRates_IdToCurrency] ON [dbo].[ExchangeRates]
(
	[IdToCurrency] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseTransactions_IdExchangeRate]    Script Date: 6/21/2021 5:28:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseTransactions_IdExchangeRate] ON [dbo].[PurchaseTransactions]
(
	[IdExchangeRate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PurchaseTransactions_IdPerson]    Script Date: 6/21/2021 5:28:32 AM ******/
CREATE NONCLUSTERED INDEX [IX_PurchaseTransactions_IdPerson] ON [dbo].[PurchaseTransactions]
(
	[IdPerson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[PurchaseTransactions] ADD  DEFAULT ((0.0)) FOR [Amount]
GO
ALTER TABLE [dbo].[Currencies]  WITH CHECK ADD  CONSTRAINT [FK_Currencies_Countries_IdCountry] FOREIGN KEY([IdCountry])
REFERENCES [dbo].[Countries] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Currencies] CHECK CONSTRAINT [FK_Currencies_Countries_IdCountry]
GO
ALTER TABLE [dbo].[ExchangeRates]  WITH CHECK ADD  CONSTRAINT [FK_ExchangeRates_Currencies_IdFromCurrency] FOREIGN KEY([IdFromCurrency])
REFERENCES [dbo].[Currencies] ([Id])
GO
ALTER TABLE [dbo].[ExchangeRates] CHECK CONSTRAINT [FK_ExchangeRates_Currencies_IdFromCurrency]
GO
ALTER TABLE [dbo].[ExchangeRates]  WITH CHECK ADD  CONSTRAINT [FK_ExchangeRates_Currencies_IdToCurrency] FOREIGN KEY([IdToCurrency])
REFERENCES [dbo].[Currencies] ([Id])
GO
ALTER TABLE [dbo].[ExchangeRates] CHECK CONSTRAINT [FK_ExchangeRates_Currencies_IdToCurrency]
GO
ALTER TABLE [dbo].[PurchaseTransactions]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseTransactions_ExchangeRates_IdExchangeRate] FOREIGN KEY([IdExchangeRate])
REFERENCES [dbo].[ExchangeRates] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseTransactions] CHECK CONSTRAINT [FK_PurchaseTransactions_ExchangeRates_IdExchangeRate]
GO
ALTER TABLE [dbo].[PurchaseTransactions]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseTransactions_Person_IdPerson] FOREIGN KEY([IdPerson])
REFERENCES [dbo].[Person] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseTransactions] CHECK CONSTRAINT [FK_PurchaseTransactions_Person_IdPerson]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Person_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Person] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Person_Id]
GO
USE [master]
GO
ALTER DATABASE [TechnicalEvDb] SET  READ_WRITE 
GO
