USE SIDb
GO

CREATE PROC UpdateWorker
	@Id int,
	@WorkerPost varchar(50),
	@People_Id int 
	
AS
	UPDATE Workers Set [WorkerPost] = @WorkerPost,
	[People_Id]  = @People_Id
	Where Id = @Id

	