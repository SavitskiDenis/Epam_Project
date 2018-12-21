USE SIDb
GO

CREATE PROC Delete_UserRole
	@Id int 
AS
	Delete From UserAndRole Where [UserId] = @Id;
