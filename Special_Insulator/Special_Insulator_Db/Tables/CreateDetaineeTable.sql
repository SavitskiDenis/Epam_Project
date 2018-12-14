use SIDb
go 

create table Detainees (
    Id int primary key IDentity,
	[People_Id] int NOT NULL,
	[BornDate] datetime NOT NULL,
	[Status] varchar(25) NOT NUll,
	[Workplace] varchar(50) NOT NULL,
	[Photo] varchar(50) NULL,
	[Address] varchar(200) NOT NULL,
	[Additional_information] varchar(200) NULL,

)