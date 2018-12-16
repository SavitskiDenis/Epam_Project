USE SIDb
GO

CREATE PROC Delete_Detention
	@Id int 
AS
	Delete From Detentions Where Id = @Id;
