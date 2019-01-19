USE SIDb
GO

CREATE PROC UpdatePhone
	@DetaineeId int,
	@Number varchar(50)
AS
	UPDATE Phones Set[Number] = @Number
	Where [DetaineeId] = @DetaineeId 

	