USE SIDb
GO

CREATE PROC AddWorker
	@WorkerPost varchar(50),
	@PeopleId int
AS
	INSERT INTO Workers([WorkerPost],[PeopleId]) VALUES (@WorkerPost, @PeopleId)