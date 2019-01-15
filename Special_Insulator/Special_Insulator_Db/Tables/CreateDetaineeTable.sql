use SIDb
go 

create table Detainees (
    Id int primary key IDentity,
	[PeopleId] int NOT NULL,
	[BornDate] datetime NOT NULL,
	[Status] varchar(25) NOT NUll,
	[Workplace] varchar(50) NOT NULL,
	[Photo] varbinary(MAX) NULL,
	[Address] varchar(200) NOT NULL,
	[AdditionalInformation] varchar(200) NULL,

)