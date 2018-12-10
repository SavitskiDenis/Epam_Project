USE SIDb
GO

CREATE PROC Delete_DetDel
	@Id int 
AS
	Delete From DetantionsAndDeliveryWorkers Where [Detantion_Id] = @Id;
