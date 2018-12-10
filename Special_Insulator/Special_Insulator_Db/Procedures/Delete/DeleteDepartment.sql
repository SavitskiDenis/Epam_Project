USE SIDb
GO

CREATE PROC Delete_Department
	@Id int 
AS
	Delete From Departments Where Id = @Id;
