USE SIDb
GO

CREATE PROC AddPost
	@Post varchar(50)
AS
	INSERT INTO Posts([Post]) VALUES (@Post)