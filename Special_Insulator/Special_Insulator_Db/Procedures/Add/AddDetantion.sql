USE SIDb
GO

CREATE PROC AddDetantion
	@Detainee_Id int,
	@DetentionDate datetime,
	@DeliveryDate datetime,
	@LiberationDate datetime,
	@Department_Id  int,
	@AccruedAmount decimal,
	@PaidAmount decimal
AS
	INSERT INTO Detantions([Detainee_Id],[DetentionDate],[DeliveryDate],[LiberationDate],[Department_Id],[AccruedAmount],[PaidAmount]) VALUES (@Detainee_Id,@DetentionDate,@DeliveryDate,@LiberationDate,@Department_Id,@AccruedAmount,@PaidAmount)