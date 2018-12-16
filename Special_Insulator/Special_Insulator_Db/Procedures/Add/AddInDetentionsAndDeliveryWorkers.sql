USE SIDb
GO

CREATE PROC AddInDetentionsAndDeliveryWorkers
	@Detention_Id int,
	@Worker_Id int
AS
	INSERT INTO DetentionsAndDeliveryWorkers([Detention_Id],[Worker_Id]) VALUES (@Detention_Id,@Worker_Id)