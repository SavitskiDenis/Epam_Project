USE SIDb
GO

CREATE PROC DeletePost
	@Id int 
AS
	Delete From Posts Where Id = @Id;
