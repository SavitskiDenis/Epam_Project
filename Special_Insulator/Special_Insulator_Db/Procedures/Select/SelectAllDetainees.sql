USE SIDb
GO

CREATE PROC SelectAllDetainees
AS
	Select Detainees.*,Statuses.[StatusName] as 'StatusName',Phones.[Number] as 'PhoneNumber'  From Detainees 
	Inner Join Statuses on [StatusId] = Statuses.Id
	Inner Join Phones on Detainees.Id = Phones.[DetaineeId]
