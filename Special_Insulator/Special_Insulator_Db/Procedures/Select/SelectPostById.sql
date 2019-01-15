USE SIDb
GO

CREATE PROC SelectPostById
	@Id int
AS
	Select * From Posts Where Id = @Id
