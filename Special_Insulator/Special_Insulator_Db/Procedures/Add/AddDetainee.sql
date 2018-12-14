USE SIDb
GO

CREATE PROC AddDetainee
	@People_Id int,
	@BornDate datetime,
	@Status varchar(25),
	@Workplace varchar(50),
	@Photo varchar(50) ='',
	@Address varchar(200),
	@Additional_information varchar(200)=''
AS
	INSERT INTO Detainees([People_Id],[BornDate],[Status],[Workplace],[Photo],[Address],[Additional_information]) VALUES (@People_Id,@BornDate,@Status,@Workplace,@Photo,@Address,@Additional_information)