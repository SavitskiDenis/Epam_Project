USE SIDb
GO

CREATE PROC SelectAllPostIdsFromWorkers
AS
	Select [WorkerPostId] From Workers 