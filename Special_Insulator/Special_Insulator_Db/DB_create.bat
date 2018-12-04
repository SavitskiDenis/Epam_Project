sqlcmd -S.\ -E -i %DBCreate.sql
sqlcmd -S.\ -E -i %Tables/CreateRoleTable.sql
sqlcmd -S.\ -E -i %Tables/CreateUserTable.sql
sqlcmd -S.\ -E -i %Tables/UserAndRole.sql
sqlcmd -S.\ -E -i %Tables/CreateDetaineeTable.sql
sqlcmd -S.\ -E -i %Tables/CreateWorkerTable.sql



sqlcmd -S.\ -E -i %RelationShip.sql



PAUSE
