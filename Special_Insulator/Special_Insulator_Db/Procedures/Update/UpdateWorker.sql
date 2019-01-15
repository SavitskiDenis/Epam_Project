USE SIDb
GO

CREATE PROC UpdateWorker
	@Id int,
	@WorkerPostId int,
	@PeopleId int 
	
AS
	UPDATE Workers Set [WorkerPostId] = @WorkerPostId,
	[PeopleId]  = @PeopleId
	Where Id = @Id

	