USE SIDb
GO

CREATE PROC AddInUserAndRole
	@UserId int,
	@RoleId int
AS
	INSERT INTO UserAndRole([UserId],RoleId) VALUES (@UserId,@RoleId)