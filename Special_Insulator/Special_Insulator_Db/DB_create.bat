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

sqlcmd -S.\ -E -i %Procedures/Add/AddDepartment.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddDetainee.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddDetantion.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddInDetantionsAndDeliveryWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddInDetantionsAndDetainWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddInDetantionsAndReleaseWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddInUserAndRole.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddPeople.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddPhone.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddRole.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddUser.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddWorker.sql

sqlcmd -S.\ -E -i %Procedures/Delete/DeleteDepartment.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteDetainee.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteDetantion.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteInDetantionsAndDeliveryWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteInDetantionsAndDetainWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteInDetantionsAndReleaseWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteInUserAndRole.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeletePeople.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeletePhone.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteRole.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteUser.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteWorker.sql

sqlcmd -S.\ -E -i %Procedures/Update/UpdateDepartment.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdateDetainee.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdateDetantion.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdatePeople.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdatePhone.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdateRole.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdateUser.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdateWorker.sql

sqlcmd -S.\ -E -i %Procedures/Select/SelectAllDetainees.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectPersonById.sql




sqlcmd -S.\ -E -i %RelationShip.sql



PAUSE
