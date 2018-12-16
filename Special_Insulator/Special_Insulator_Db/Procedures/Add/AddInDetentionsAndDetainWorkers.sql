USE SIDb
GO

CREATE PROC AddInDetentionsAndDetainWorkers
	@Detention_Id int,
	@Worker_Id int
AS
	INSERT INTO DetentionsAndDetainWorkers([Detention_Id],[Worker_Id]) VALUES (@Detention_Id,@Worker_Id)