USE SIDb
GO

CREATE PROC Delete_DR
	@Id int 
AS
	Delete From DetentionsAndReleaseWorkers Where [Detention_Id] = @Id;
