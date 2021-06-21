/*
 Navicat Premium Data Transfer

 Source Server         : MyLocalDb
 Source Server Type    : SQL Server
 Source Server Version : 15002080
 Source Host           : LENOVO-PC:1433
 Source Catalog        : TechnicalEvDb
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 15002080
 File Encoding         : 65001

 Date: 21/06/2021 05:34:31
*/


-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type IN ('U'))
	DROP TABLE [dbo].[__EFMigrationsHistory]
GO

CREATE TABLE [dbo].[__EFMigrationsHistory] (
  [MigrationId] nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ProductVersion] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[__EFMigrationsHistory] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of __EFMigrationsHistory
-- ----------------------------
INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210616052803_Create_DB_With_Tbl_Currency_ExchangeRate_Country_User_Person_PurchaseTransaction', N'5.0.7')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210617030250_Remove_Rate_Column', N'5.0.7')
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210617153135_Add_Column_Amount_ToTbl_PurchaseTransaction', N'5.0.7')
GO


-- ----------------------------
-- Table structure for Countries
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Countries]') AND type IN ('U'))
	DROP TABLE [dbo].[Countries]
GO

CREATE TABLE [dbo].[Countries] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [ISOCode] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Name] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[Countries] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Countries
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Countries] ON
GO

INSERT INTO [dbo].[Countries] ([Id], [ISOCode], [Name]) VALUES (N'1', N'US', N'UNITED STATE OF AMERICA')
GO

INSERT INTO [dbo].[Countries] ([Id], [ISOCode], [Name]) VALUES (N'2', N'AR', N'ARGENTINA')
GO

INSERT INTO [dbo].[Countries] ([Id], [ISOCode], [Name]) VALUES (N'3', N'BR', N'BRAZIL')
GO

SET IDENTITY_INSERT [dbo].[Countries] OFF
GO


-- ----------------------------
-- Table structure for Currencies
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Currencies]') AND type IN ('U'))
	DROP TABLE [dbo].[Currencies]
GO

CREATE TABLE [dbo].[Currencies] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Code] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [IdCountry] int  NOT NULL,
  [Name] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[Currencies] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Currencies
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Currencies] ON
GO

INSERT INTO [dbo].[Currencies] ([Id], [Code], [IdCountry], [Name]) VALUES (N'1', N'USD', N'1', N'DOLLAR')
GO

INSERT INTO [dbo].[Currencies] ([Id], [Code], [IdCountry], [Name]) VALUES (N'2', N'ARS', N'2', N'ARGENTINE PESO')
GO

INSERT INTO [dbo].[Currencies] ([Id], [Code], [IdCountry], [Name]) VALUES (N'3', N'BRL', N'3', N'REAL')
GO

SET IDENTITY_INSERT [dbo].[Currencies] OFF
GO


-- ----------------------------
-- Table structure for ExchangeRates
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ExchangeRates]') AND type IN ('U'))
	DROP TABLE [dbo].[ExchangeRates]
GO

CREATE TABLE [dbo].[ExchangeRates] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [IdFromCurrency] int  NOT NULL,
  [IdToCurrency] int  NOT NULL,
  [Buy] decimal(18,2)  NOT NULL,
  [Sell] decimal(18,2)  NOT NULL,
  [Update] datetime2(7)  NOT NULL
)
GO

ALTER TABLE [dbo].[ExchangeRates] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ExchangeRates
-- ----------------------------
SET IDENTITY_INSERT [dbo].[ExchangeRates] ON
GO

INSERT INTO [dbo].[ExchangeRates] ([Id], [IdFromCurrency], [IdToCurrency], [Buy], [Sell], [Update]) VALUES (N'1', N'2', N'1', N'94.25', N'100.25', N'2021-06-16 15:00:00.0000000')
GO

INSERT INTO [dbo].[ExchangeRates] ([Id], [IdFromCurrency], [IdToCurrency], [Buy], [Sell], [Update]) VALUES (N'2', N'2', N'3', N'23.56', N'25.06', N'2021-06-18 15:00:00.0000000')
GO

SET IDENTITY_INSERT [dbo].[ExchangeRates] OFF
GO


-- ----------------------------
-- Table structure for Person
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Person]') AND type IN ('U'))
	DROP TABLE [dbo].[Person]
GO

CREATE TABLE [dbo].[Person] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [FirstName] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [LastName] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[Person] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Person
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Person] ON
GO

INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (N'1', N'JEAN', N'SANTANA')
GO

INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (N'2', N'LAURA', N'CRUZ')
GO

INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (N'3', N'MANUEL', N'REYES')
GO

INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName]) VALUES (N'4', N'JHON', N'SMITH')
GO

SET IDENTITY_INSERT [dbo].[Person] OFF
GO


-- ----------------------------
-- Table structure for PurchaseTransactions
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[PurchaseTransactions]') AND type IN ('U'))
	DROP TABLE [dbo].[PurchaseTransactions]
GO

CREATE TABLE [dbo].[PurchaseTransactions] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [IdPerson] int  NOT NULL,
  [IdTransactionType] int  NOT NULL,
  [IdExchangeRate] int  NOT NULL,
  [PurchasedAmount] decimal(18,2)  NOT NULL,
  [BuyRateLog] decimal(18,2)  NOT NULL,
  [SellRateLog] decimal(18,2)  NOT NULL,
  [Date] datetime2(7)  NOT NULL,
  [Amount] decimal(18,2) DEFAULT 0.0 NOT NULL
)
GO

ALTER TABLE [dbo].[PurchaseTransactions] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of PurchaseTransactions
-- ----------------------------
SET IDENTITY_INSERT [dbo].[PurchaseTransactions] ON
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'3', N'1', N'1', N'1', N'49.88', N'94.25', N'100.25', N'2021-06-17 15:39:42.9950758', N'5000.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'4', N'1', N'1', N'1', N'24.94', N'94.25', N'100.25', N'2021-06-20 00:25:20.9125832', N'2500.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'5', N'1', N'1', N'1', N'34.91', N'94.25', N'100.25', N'2021-06-20 14:36:11.8890879', N'3500.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'6', N'1', N'1', N'1', N'24.94', N'94.25', N'100.25', N'2021-06-20 14:40:09.3636668', N'2500.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'7', N'1', N'1', N'1', N'18.95', N'94.25', N'100.25', N'2021-06-20 14:42:28.2590200', N'1900.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'8', N'1', N'1', N'1', N'14.96', N'94.25', N'100.25', N'2021-06-20 14:44:49.7484194', N'1500.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'9', N'1', N'1', N'1', N'17.96', N'94.25', N'100.25', N'2021-06-20 14:46:00.4339115', N'1800.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'10', N'1', N'1', N'2', N'39.90', N'23.56', N'25.06', N'2021-06-20 15:03:54.5154308', N'1000.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'11', N'1', N'1', N'2', N'31.92', N'23.56', N'25.06', N'2021-06-20 15:29:22.4015095', N'800.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'12', N'1', N'1', N'2', N'3.99', N'23.56', N'25.06', N'2021-06-20 16:13:37.5683286', N'100.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'13', N'1', N'1', N'2', N'11.97', N'23.56', N'25.06', N'2021-06-20 16:21:22.0494143', N'300.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'14', N'1', N'1', N'2', N'19.95', N'23.56', N'25.06', N'2021-06-20 16:22:09.8303316', N'500.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'15', N'1', N'1', N'2', N'11.97', N'23.56', N'25.06', N'2021-06-21 03:24:42.2384127', N'300.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'16', N'1', N'1', N'2', N'5.99', N'23.56', N'25.06', N'2021-06-21 03:46:21.9631255', N'150.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'17', N'1', N'1', N'1', N'5.80', N'94.25', N'100.25', N'2021-06-21 03:53:53.0329961', N'8000.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'18', N'2', N'1', N'1', N'29.93', N'94.25', N'100.25', N'2021-06-21 04:05:40.5480006', N'3000.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'19', N'2', N'1', N'2', N'99.76', N'23.56', N'25.06', N'2021-06-21 04:06:36.5015729', N'2500.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'20', N'2', N'1', N'1', N'24.94', N'94.25', N'100.25', N'2021-06-21 04:36:58.0905505', N'2500.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'21', N'2', N'1', N'2', N'29.93', N'23.56', N'25.06', N'2021-06-21 04:37:41.4986059', N'750.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'22', N'2', N'1', N'2', N'11.97', N'23.56', N'25.06', N'2021-06-21 05:01:11.0256381', N'300.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'23', N'2', N'1', N'1', N'4.99', N'94.25', N'100.25', N'2021-06-21 05:01:24.7707560', N'500.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'24', N'2', N'1', N'1', N'89.78', N'94.25', N'100.25', N'2021-06-21 05:11:19.0972013', N'9000.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'25', N'2', N'1', N'2', N'37.91', N'23.56', N'25.06', N'2021-06-21 05:11:34.7758026', N'950.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'26', N'1', N'1', N'2', N'7.98', N'23.56', N'25.06', N'2021-06-21 08:05:28.6783256', N'200.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'27', N'2', N'1', N'2', N'7.98', N'23.56', N'25.06', N'2021-06-21 08:08:26.5816928', N'200.00')
GO

INSERT INTO [dbo].[PurchaseTransactions] ([Id], [IdPerson], [IdTransactionType], [IdExchangeRate], [PurchasedAmount], [BuyRateLog], [SellRateLog], [Date], [Amount]) VALUES (N'28', N'2', N'1', N'2', N'2.00', N'23.56', N'25.06', N'2021-06-21 08:10:45.5141388', N'50.00')
GO

SET IDENTITY_INSERT [dbo].[PurchaseTransactions] OFF
GO


-- ----------------------------
-- Table structure for User
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type IN ('U'))
	DROP TABLE [dbo].[User]
GO

CREATE TABLE [dbo].[User] (
  [Id] int  NOT NULL,
  [Username] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Password] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[User] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of User
-- ----------------------------
INSERT INTO [dbo].[User] ([Id], [Username], [Password]) VALUES (N'1', N'Jsantana', N'12346')
GO

INSERT INTO [dbo].[User] ([Id], [Username], [Password]) VALUES (N'2', N'LCruz', N'123456')
GO

INSERT INTO [dbo].[User] ([Id], [Username], [Password]) VALUES (N'3', N'MReyes', N'123456')
GO

INSERT INTO [dbo].[User] ([Id], [Username], [Password]) VALUES (N'4', N'JSmith', N'123456')
GO


-- ----------------------------
-- Primary Key structure for table __EFMigrationsHistory
-- ----------------------------
ALTER TABLE [dbo].[__EFMigrationsHistory] ADD CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Countries
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Countries]', RESEED, 3)
GO


-- ----------------------------
-- Primary Key structure for table Countries
-- ----------------------------
ALTER TABLE [dbo].[Countries] ADD CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Currencies
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Currencies]', RESEED, 3)
GO


-- ----------------------------
-- Indexes structure for table Currencies
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_Currencies_IdCountry]
ON [dbo].[Currencies] (
  [IdCountry] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table Currencies
-- ----------------------------
ALTER TABLE [dbo].[Currencies] ADD CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for ExchangeRates
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[ExchangeRates]', RESEED, 2)
GO


-- ----------------------------
-- Indexes structure for table ExchangeRates
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_ExchangeRates_IdFromCurrency]
ON [dbo].[ExchangeRates] (
  [IdFromCurrency] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_ExchangeRates_IdToCurrency]
ON [dbo].[ExchangeRates] (
  [IdToCurrency] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table ExchangeRates
-- ----------------------------
ALTER TABLE [dbo].[ExchangeRates] ADD CONSTRAINT [PK_ExchangeRates] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Person
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Person]', RESEED, 4)
GO


-- ----------------------------
-- Primary Key structure for table Person
-- ----------------------------
ALTER TABLE [dbo].[Person] ADD CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for PurchaseTransactions
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[PurchaseTransactions]', RESEED, 28)
GO


-- ----------------------------
-- Indexes structure for table PurchaseTransactions
-- ----------------------------
CREATE NONCLUSTERED INDEX [IX_PurchaseTransactions_IdExchangeRate]
ON [dbo].[PurchaseTransactions] (
  [IdExchangeRate] ASC
)
GO

CREATE NONCLUSTERED INDEX [IX_PurchaseTransactions_IdPerson]
ON [dbo].[PurchaseTransactions] (
  [IdPerson] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table PurchaseTransactions
-- ----------------------------
ALTER TABLE [dbo].[PurchaseTransactions] ADD CONSTRAINT [PK_PurchaseTransactions] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table User
-- ----------------------------
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table Currencies
-- ----------------------------
ALTER TABLE [dbo].[Currencies] ADD CONSTRAINT [FK_Currencies_Countries_IdCountry] FOREIGN KEY ([IdCountry]) REFERENCES [dbo].[Countries] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table ExchangeRates
-- ----------------------------
ALTER TABLE [dbo].[ExchangeRates] ADD CONSTRAINT [FK_ExchangeRates_Currencies_IdFromCurrency] FOREIGN KEY ([IdFromCurrency]) REFERENCES [dbo].[Currencies] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[ExchangeRates] ADD CONSTRAINT [FK_ExchangeRates_Currencies_IdToCurrency] FOREIGN KEY ([IdToCurrency]) REFERENCES [dbo].[Currencies] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table PurchaseTransactions
-- ----------------------------
ALTER TABLE [dbo].[PurchaseTransactions] ADD CONSTRAINT [FK_PurchaseTransactions_ExchangeRates_IdExchangeRate] FOREIGN KEY ([IdExchangeRate]) REFERENCES [dbo].[ExchangeRates] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[PurchaseTransactions] ADD CONSTRAINT [FK_PurchaseTransactions_Person_IdPerson] FOREIGN KEY ([IdPerson]) REFERENCES [dbo].[Person] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table User
-- ----------------------------
ALTER TABLE [dbo].[User] ADD CONSTRAINT [FK_User_Person_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Person] ([Id]) ON DELETE CASCADE ON UPDATE NO ACTION
GO

