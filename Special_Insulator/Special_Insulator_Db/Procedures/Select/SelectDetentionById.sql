USE SIDb
GO

CREATE PROC SelectDetentionById
@Id int
AS
	Select Detentions.*,DetentionPlaces.[Address] as 'Address' From Detentions 
	Inner Join DetentionPlaces on [DetentionPlaceId] = DetentionPlaces.Id
	where Detentions.Id = @Id;

