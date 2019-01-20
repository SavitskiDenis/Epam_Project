USE SIDb
GO

CREATE PROC SelectAllDetentionPlaceIdsFromDetentions
AS
	Select [DetentionPlaceId] From Detentions 