USE SIDb
GO

CREATE PROC SelectAllWorkerIdsFromDetainWorkers
AS
	Select [WorkerId] From DetentionsAndDetainWorkers 
	

