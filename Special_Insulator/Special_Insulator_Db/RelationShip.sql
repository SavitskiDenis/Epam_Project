USE SIDb
GO

--Many To Many

Alter table UserAndRole
ADD CONSTRAINT FK_UserRoleToUsers FOREIGN KEY([UserId])
	REFERENCES Users(Id),
CONSTRAINT FK_UserRoleToRoles FOREIGN KEY(RoleId)
	REFERENCES Roles(Id);


Alter table DetentionsAndDetainWorkers
ADD CONSTRAINT FK_DetentionDWorkerToDetantions FOREIGN KEY([DetentionId])
	REFERENCES Detentions(Id),
CONSTRAINT FK_DetentionDWorkerToWorkers FOREIGN KEY([WorkerId])
	REFERENCES Workers(Id);


Alter table DetentionsAndDeliveryWorkers
ADD CONSTRAINT FK_DetentionDelWorkerToDetantions FOREIGN KEY([DetentionId])
	REFERENCES Detentions(Id),
CONSTRAINT FK_DetentionDelWorkerToWorkers FOREIGN KEY([WorkerId])
	REFERENCES Workers(Id);

Alter table DetentionsAndReleaseWorkers
ADD CONSTRAINT FK_DetentionRWorkerToDetantions FOREIGN KEY([DetentionId])
	REFERENCES Detentions(Id),
CONSTRAINT FK_DetentionRWorkerToWorkers FOREIGN KEY([WorkerId])
	REFERENCES Workers(Id);

------------

--- One TO Many

ALTER TABLE Phones
ADD CONSTRAINT FK_Phone_Detainees FOREIGN KEY([DetaineeId]) 
    REFERENCES Detainees(Id);

ALTER TABLE Detentions
ADD CONSTRAINT FK_Detantion_Detainees FOREIGN KEY([DetaineeId]) 
    REFERENCES Detainees(Id),
CONSTRAINT FK_DetantionDepartments FOREIGN KEY([DepartmentId])
	REFERENCES Departments(Id);

ALTER TABLE Detainees
ADD CONSTRAINT FK_Detainees_People FOREIGN KEY([PeopleId]) 
    REFERENCES People(Id);

ALTER TABLE Workers
ADD CONSTRAINT FK_Workers_People FOREIGN KEY([PeopleId]) 
    REFERENCES People(Id);


