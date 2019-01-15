USE SIDb
GO

CREATE PROC AddWorker
	@WorkerPostId int,
	@PeopleId int
AS
	INSERT INTO Workers([WorkerPostId],[PeopleId]) VALUES (@WorkerPostId, @PeopleId)