USE SIDb
GO

CREATE PROC Delete_Role
	@Id int 
AS
	Delete From Roles Where Id = @Id;
