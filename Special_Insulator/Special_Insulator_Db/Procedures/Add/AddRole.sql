USE SIDb
GO

CREATE PROC AddRole
	@RoleName varchar(50)
AS
	INSERT INTO Roles(RoleName) VALUES (@RoleName)