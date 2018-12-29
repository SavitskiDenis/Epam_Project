USE SIDb
GO

CREATE PROC SelectReleaseWorkerId
@DetentionId int
AS
	Select [WorkerId] From DetentionsAndReleaseWorkers Where [DetentionId] = @DetentionId