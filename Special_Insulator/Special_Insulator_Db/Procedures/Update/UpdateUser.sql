USE SIDb
GO

CREATE PROC UpdateUser
	@Id int,
	@Login varchar(50) ,
	@Password varchar(50),
	@E_mail varchar(50),
	@PeopleId int 
	
AS
	UPDATE Users Set [Login] = @Login,
	[Password] = @Password,
	[E_mail] =  @E_mail,
	[PeopleId] = @PeopleId
	Where Id = @Id

	