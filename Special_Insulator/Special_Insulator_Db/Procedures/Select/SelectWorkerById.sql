USE SIDb
GO

CREATE PROC SelectWorkerById
@Id int
AS
	Select * From Workers Where [Id] = @Id