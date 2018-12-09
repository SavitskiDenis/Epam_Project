USE SIDb
GO

CREATE PROC AddPhone
	@Detainee_Id int,
	@Number varchar(50)
AS
	INSERT INTO Phones([Detainee_Id] ,[Number] ) VALUES (@Detainee_Id, @Number)