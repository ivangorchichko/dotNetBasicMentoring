CREATE TABLE [dbo].[Order]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Status] INT NULL, 
    [CreatedDate] DATETIME NULL, 
    [UpdatedDate] DATETIME NULL, 
    [ProductId] INT NULL, 
    CONSTRAINT [FK_Employee_Address] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
