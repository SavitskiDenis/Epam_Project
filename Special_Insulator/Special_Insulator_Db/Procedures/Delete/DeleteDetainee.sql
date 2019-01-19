USE SIDb
GO

CREATE PROC DeleteDetainee
	@Id int
AS
	Delete From Phones Where DetaineeId = @Id
	Declare @personId int 
	Select  @personId = [PeopleId] From Detainees Where Id = @Id;
	Delete From Detainees Where Id = @Id;
	Select @personId
	
	
