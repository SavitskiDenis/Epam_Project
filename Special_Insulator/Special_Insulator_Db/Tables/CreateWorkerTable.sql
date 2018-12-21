use SIDb
go 

create table Workers (
    Id int primary key IDentity,
	[WorkerPost] varchar(50) NOT NULL,
	[PeopleId] int NOT NULL
)