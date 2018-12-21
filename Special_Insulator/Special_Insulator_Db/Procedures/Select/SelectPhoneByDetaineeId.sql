USE SIDb
GO

CREATE PROC SelectPhoneByDetaineeId
@DetaineeId int
AS
	Select * From Phones Where [DetaineeId] = @DetaineeId
