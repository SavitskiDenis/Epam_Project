USE SIDb
GO

--Many To Many

Alter table UserAndRole
ADD CONSTRAINT FK___UserRoleToUsers FOREIGN KEY([User_Id])
	REFERENCES Users(Id),
CONSTRAINT FK___UserRoleToRoles FOREIGN KEY(Role_Id)
	REFERENCES Roles(Id);


Alter table DetantionsAndDetainWorkers
ADD CONSTRAINT FK_DetantionDWorker_ToDetantions FOREIGN KEY([Detantion_Id])
	REFERENCES Detantions(Id),
CONSTRAINT FK_DetantionDWorker_ToWorkers FOREIGN KEY([Worker_Id])
	REFERENCES Workers(Id);


Alter table DetantionsAndDeliveryWorkers
ADD CONSTRAINT FK_DetantionDelWorker_ToDetantions FOREIGN KEY([Detantion_Id])
	REFERENCES Detantions(Id),
CONSTRAINT FK_DetantionDelWorker_ToWorkers FOREIGN KEY([Worker_Id])
	REFERENCES Workers(Id);

Alter table DetantionsAndReleaseWorkers
ADD CONSTRAINT FK_DetantionRWorker_ToDetantions FOREIGN KEY([Detantion_Id])
	REFERENCES Detantions(Id),
CONSTRAINT FK_DetantionRWorker_ToWorkers FOREIGN KEY([Worker_Id])
	REFERENCES Workers(Id);

------------

--- One TO Many

ALTER TABLE Phones
ADD CONSTRAINT FK_Phone_Detainees FOREIGN KEY([Detainee_Id]) 
    REFERENCES Detainees(Id);

ALTER TABLE Detantions
ADD CONSTRAINT FK_Detantion_Detainees FOREIGN KEY([Detainee_Id]) 
    REFERENCES Detainees(Id),
CONSTRAINT FK_Detantion_Departments FOREIGN KEY([Department_Id])
	REFERENCES Departments(Id);

ALTER TABLE Detainees
ADD CONSTRAINT FK_Detainees_People FOREIGN KEY([People_Id]) 
    REFERENCES People(Id);

ALTER TABLE Workers
ADD CONSTRAINT FK_Workers_People FOREIGN KEY([People_Id]) 
    REFERENCES People(Id);


