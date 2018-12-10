USE SIDb
GO

CREATE PROC Delete_Worker
	@Id int 
AS
	Delete From Workers Where Id = @Id;
