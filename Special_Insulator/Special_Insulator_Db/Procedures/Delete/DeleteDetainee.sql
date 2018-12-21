USE SIDb
GO

CREATE PROC Delete_Detainee
	@Id int
AS
	Delete From Phones Where DetaineeId = @Id
	Declare @personId int 
	Select  @personId = [PeopleId] From Detainees Where Id = @Id;
	Delete From Detainees Where Id = @Id;
	Select @personId
	
	
