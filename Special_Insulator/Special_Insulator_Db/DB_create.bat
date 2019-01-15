sqlcmd -S.\ -E -i %DBCreate.sql
sqlcmd -S.\ -E -i %Tables/CreateRoleTable.sql
sqlcmd -S.\ -E -i %Tables/CreateUserTable.sql
sqlcmd -S.\ -E -i %Tables/UserAndRole.sql
sqlcmd -S.\ -E -i %Tables/CreateDetentionTable.sql
sqlcmd -S.\ -E -i %Tables/CreateWorkerTable.sql
sqlcmd -S.\ -E -i %Tables/CreateDepartmentTable.sql
sqlcmd -S.\ -E -i %Tables/CreateDetaineeTable.sql
sqlcmd -S.\ -E -i %Tables/CreatePeopleTable.sql
sqlcmd -S.\ -E -i %Tables/CreatePhoneTable.sql
sqlcmd -S.\ -E -i %Tables/DetensionsAndDetainWorkers.sql
sqlcmd -S.\ -E -i %Tables/DetentionsAndDeliveryWorkers.sql
sqlcmd -S.\ -E -i %Tables/DetentionsAndReleaseWorkers.sql
sqlcmd -S.\ -E -i %Tables/CreatePostsTable.sql

sqlcmd -S.\ -E -i %Procedures/Add/AddDepartment.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddDetainee.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddDetention.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddInDetentionsAndDeliveryWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddInDetentionsAndDetainWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddInDetentionsAndReleaseWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddInUserAndRole.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddPeople.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddPhone.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddRole.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddUser.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddWorker.sql
sqlcmd -S.\ -E -i %Procedures/Add/AddPost.sql

sqlcmd -S.\ -E -i %Procedures/Delete/DeleteDepartment.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteDetainee.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteDetention.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteInDetentionsAndDeliveryWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteInDetentionsAndDetainWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteInDetentionsAndReleaseWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteInUserAndRole.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeletePeople.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeletePhone.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteRole.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteUser.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteWorker.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeleteDetentionByDetaineeId.sql
sqlcmd -S.\ -E -i %Procedures/Delete/DeletePost.sql

sqlcmd -S.\ -E -i %Procedures/Update/UpdateDepartment.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdateDetainee.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdateDetention.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdatePeople.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdatePhone.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdateRole.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdateUser.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdateWorker.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdateInDetensionsAndDetainWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdateInDetentionsAndDeliveryWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdateInDetentionsAndReleaseWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Update/UpdatePost.sql

sqlcmd -S.\ -E -i %Procedures/Select/SelectAllDetainees.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectPersonById.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectPhoneByDetaineeId.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectAllPeople.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectDetaineeById.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectDetentionsByDetaineeId.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectAllDepartments.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectAllWorkers.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectDepartmentById.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectWorkerById.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectDeliveryWorkerId.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectDetainWorkerId.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectReleaseWorkerId.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectDetentionById.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectDetentionsIdByDetaineeId.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectLastDetentionDateByDetaineeId.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectAllUsers.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectRoleById.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectRolesIdByUserId.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectAllPosts.sql
sqlcmd -S.\ -E -i %Procedures/Select/SelectPostById.sql




sqlcmd -S.\ -E -i %RelationShip.sql



PAUSE
