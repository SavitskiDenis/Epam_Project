USE SIDb
GO

CREATE PROC AddDetainee
	@PeopleId int,
	@BornDate datetime,
	@Status varchar(25),
	@Workplace varchar(50),
	@Photo varbinary(MAX),
	@Address varchar(200),
	@AdditionalInformation varchar(200)=''
AS
	INSERT INTO Detainees([PeopleId],[BornDate],[Status],[Workplace],[Photo],[Address],[AdditionalInformation]) VALUES (@PeopleId,@BornDate,@Status,@Workplace,@Photo,@Address,@AdditionalInformation)
	Select SCOPE_IDENTITY()