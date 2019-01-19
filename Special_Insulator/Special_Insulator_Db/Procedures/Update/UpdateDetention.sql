USE SIDb
GO

CREATE PROC UpdateDetention
	@Id int,
	@DetentionDate datetime ,
	@DeliveryDate datetime ,
	@LiberationDate datetime ,
	@DetentionPlaceId  int ,
	@AccruedAmount varchar(50) ,
	@PaidAmount varchar(50) 
	
AS
	UPDATE Detentions Set
	[DetentionDate] = @DetentionDate,
	[DeliveryDate] = @DeliveryDate,
	[LiberationDate] = @LiberationDate,
	[DetentionPlaceId] = @DetentionPlaceId,
	[AccruedAmount] = @AccruedAmount,
	[PaidAmount] = @PaidAmount
	Where Id = @Id

	