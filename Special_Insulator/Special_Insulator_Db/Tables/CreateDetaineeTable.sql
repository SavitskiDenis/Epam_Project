use SIDb
go 

create table Detainees (
    Id int primary key IDentity,
	[Login] varchar(50) NOT NULL,
	[FullName] varchar(100) NOT NULL,
	[BornDate] time NOT NULL,
	[Workplace] varchar(50) NOT NULL,
	[Phone] varchar(50) NOT NULL,
	[Photo] varchar(50) NOT NULL,
	[Address] varchar(200) NOT NULL,
	[Additional_information] varchar(200) NOT NULL,

)