USE SIDb
GO

CREATE PROC Delete_Phone
	@Id int 
AS
	Delete From Phones Where Id = @Id;
