USE SIDb
GO

CREATE PROC SelectPersonById
@Id int 
AS
	Select * From People Where [Id] = @Id
