USE SIDb
GO

CREATE PROC SelectRoleById
@Id int
AS
	Select RoleName From Roles Where Id = @Id