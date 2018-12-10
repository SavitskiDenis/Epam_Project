USE SIDb
GO

CREATE PROC UpdatePhone
	@Id int,
	@Detainee_Id int,
	@Number varchar(50)
AS
	UPDATE Phones Set [Detainee_Id] = @Detainee_Id, [Number] = @Number
	Where Id = @Id

	