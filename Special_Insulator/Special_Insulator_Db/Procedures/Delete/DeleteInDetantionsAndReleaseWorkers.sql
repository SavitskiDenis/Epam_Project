USE SIDb
GO

CREATE PROC Delete_DR
	@Id int 
AS
	Delete From DetantionsAndReleaseWorkers Where [Detantion_Id] = @Id;
