use SIDb
go 

create table Detentions (
    Id int primary key IDentity,
	[DetaineeId] int NOT NULL,
	[DetentionDate] datetime NOT NULL,
	[DeliveryDate] datetime NOT NULL,
	[LiberationDate] datetime NOT NULL,
	[DepartmentId]  int NOT NULL,
	[AccruedAmount] decimal NOT NULL,
	[PaidAmount] decimal NOT NULL,
)