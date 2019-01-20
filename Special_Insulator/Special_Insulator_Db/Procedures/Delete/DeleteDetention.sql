USE SIDb
GO

CREATE PROC DeleteDetention
	@Id int 
AS
	Declare @detaineeId int;
	Select @detaineeId = [DetaineeId] From Detentions Where Id = @Id;
	Delete From Detentions Where Id = @Id;
	Select @detaineeId;