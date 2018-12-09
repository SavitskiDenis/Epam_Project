USE SIDb
GO

CREATE PROC AddInDetantionsAndReleaseWorkers
	@Detantion_Id int,
	@Worker_Id int
AS
	INSERT INTO DetantionsAndReleaseWorkers([Detantion_Id],[Worker_Id]) VALUES (@Detantion_Id,@Worker_Id)