USE SIDb
GO

CREATE PROC AddDetention
	@DetaineeId int,
	@DetentionDate datetime,
	@DeliveryDate datetime,
	@LiberationDate datetime,
	@DetentionPlaceId  int,
	@AccruedAmount varchar(50),
	@PaidAmount varchar(50)
AS
	INSERT INTO Detentions([DetaineeId],[DetentionDate],[DeliveryDate],[LiberationDate],[DetentionPlaceId],[AccruedAmount],[PaidAmount]) VALUES (@DetaineeId,@DetentionDate,@DeliveryDate,@LiberationDate,@DetentionPlaceId,@AccruedAmount,@PaidAmount)
	Select SCOPE_IDENTITY()