USE SIDb
GO

CREATE PROC UpdateDetainee
	@Id int,
	@People_Id int,
	@BornDate datetime,
	@Status varchar(25),
	@Workplace varchar(50) ,
	@Photo varchar(50)='' ,
	@Address varchar(200),
	@Additional_information varchar(200)='' 
	
AS
	UPDATE Detainees Set [People_Id] = @People_Id ,
	[BornDate] = @BornDate ,
	[Status] = @Status ,
	[Workplace] = @Workplace ,
	[Photo] = @Photo ,
	[Address] = @Address ,
	[Additional_information] = @Additional_information
	Where Id = @Id

	