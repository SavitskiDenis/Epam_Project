USE SIDb
GO

CREATE PROC AddInUserAndRole
	@User_Id int,
	@Role_Id int
AS
	INSERT INTO UserAndRole([User_Id],Role_Id) VALUES (@User_Id,@Role_Id)