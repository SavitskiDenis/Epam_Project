USE SIDb
GO

CREATE PROC SelectAllWorkerIdsFromReleaseWorkers
AS
	Select [WorkerId] From DetentionsAndDetainWorkers 
	

