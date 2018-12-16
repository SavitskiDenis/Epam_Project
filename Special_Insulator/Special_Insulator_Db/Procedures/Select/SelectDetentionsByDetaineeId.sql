USE SIDb
GO

CREATE PROC SelectDetentionsByDetaineeId
@Detainee_Id int
AS
	Select * From Detentions Where [Detainee_Id] = @Detainee_Id 

