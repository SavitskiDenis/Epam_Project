USE SIDb
GO

CREATE PROC UpdateInDetentionsAndReleaseWorkers
@DetentionId int ,
@WorkerId int

AS
	UPDATE DetentionsAndReleaseWorkers Set
	[WorkerId] = @WorkerId
	Where [DetentionId] = @DetentionId

	