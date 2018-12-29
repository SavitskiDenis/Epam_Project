USE SIDb
GO

CREATE PROC Delete_Worker
	@Id int 
AS
	Declare @personId int
	Select  @personId = [PeopleId] From Workers Where Id = @Id;
	Delete From Workers Where Id = @Id;
	Select @personId

