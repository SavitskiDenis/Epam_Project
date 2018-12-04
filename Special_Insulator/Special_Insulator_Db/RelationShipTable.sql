Alter table UserAndRole
ADD CONSTRAINT FK_UserRole_User FOREIGN KEY([User_Id])
	REFERENCES Users(Id),
CONSTRAINT FK_UserRole_Role FOREIGN KEY(Role_Id)
	REFERENCES Roles(Id)