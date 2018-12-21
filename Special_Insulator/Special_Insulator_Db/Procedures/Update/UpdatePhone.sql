USE SIDb
GO

CREATE PROC UpdatePhone
	@Id int,
	@DetaineeId int,
	@Number varchar(50)
AS
	UPDATE Phones Set [DetaineeId] = @DetaineeId, [Number] = @Number
	Where Id = @Id

	