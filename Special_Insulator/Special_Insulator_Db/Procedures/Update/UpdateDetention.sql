USE SIDb
GO

CREATE PROC UpdateDetention
	@Id int,
	@Detainee_Id int,
	@DetentionDate datetime ,
	@DeliveryDate datetime ,
	@LiberationDate datetime ,
	@Department_Id  int ,
	@AccruedAmount decimal ,
	@PaidAmount decimal 
	
AS
	UPDATE Detentions Set [Detainee_Id] = @Detainee_Id,
	[DetentionDate] = @DetentionDate,
	[DeliveryDate] = @DeliveryDate,
	[LiberationDate] = @LiberationDate,
	[Department_Id] = @Department_Id,
	[AccruedAmount] = @AccruedAmount,
	[PaidAmount] = @PaidAmount
	Where Id = @Id

	