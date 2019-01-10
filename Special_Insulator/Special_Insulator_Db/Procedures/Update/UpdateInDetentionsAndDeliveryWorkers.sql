USE SIDb
GO

CREATE PROC UpdateInDetentionsAndDeliveryWorkers
@DetentionId int ,
@WorkerId int

AS
	UPDATE DetentionsAndDeliveryWorkers Set
	[WorkerId] = @WorkerId
	Where [DetentionId] = @DetentionId

	