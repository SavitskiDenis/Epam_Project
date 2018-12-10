USE SIDb
GO

CREATE PROC UpdateDepartment
	@Id int,
	@Address varchar(Max)
	
AS
	UPDATE Departments Set [Address] = @Address
	Where Id = @Id

	