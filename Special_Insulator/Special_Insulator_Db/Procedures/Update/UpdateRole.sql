USE SIDb
GO

CREATE PROC UpdateRole
	@Id int,
	@RoleName varchar(50)
	
AS
	UPDATE Roles Set [RoleName] = @RoleName
	Where Id = @Id

	