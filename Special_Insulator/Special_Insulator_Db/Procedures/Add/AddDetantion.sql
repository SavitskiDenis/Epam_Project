USE SIDb
GO

CREATE PROC AddDetantion
	@Detainee_Id int,
	@DetentionDate time,
	@DeliveryDate time,
	@LiberationDate time,
	@Department_Id  int,
	@AccruedAmount decimal,
	@PaidAmount decimal
AS
	INSERT INTO Detantions([Detainee_Id],[DetentionDate],[DeliveryDate],[LiberationDate],[Department_Id],[AccruedAmount],[PaidAmount]) VALUES (@Detainee_Id,@DetentionDate,@DeliveryDate,@LiberationDate,@Department_Id,@AccruedAmount,@PaidAmount)