USE [master]
GO
/****** Object:  Database [MohamedRefaat]    Script Date: 7/4/2022 10:52:04 PM ******/
CREATE DATABASE [MohamedRefaat]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MohamedRefaat', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LOCALHOST\MSSQL\DATA\MohamedRefaat.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MohamedRefaat_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.LOCALHOST\MSSQL\DATA\MohamedRefaat_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MohamedRefaat] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MohamedRefaat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MohamedRefaat] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MohamedRefaat] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MohamedRefaat] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MohamedRefaat] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MohamedRefaat] SET ARITHABORT OFF 
GO
ALTER DATABASE [MohamedRefaat] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MohamedRefaat] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MohamedRefaat] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MohamedRefaat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MohamedRefaat] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MohamedRefaat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MohamedRefaat] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MohamedRefaat] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MohamedRefaat] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MohamedRefaat] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MohamedRefaat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MohamedRefaat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MohamedRefaat] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MohamedRefaat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MohamedRefaat] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MohamedRefaat] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MohamedRefaat] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MohamedRefaat] SET RECOVERY FULL 
GO
ALTER DATABASE [MohamedRefaat] SET  MULTI_USER 
GO
ALTER DATABASE [MohamedRefaat] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MohamedRefaat] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MohamedRefaat] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MohamedRefaat] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MohamedRefaat] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MohamedRefaat] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MohamedRefaat', N'ON'
GO
ALTER DATABASE [MohamedRefaat] SET QUERY_STORE = OFF
GO
USE [MohamedRefaat]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/4/2022 10:52:05 PM ******/
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
/****** Object:  Table [dbo].[Customers]    Script Date: 7/4/2022 10:52:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Mobile] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 7/4/2022 10:52:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductOrders]    Script Date: 7/4/2022 10:52:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_ProductOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 7/4/2022 10:52:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Notes] [nvarchar](max) NOT NULL,
	[Quantity] [nvarchar](max) NOT NULL,
	[SupplierName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220629161333_InitialMigration', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220629172053_AddDetailsColumnToProductTable', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220629185930_AddOderTable', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220702114957_RemovePhotoColumnFromProductTable', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220703101433_CreateOrderAndProductRelationShip', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220703101744_RemoveOrderAndProductRelationShip', N'6.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220703224251_AddNewColumns', N'6.0.6')
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [Name], [Address], [Mobile]) VALUES (3, N'Mohamed', N'Cairo', N'0111287878')
INSERT [dbo].[Customers] ([Id], [Name], [Address], [Mobile]) VALUES (4, N'ALi', N'Giza', N'0102928727')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [CustomerId], [OrderDate]) VALUES (2, 3, CAST(N'2022-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [CustomerId], [OrderDate]) VALUES (4, 4, CAST(N'2022-02-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Orders] ([Id], [CustomerId], [OrderDate]) VALUES (5, 4, CAST(N'2022-03-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductOrders] ON 

INSERT [dbo].[ProductOrders] ([Id], [OrderId], [ProductId], [Price], [Quantity]) VALUES (5, 4, 5, CAST(100.00 AS Decimal(18, 2)), 111)
INSERT [dbo].[ProductOrders] ([Id], [OrderId], [ProductId], [Price], [Quantity]) VALUES (8, 2, 5, CAST(10000.00 AS Decimal(18, 2)), 30)
INSERT [dbo].[ProductOrders] ([Id], [OrderId], [ProductId], [Price], [Quantity]) VALUES (10, 5, 20, CAST(2000.00 AS Decimal(18, 2)), 70)
SET IDENTITY_INSERT [dbo].[ProductOrders] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductName], [Description], [Notes], [Quantity], [SupplierName]) VALUES (5, N'Orange', N'New', N'', N'200', N'Mohamed')
INSERT [dbo].[Products] ([Id], [ProductName], [Description], [Notes], [Quantity], [SupplierName]) VALUES (20, N'Apple', N'', N'', N'1000', N'Ali')
INSERT [dbo].[Products] ([Id], [ProductName], [Description], [Notes], [Quantity], [SupplierName]) VALUES (21, N'Watermelon', N'Good', N'', N'500', N'Mahmoud')
INSERT [dbo].[Products] ([Id], [ProductName], [Description], [Notes], [Quantity], [SupplierName]) VALUES (22, N'Brocoli', N'', N'', N'3000', N'Mustafa')
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
/****** Object:  Index [IX_Orders_CustomerId]    Script Date: 7/4/2022 10:52:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_CustomerId] ON [dbo].[Orders]
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductOrders_OrderId]    Script Date: 7/4/2022 10:52:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductOrders_OrderId] ON [dbo].[ProductOrders]
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductOrders_ProductId]    Script Date: 7/4/2022 10:52:05 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductOrders_ProductId] ON [dbo].[ProductOrders]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [OrderDate]
GO
ALTER TABLE [dbo].[ProductOrders] ADD  DEFAULT ((0.0)) FOR [Price]
GO
ALTER TABLE [dbo].[ProductOrders] ADD  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'') FOR [Description]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'') FOR [Notes]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'') FOR [Quantity]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (N'') FOR [SupplierName]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers_CustomerId]
GO
ALTER TABLE [dbo].[ProductOrders]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrders_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductOrders] CHECK CONSTRAINT [FK_ProductOrders_Orders_OrderId]
GO
ALTER TABLE [dbo].[ProductOrders]  WITH CHECK ADD  CONSTRAINT [FK_ProductOrders_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductOrders] CHECK CONSTRAINT [FK_ProductOrders_Products_ProductId]
GO
USE [master]
GO
ALTER DATABASE [MohamedRefaat] SET  READ_WRITE 
GO
