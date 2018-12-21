USE SIDb
GO

CREATE PROC AddInDetentionsAndDetainWorkers
	@DetentionId int,
	@WorkerId int
AS
	INSERT INTO DetentionsAndDetainWorkers([DetentionId],[WorkerId]) VALUES (@DetentionId,@WorkerId)