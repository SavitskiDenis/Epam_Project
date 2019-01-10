USE SIDb
GO

CREATE PROC DeleteDetentionByDetaineeId
	@Id int 
AS
	Delete From Detentions Where [DetaineeId] = @Id;
