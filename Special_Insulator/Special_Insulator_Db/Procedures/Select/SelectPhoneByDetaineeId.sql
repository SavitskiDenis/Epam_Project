USE SIDb
GO

CREATE PROC SelectPhoneByDetaineeId
@Detainee_Id int
AS
	Select * From Phones Where [Detainee_Id] = @Detainee_Id
