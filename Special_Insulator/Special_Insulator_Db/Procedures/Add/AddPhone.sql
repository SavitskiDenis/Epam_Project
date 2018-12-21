USE SIDb
GO

CREATE PROC AddPhone
	@DetaineeId int,
	@Number varchar(50)
AS
	INSERT INTO Phones([DetaineeId] ,[Number] ) VALUES (@DetaineeId, @Number)