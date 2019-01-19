use SIDb
go 

create table People (
    Id int primary key IDentity,
	[FirstName] varchar(50) NOT NUll,
	[LastName] varchar(50) NOT NUll,
	[Patronymic] varchar(50) NUll
)