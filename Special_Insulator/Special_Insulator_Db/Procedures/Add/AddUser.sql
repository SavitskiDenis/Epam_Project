USE SIDb
GO

CREATE PROC AddUser
	@Login varchar(50),
	@Password varchar(50),
	@Email varchar(50),
	@PeopleId int
AS
	INSERT INTO Users([Login],[Password],[Email],[PeopleId]) VALUES (@Login, @Password,@Email,@PeopleId)