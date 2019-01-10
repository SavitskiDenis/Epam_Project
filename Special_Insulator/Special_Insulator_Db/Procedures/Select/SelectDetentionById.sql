USE SIDb
GO

CREATE PROC SelectDetentionById
@Id int
AS
	Select * From Detentions Where Id = @Id 

