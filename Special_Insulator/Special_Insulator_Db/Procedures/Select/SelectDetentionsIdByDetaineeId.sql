USE SIDb
GO

CREATE PROC SelectDetentionsIdByDetaineeId
@Id int
AS
	Select Id From Detentions Where [DetaineeId] = @Id 

