use SIDb
go 

create table Users (
    Id int primary key IDentity,
	[Login] varchar(50) NOT NULL,
	[Password] varchar(50) NOT NULL,
	[E_mail] varchar(50) NOT NULL
)