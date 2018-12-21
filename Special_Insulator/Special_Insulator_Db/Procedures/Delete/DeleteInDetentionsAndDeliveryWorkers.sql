USE SIDb
GO

CREATE PROC Delete_DetDel
	@Id int 
AS
	Delete From DetentionsAndDeliveryWorkers Where [DetentionId] = @Id;
