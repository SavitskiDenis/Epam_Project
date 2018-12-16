USE SIDb
GO

CREATE PROC Delete_Detainee
	@Id int
AS
	Delete From Phones Where Detainee_Id = @Id
	Declare @person_id int 
	Select  @person_id = [People_Id] From Detainees Where Id = @Id;
	Delete From Detainees Where Id = @Id;
	Select @person_id
	
	
