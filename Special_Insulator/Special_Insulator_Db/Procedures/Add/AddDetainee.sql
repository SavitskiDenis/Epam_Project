USE SIDb
GO

CREATE PROC AddDetainee
	@PeopleId int,
	@BornDate datetime,
	@StatusId int,
	@Workplace varchar(50),
	@Photo varbinary(MAX),
	@Address varchar(200),
	@AdditionalInformation varchar(200)=''
AS
	INSERT INTO Detainees([PeopleId],[BornDate],[StatusId],[Workplace],[Photo],[Address],[AdditionalInformation]) VALUES (@PeopleId,@BornDate,@StatusId,@Workplace,@Photo,@Address,@AdditionalInformation)
	Select SCOPE_IDENTITY()