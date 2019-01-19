USE SIDb
GO

CREATE PROC UpdatePeople
	@Id int,
	@FirstName varchar(50) ,
	@LastName varchar(50),
	@Patronymic varchar(50) = ''
AS
	UPDATE People Set [FirstName] =@FirstName,
	[LastName] = @LastName,
	[Patronymic] = @Patronymic
	Where Id = @Id

	