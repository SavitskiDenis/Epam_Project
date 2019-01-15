USE SIDb
GO

CREATE PROC AddUser
	@Login varchar(50),
	@Password varchar(50),
	@Email varchar(50)
AS
	INSERT INTO Users([Login],[Password],[Email]) VALUES (@Login, @Password,@Email)
	Select SCOPE_IDENTITY()