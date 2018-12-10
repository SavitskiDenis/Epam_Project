USE SIDb
GO

CREATE PROC UpdateRole
	@Id int,
	@Role_Name varchar(50)
	
AS
	UPDATE Roles Set [Role_Name] = @Role_Name
	Where Id = @Id

	