USE SIDb
GO

CREATE PROC Delete_Detantion
	@Id int 
AS
	Delete From Detantions Where Id = @Id;
