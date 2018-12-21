USE SIDb
GO

CREATE PROC AddInDetentionsAndReleaseWorkers
	@DetentionId int,
	@WorkerId int
AS
	INSERT INTO DetentionsAndReleaseWorkers([DetentionId],[WorkerId]) VALUES (@DetentionId,@WorkerId)