USE master;
GO

CREATE DATABASE OrderDb
ON
( 
    NAME = OrderDb_dat,
    FILENAME = 'replace with location',
    SIZE = 10,
    MAXSIZE = 50,
    FILEGROWTH = 5 
)
LOG ON
( 
    NAME = OrderDb_log,
    FILENAME = 'replace with location',
    SIZE = 5MB,
    MAXSIZE = 25MB,
    FILEGROWTH = 5MB 
);
GO

USE [OrderDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Places](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Place] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Orders](
	[Id] [int] NOT NULL,
	[PlaceId] [int] NULL,
	[Name] [varchar](50) NOT NULL,
	[Discount] [decimal](18, 0) NOT NULL,
	[TotalPriceWithoutDiscount] [decimal](18, 0) NOT NULL,
	[TotalPrice] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OrderItems](
	[Id] [int] NOT NULL,
	[OrderId] [int] NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
