USE SIDb
GO

CREATE PROC Delete_Detainee
	@Id int 
AS
	Delete From Detainees Where Id = @Id;
