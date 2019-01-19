USE SIDb
GO

CREATE PROC UpdateDetentionPlace
	@Id int,
	@Address varchar(Max)
	
AS
	UPDATE DetentionPlaces Set [Address] = @Address
	Where Id = @Id

	