USE SIDb
GO

CREATE PROC AddPeople
	@FirstName varchar(50),
	@LastName varchar(50)
AS
	INSERT INTO People([FirstName],[LastName]) VALUES (@FirstName, @LastName)