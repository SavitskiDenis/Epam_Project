USE SIDb
GO

CREATE PROC AddDetentionPlace
	@Address varchar(Max)
AS
	INSERT INTO DetentionPlaces([Address]) VALUES (@Address)