USE SIDb
GO

CREATE PROC UpdateDetantion
	@Id int,
	@Detainee_Id int,
	@DetentionDate time ,
	@DeliveryDate time ,
	@LiberationDate time ,
	@Department_Id  int ,
	@AccruedAmount decimal ,
	@PaidAmount decimal 
	
AS
	UPDATE Detantions Set [Detainee_Id] = @Detainee_Id,
	[DetentionDate] = @DetentionDate,
	[DeliveryDate] = @DeliveryDate,
	[LiberationDate] = @LiberationDate,
	[Department_Id] = @Department_Id,
	[AccruedAmount] = @AccruedAmount,
	[PaidAmount] = @PaidAmount
	Where Id = @Id

	