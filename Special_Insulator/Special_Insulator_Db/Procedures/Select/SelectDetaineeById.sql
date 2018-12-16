USE SIDb
GO

CREATE PROC SelectDetaineeById
@Id int
AS
	Select * From Detainees Where [Id] = @Id
