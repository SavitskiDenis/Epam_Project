USE SIDb
GO

CREATE PROC UpdateUser
	@Id int,
	@Login varchar(50) ,
	@Password varchar(50),
	@Email varchar(50)
AS
	UPDATE Users Set [Login] = @Login,
	[Password] = @Password,
	[Email] =  @Email
	Where Id = @Id

	