USE SIDb
GO

CREATE PROC AddPhone
	@Address varchar(Max)
AS
	INSERT INTO Departments([Address]) VALUES (@Address)