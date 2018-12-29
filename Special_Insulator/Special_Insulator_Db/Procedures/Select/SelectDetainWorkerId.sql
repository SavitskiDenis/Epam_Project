USE SIDb
GO

CREATE PROC SelectDetainWorkerId
@DetentionId int
AS
	Select [WorkerId] From DetentionsAndDetainWorkers Where [DetentionId] = @DetentionId