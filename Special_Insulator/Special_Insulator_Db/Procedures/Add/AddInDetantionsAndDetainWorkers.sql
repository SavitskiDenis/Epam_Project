USE SIDb
GO

CREATE PROC AddInDetantionsAndDetainWorkers
	@Detantion_Id int,
	@Worker_Id int
AS
	INSERT INTO DetantionsAndDetainWorkers([Detantion_Id],[Worker_Id]) VALUES (@Detantion_Id,@Worker_Id)