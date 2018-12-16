USE SIDb
GO

CREATE PROC AddInDetentionsAndReleaseWorkers
	@Detention_Id int,
	@Worker_Id int
AS
	INSERT INTO DetentionsAndReleaseWorkers([Detention_Id],[Worker_Id]) VALUES (@Detention_Id,@Worker_Id)