USE SIDb
GO

CREATE PROC SelectAllWorkerIdsFromDeliveryWorkers
AS
	Select [WorkerId] From DetentionsAndDeliveryWorkers 
	

