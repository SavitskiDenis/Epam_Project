use SIDb
go 

create table Detantions (
    Id int primary key IDentity,
	[Detainee_Id] int NOT NULL,
	[DetentionDate] time NOT NULL,
	[DeliveryDate] time NOT NULL,
	[LiberationDate] time NOT NULL,
	[Department_Id]  int NOT NULL,
	[AccruedAmount] decimal NOT NULL,
	[PaidAmount] decimal NOT NULL,

)