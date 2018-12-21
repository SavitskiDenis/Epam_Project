use SIDb
go 

create table Phones (
    Id int primary key IDentity,
	[DetaineeId] int NOT NULL,
	[Number] varchar(50) NOT NULL
)