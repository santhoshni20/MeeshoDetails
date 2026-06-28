-- ============================================================================
-- MeeshoDetails Database Initialization Script
-- Creates tables for managing Meesho sellers, products, orders, and payments.
-- ============================================================================

-- Create Sellers Table
CREATE TABLE [dbo].[Sellers] (
    [SellerId]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (100) NOT NULL,
    [ShopName]    NVARCHAR (150) NOT NULL,
    [Email]       NVARCHAR (100) NULL,
    [Phone]       NVARCHAR (15)  NULL,
    [Address]     NVARCHAR (250) NULL,
    [Gstin]       NVARCHAR (15)  NULL,
    [CreatedAt]   DATETIME       DEFAULT (GETDATE()) NOT NULL,
    CONSTRAINT [PK_Sellers] PRIMARY KEY CLUSTERED ([SellerId] ASC)
);

-- Create Products Table
CREATE TABLE [dbo].[Products] (
    [ProductId]   INT            IDENTITY (1, 1) NOT NULL,
    [SellerId]    INT            NOT NULL,
    [Title]       NVARCHAR (200) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Sku]         NVARCHAR (50)  NOT NULL,
    [Price]       DECIMAL (18, 2) NOT NULL,
    [Category]    NVARCHAR (100) NULL,
    [StockCount]  INT            DEFAULT (0) NOT NULL,
    [CreatedAt]   DATETIME       DEFAULT (GETDATE()) NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Products_Sellers] FOREIGN KEY ([SellerId]) REFERENCES [dbo].[Sellers] ([SellerId]) ON DELETE CASCADE
);

-- Create Orders Table
CREATE TABLE [dbo].[Orders] (
    [OrderId]          INT            IDENTITY (1, 1) NOT NULL,
    [ProductId]        INT            NOT NULL,
    [Quantity]         INT            DEFAULT (1) NOT NULL,
    [TotalPrice]       DECIMAL (18, 2) NOT NULL,
    [CustomerName]     NVARCHAR (100) NOT NULL,
    [CustomerPhone]    NVARCHAR (15)  NULL,
    [ShippingAddress]  NVARCHAR (300) NOT NULL,
    [OrderStatus]      NVARCHAR (50)  DEFAULT ('Pending') NOT NULL,
    [OrderDate]        DATETIME       DEFAULT (GETDATE()) NOT NULL,
    [EstimatedDelivery] DATETIME      NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderId] ASC),
    CONSTRAINT [FK_Orders_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId])
);

-- Create Payments Table
CREATE TABLE [dbo].[Payments] (
    [PaymentId]     INT            IDENTITY (1, 1) NOT NULL,
    [OrderId]       INT            NOT NULL,
    [Amount]        DECIMAL (18, 2) NOT NULL,
    [PaymentStatus] NVARCHAR (50)  DEFAULT ('Pending') NOT NULL,
    [PaymentMethod] NVARCHAR (50)  NULL,
    [TransactionId] NVARCHAR (100) NULL,
    [PaymentDate]   DATETIME       DEFAULT (GETDATE()) NOT NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED ([PaymentId] ASC),
    CONSTRAINT [FK_Payments_Orders] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([OrderId]) ON DELETE CASCADE
);

-- Create Indexes for performance
CREATE INDEX [IX_Products_SellerId] ON [dbo].[Products] ([SellerId]);
CREATE INDEX [IX_Orders_ProductId] ON [dbo].[Orders] ([ProductId]);
CREATE INDEX [IX_Payments_OrderId] ON [dbo].[Payments] ([OrderId]);
