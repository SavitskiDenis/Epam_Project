USE SIDb
GO

CREATE PROC UpdateWorker
	@Id int,
	@WorkerPost varchar(50),
	@PeopleId int 
	
AS
	UPDATE Workers Set [WorkerPost] = @WorkerPost,
	[PeopleId]  = @PeopleId
	Where Id = @Id

	