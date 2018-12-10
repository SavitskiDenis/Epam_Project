USE SIDb
GO

CREATE PROC Delete_People
	@Id int 
AS
	Delete From People Where Id = @Id;
