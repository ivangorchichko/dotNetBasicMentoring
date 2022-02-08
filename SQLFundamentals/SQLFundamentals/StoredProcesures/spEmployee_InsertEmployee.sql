CREATE PROCEDURE [dbo].[spEmployee_InsertEmployee]
	@companyName nvarchar(MAX),
	@street nvarchar(50),
	@employeeName nvarchar(100) = null,
	@firstName nvarchar(50) = null,
	@lastName nvarchar(50) = null,
	@position nvarchar(30) = null,
	@city nvarchar(20) = null,
	@state nvarchar(50) = null,
	@zipCode nvarchar(50) = null
AS
	IF LTRIM(NULLIF(RTRIM(@employeeName), '')) IS NOT NULL
	OR LTRIM(NULLIF(RTRIM(@firstName), '')) IS NOT NULL
		OR LTRIM(NULLIF(RTRIM(@lastName), '')) IS NOT NULL
	BEGIN
		declare @addressId int
		declare @personId int

		INSERT INTO Employee
		(AddressId, PersonId, CompanyName, Position, EmployeeName)
		values (@addressId, @personId, SUBSTRING(@companyName, 1, 20), @position, @employeeName)

		INSERT INTO Address
		(Street, City, State, ZipCode)
		VALUES(@street, @city, @state, @zipCode)
		SET @addressId = @@IDENTITY

		INSERT INTO Person
		(FirstName, LastName)
		VALUES (COALESCE(@firstName,''), COALESCE(@lastName,''))
		SET @personId = @@IDENTITY
	END;
RETURN 0
