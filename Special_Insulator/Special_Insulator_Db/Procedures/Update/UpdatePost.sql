USE SIDb
GO

CREATE PROC UpdatePost
	@Id int,
	@Post varchar(50)
AS
	UPDATE Posts Set [Post] = @Post
	Where Id = @Id

	