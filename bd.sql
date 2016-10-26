-- Script Date: 26/10/2016 15:45  - ErikEJ.SqlCeScripting version 3.5.2.58
-- Database information:
-- Database: C:\Users\lguimaraes\Documents\workspace\Product.Inventory\bd.db
-- ServerVersion: 3.9.2
-- DatabaseSize: 4 KB
-- Created: 24/10/2016 15:07

-- User Table information:
-- Number of tables: 3
-- Inventory: -1 row(s)
-- Product: -1 row(s)
-- Sales: -1 row(s)

-- Warning - constraint: Inventory Parent Columns and Child Columns don't have type-matching columns.
-- Warning - constraint: Sales Parent Columns and Child Columns don't have type-matching columns.
SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [Sales] (
  [Id] bigint NOT NULL
, [Id_Product] int NOT NULL
, [Quantity] int NOT NULL
, CONSTRAINT [sqlite_master_PK_Sales] PRIMARY KEY ([Id])
, FOREIGN KEY ([Id_Product]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [Product] (
  [Id] bigint NOT NULL
, [Name] nvarchar(100) NOT NULL
, CONSTRAINT [sqlite_master_PK_Product] PRIMARY KEY ([Id])
);
CREATE TABLE [Inventory] (
  [Id] bigint NOT NULL
, [Id_Product] int NOT NULL
, [Quantity] int NOT NULL
, CONSTRAINT [sqlite_master_PK_Inventory] PRIMARY KEY ([Id])
, FOREIGN KEY ([Id_Product]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
COMMIT;

