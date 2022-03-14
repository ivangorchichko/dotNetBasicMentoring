CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Weight] FLOAT NULL, 
    [Height] FLOAT NULL, 
    [Width] FLOAT NULL, 
    [Length] FLOAT NULL
)
