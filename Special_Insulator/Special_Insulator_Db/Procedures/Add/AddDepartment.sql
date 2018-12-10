USE SIDb
GO

CREATE PROC AddDepartment
	@Address varchar(Max)
AS
	INSERT INTO Departments([Address]) VALUES (@Address)