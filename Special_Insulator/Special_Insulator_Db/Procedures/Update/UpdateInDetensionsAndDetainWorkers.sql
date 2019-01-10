USE SIDb
GO

CREATE PROC UpdateInDetensionsAndDetainWorkers
@DetentionId int ,
@WorkerId int

AS
	UPDATE DetentionsAndDetainWorkers Set
	[WorkerId] = @WorkerId
	Where [DetentionId] = @DetentionId

	