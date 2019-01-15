USE SIDb
GO

CREATE PROC DeleteUserRole
	@Id int,
	@RoleId int
AS
	Delete From UserAndRole Where [UserId] = @Id And RoleId = @RoleId
