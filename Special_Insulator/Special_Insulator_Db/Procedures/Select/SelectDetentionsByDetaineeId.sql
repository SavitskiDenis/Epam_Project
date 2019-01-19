USE SIDb
GO

CREATE PROC SelectDetentionsByDetaineeId
@DetaineeId int
AS
	Select Detentions.*,DetentionPlaces.[Address] as 'Address' From Detentions 
	Inner Join DetentionPlaces on [DetentionPlaceId] = DetentionPlaces.Id
	where Detentions.[DetaineeId] = @DetaineeId;

