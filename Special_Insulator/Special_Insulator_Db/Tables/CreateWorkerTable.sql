use SIDb
go 

create table Workers (
    Id int primary key IDentity,
	[WorkerPostId] int NOT NULL,
	[PeopleId] int NOT NULL
)