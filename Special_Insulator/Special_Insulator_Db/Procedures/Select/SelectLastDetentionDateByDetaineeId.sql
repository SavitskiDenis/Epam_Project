USE SIDb
GO

CREATE PROC SelectLastDetentionDateByDetaineeId
@Id int
AS
	Select Max([DetentionDate]) From Detentions Where [DetaineeId] = @Id

