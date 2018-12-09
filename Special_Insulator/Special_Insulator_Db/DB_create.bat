sqlcmd -S.\ -E -i %DBCreate.sql
sqlcmd -S.\ -E -i %Tables/CreateRoleTable.sql
sqlcmd -S.\ -E -i %Tables/CreateUserTable.sql
sqlcmd -S.\ -E -i %Tables/UserAndRole.sql
sqlcmd -S.\ -E -i %Tables/CreateDetaineeTable.sql
sqlcmd -S.\ -E -i %Tables/CreateWorkerTable.sql
sqlcmd -S.\ -E -i %Tables/CreateDepartmentTable.sql
sqlcmd -S.\ -E -i %Tables/CreateDetantionTable.sql
sqlcmd -S.\ -E -i %Tables/CreatePeopleTable.sql
sqlcmd -S.\ -E -i %Tables/CreatePhoneTable.sql
sqlcmd -S.\ -E -i %Tables/DetansionsAndDetainWorkers.sql
sqlcmd -S.\ -E -i %Tables/DetantionsAndDeliveryWorkers.sql
sqlcmd -S.\ -E -i %Tables/DetantionsAndReleaseWorkers.sql



sqlcmd -S.\ -E -i %RelationShip.sql



PAUSE
