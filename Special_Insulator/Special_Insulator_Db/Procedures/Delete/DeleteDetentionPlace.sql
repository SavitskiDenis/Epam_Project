USE SIDb
GO

CREATE PROC DeleteDetentionPlace
	@Id int 
AS
	Delete From DetentionPlaces Where Id = @Id;
