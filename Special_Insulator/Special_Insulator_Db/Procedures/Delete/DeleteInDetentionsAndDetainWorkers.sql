USE SIDb
GO

CREATE PROC Delete_DD
	@Id int 
AS
	Delete From DetentionsAndDetainWorkers Where [DetentionId] = @Id;
