use SIDb
go 

create table Users (
    Id int primary key IDentity,
	[Login] varchar(50) NOT NULL,
	[Password] varchar(50) NOT NULL,
	[Email] varchar(50) NOT NULL,
	[PeopleId] int NULL
)