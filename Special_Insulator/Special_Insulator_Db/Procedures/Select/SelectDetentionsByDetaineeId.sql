USE SIDb
GO

CREATE PROC SelectDetentionsByDetaineeId
@DetaineeId int
AS
	Select * From Detentions Where [DetaineeId] = @DetaineeId 

