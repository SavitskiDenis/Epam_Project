USE SIDb
GO

CREATE PROC AddWorker
	@WorkerPost varchar(50),
	@People_Id int
AS
	INSERT INTO Workers([WorkerPost],[People_Id]) VALUES (@WorkerPost, @People_Id)