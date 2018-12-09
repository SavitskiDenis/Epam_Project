USE SIDb
GO

CREATE PROC AddUser
	@Login varchar(50),
	@Password varchar(50),
	@E_mail varchar(50),
	@PeopleId int
AS
	INSERT INTO Users([Login],[Password],[E_mail],[PeopleId]) VALUES (@Login, @Password,@E_mail,@PeopleId)