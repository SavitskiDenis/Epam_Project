use SIDb
go 

create table Detantions (
    Id int primary key IDentity,
	[Detainee_Id] int NOT NULL,
	[DetentionDate] datetime NOT NULL,
	[DeliveryDate] datetime NOT NULL,
	[LiberationDate] datetime NOT NULL,
	[Department_Id]  int NOT NULL,
	[AccruedAmount] decimal NOT NULL,
	[PaidAmount] decimal NOT NULL,

)