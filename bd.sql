-- Script Date: 24/10/2016 15:06  - ErikEJ.SqlCeScripting version 3.5.2.58
SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [Product] (
  [Id] int NOT NULL
, [Name] nchar(10) NULL
, CONSTRAINT [PK__Product__3214EC07DB26BCA8] PRIMARY KEY ([Id])
);
CREATE TABLE [Inventory] (
  [Id] int NOT NULL
, [Id_product] int NULL
, [Quantity] int NULL
, CONSTRAINT [PK__Inventor__3214EC071B7B8587] PRIMARY KEY ([Id])
, FOREIGN KEY ([Id_product]) REFERENCES [Product] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
COMMIT;

