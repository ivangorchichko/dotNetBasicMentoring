CREATE TRIGGER [tr_Employee_InsertRow]
ON [dbo].[Employee]
AFTER INSERT
AS
BEGIN
	INSERT INTO Company (Name, AddressId)
	SELECT CompanyName, AddressId FROM INSERTED
END