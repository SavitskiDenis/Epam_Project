USE SIDb
GO

INSERT INTO Roles(RoleName) VALUES ('User'),('Editor'),('Admin')
INSERT INTO Users([Login],[Password],[Email]) VALUES ('admin','adminadmin','admin@yandex.by')
INSERT INTO UserAndRole([UserId],RoleId) VALUES (1,1),(1,2),(1,3)
INSERT INTO Posts([Post]) VALUES ('Рядовой'),('Сержант'),('Прапорщик'),('Лейтенант'),('Капитан'),('Майор'),('Генерал')
INSERT INTO Statuses([StatusName]) VALUES ('Женат'),('Замужем'),('Не женат'),('Не замужем')
