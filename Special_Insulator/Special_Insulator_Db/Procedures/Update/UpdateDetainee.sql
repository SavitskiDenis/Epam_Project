USE SIDb
GO

CREATE PROC UpdateDetainee
	@Id int,
	@PeopleId int,
	@BornDate datetime,
	@Status varchar(25),
	@Workplace varchar(50) ,
	@Photo varbinary(MAX) ,
	@Address varchar(200),
	@AdditionalInformation varchar(200)='' 
	
AS
	UPDATE Detainees Set [PeopleId] = @PeopleId ,
	[BornDate] = @BornDate ,
	[Status] = @Status ,
	[Workplace] = @Workplace ,
	[Photo] = @Photo ,
	[Address] = @Address ,
	[AdditionalInformation] = @AdditionalInformation
	Where Id = @Id

	