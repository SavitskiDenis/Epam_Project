USE SIDb
GO

CREATE PROC AddRole
	@Role_Name varchar(50)
AS
	INSERT INTO Roles(Role_Name) VALUES (@Role_Name)