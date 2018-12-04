use SIDb
go 

create table Workers (
    Id int primary key IDentity,
	[FullName] varchar(50) NOT NULL,
	[WorkerPost] varchar(50) NOT NULL,
	[UserId] int NOT NULL
)