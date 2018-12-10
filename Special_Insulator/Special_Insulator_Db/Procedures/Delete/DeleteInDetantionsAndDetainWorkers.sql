USE SIDb
GO

CREATE PROC Delete_DD
	@Id int 
AS
	Delete From DetantionsAndDetainWorkers Where [Detantion_Id] = @Id;
