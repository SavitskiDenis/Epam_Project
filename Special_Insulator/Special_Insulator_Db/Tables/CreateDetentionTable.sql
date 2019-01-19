use SIDb
go 

create table Detentions (
    Id int primary key IDentity,
	[DetaineeId] int NOT NULL,
	[DetentionDate] datetime NOT NULL,
	[DeliveryDate] datetime NOT NULL,
	[LiberationDate] datetime NOT NULL,
	[DetentionPlaceId]  int NOT NULL,
	[AccruedAmount] varchar(50) NOT NULL,
	[PaidAmount] varchar(50) NOT NULL,
)