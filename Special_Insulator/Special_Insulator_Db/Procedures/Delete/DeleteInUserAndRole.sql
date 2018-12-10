USE SIDb
GO

CREATE PROC Delete_UserRole
	@Id int 
AS
	Delete From UserAndRole Where [User_Id] = @Id;
