USE SIDb
GO

CREATE PROC AddInDetantionsAndDeliveryWorkers
	@Detantion_Id int,
	@Worker_Id int
AS
	INSERT INTO DetantionsAndDeliveryWorkers([Detantion_Id],[Worker_Id]) VALUES (@Detantion_Id,@Worker_Id)