USE SIDb
GO

CREATE PROC SelectRolesIdByUserId
@Id int
AS
	Select RoleId From UserAndRole Where [UserId] = @Id