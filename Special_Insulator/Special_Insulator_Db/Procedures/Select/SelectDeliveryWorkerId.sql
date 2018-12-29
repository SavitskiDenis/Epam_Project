USE SIDb
GO

CREATE PROC SelectDeliveryWorkerId
@DetentionId int
AS
	Select [WorkerId] From DetentionsAndDeliveryWorkers Where [DetentionId] = @DetentionId