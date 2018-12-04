Alter table UserAndRole
ADD CONSTRAINT FK_UserRole_ToUser FOREIGN KEY([User_Id])
	REFERENCES Users(Id),
CONSTRAINT FK_UserRole_ToRole FOREIGN KEY(Role_Id)
	REFERENCES Roles(Id)