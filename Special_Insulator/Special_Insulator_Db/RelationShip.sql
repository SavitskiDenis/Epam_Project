USE SIDb
GO

--Many To Many

Alter table UserAndRole
ADD CONSTRAINT FK___UserRoleToUsers FOREIGN KEY([User_Id])
	REFERENCES Users(Id),
CONSTRAINT FK___UserRoleToRoles FOREIGN KEY(Role_Id)
	REFERENCES Roles(Id);


Alter table DetentionsAndDetainWorkers
ADD CONSTRAINT FK_DetentionDWorker_ToDetantions FOREIGN KEY([Detention_Id])
	REFERENCES Detentions(Id),
CONSTRAINT FK_DetentionDWorker_ToWorkers FOREIGN KEY([Worker_Id])
	REFERENCES Workers(Id);


Alter table DetentionsAndDeliveryWorkers
ADD CONSTRAINT FK_DetentionDelWorker_ToDetantions FOREIGN KEY([Detention_Id])
	REFERENCES Detentions(Id),
CONSTRAINT FK_DetentionDelWorker_ToWorkers FOREIGN KEY([Worker_Id])
	REFERENCES Workers(Id);

Alter table DetentionsAndReleaseWorkers
ADD CONSTRAINT FK_DetentionRWorker_ToDetantions FOREIGN KEY([Detention_Id])
	REFERENCES Detentions(Id),
CONSTRAINT FK_DetentionRWorker_ToWorkers FOREIGN KEY([Worker_Id])
	REFERENCES Workers(Id);

------------

--- One TO Many

ALTER TABLE Phones
ADD CONSTRAINT FK_Phone_Detainees FOREIGN KEY([Detainee_Id]) 
    REFERENCES Detainees(Id);

ALTER TABLE Detentions
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


