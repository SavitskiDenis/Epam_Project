USE SIDb
GO

CREATE PROC UpdateDetention
	@Id int,
	@DetentionDate datetime ,
	@DeliveryDate datetime ,
	@LiberationDate datetime ,
	@DepartmentId  int ,
	@AccruedAmount decimal ,
	@PaidAmount decimal 
	
AS
	UPDATE Detentions Set
	[DetentionDate] = @DetentionDate,
	[DeliveryDate] = @DeliveryDate,
	[LiberationDate] = @LiberationDate,
	[DepartmentId] = @DepartmentId,
	[AccruedAmount] = @AccruedAmount,
	[PaidAmount] = @PaidAmount
	Where Id = @Id

	