USE SIDb
GO

CREATE PROC SelectDepartmentById
@Id int
AS
	Select * From Departments Where [Id] = @Id