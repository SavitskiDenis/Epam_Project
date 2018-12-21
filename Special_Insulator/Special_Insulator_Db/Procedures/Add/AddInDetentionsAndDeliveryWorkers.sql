USE SIDb
GO

CREATE PROC AddInDetentionsAndDeliveryWorkers
	@DetentionId int,
	@WorkerId int
AS
	INSERT INTO DetentionsAndDeliveryWorkers([DetentionId],[WorkerId]) VALUES (@DetentionId,@WorkerId)