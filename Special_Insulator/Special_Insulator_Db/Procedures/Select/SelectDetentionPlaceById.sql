USE SIDb
GO

CREATE PROC SelectDetentionPlaceById
@Id int
AS
	Select * From DetentionPlaces Where [Id] = @Id