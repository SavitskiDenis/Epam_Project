USE SIDb
GO

CREATE PROC Delete_User
	@Id int 
AS
	Delete From Users Where Id = @Id;
