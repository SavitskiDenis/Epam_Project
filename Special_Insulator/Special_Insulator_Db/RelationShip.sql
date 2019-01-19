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
ADD CONSTRAINT FK_PhoneDetainees FOREIGN KEY([DetaineeId]) 
    REFERENCES Detainees(Id);

ALTER TABLE Detentions
ADD CONSTRAINT FK_DetantionDetainees FOREIGN KEY([DetaineeId]) 
    REFERENCES Detainees(Id),
CONSTRAINT FK_DetantionDetentionPlaces FOREIGN KEY([DetentionPlaceId])
	REFERENCES DetentionPlaces(Id);

ALTER TABLE Detainees
ADD CONSTRAINT FK_DetaineesPeople FOREIGN KEY([PeopleId]) 
    REFERENCES People(Id),
CONSTRAINT FK_DetaineesStatuses FOREIGN KEY([PeopleId]) 
	REFERENCES People(Id);

ALTER TABLE Workers
ADD CONSTRAINT FK_WorkersPeople FOREIGN KEY([PeopleId]) 
    REFERENCES People(Id);




