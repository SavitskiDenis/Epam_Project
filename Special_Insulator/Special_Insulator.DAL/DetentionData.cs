using Common.Entity;
using Common.Reader;
using Common.SQLExecuter;
using Special_Insulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Special_Insulator.DAL
{
    class DetentionData : IDetentionData
    {
        public string connectionString = /*WebConfigurationManager.ConnectionStrings["MyDataBase"].ConnectionString*/@"Data Source=.\;Initial Catalog=SIDb;Integrated Security=True";
        public WorkerData worker = new WorkerData();
        public DepartmentData department = new DepartmentData();

        public List<Detention> GetDetentionsByDetaineeId(int id)
        {

            List<Detention> detentions = Executer.ExecuteCollectionRead(connectionString, "SelectDetentionsByDetaineeId", new ReadDetention(), new SqlParameter("@DetaineeId", id));
            foreach (var item in detentions)
            {
                item.DetainWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(item.Id, "SelectDetainWorkerId"));
                item.DeliveryWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(item.Id, "SelectDeliveryWorkerId"));
                item.ReleaseWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(item.Id, "SelectReleaseWorkerId"));
                Department mydepartment = department.GetDepartmnetnById(item.DepartmentId);
                item.DepartmentId = mydepartment.Id;
                item.Address = mydepartment.Address;
            }


            return detentions;
        }

        public void AddDetention(Detention detention)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DetaineeId",detention.DetaineeId),
                new SqlParameter("@DetentionDate",detention.DetentionDate),
                new SqlParameter("@DeliveryDate",detention.DeliveryDate),
                new SqlParameter("@LiberationDate",detention.LiberationDate),
                new SqlParameter("@DepartmentId",detention.DepartmentId),
                new SqlParameter("@AccruedAmount",detention.AccruedAmount),
                new SqlParameter("@PaidAmount",detention.PaidAmount),
            };
            var id = Executer.ExecuteScalar(connectionString, "AddDetention", parameters);
            Executer.ExecuteNonQuery(connectionString, "AddInDetentionsAndDeliveryWorkers", new SqlParameter("@DetentionId", id), new SqlParameter("@WorkerId", detention.DeliveryWorker.Worker.Id));
            Executer.ExecuteNonQuery(connectionString, "AddInDetentionsAndDetainWorkers", new SqlParameter("@DetentionId", id), new SqlParameter("@WorkerId", detention.DetainWorker.Worker.Id));
            Executer.ExecuteNonQuery(connectionString, "AddInDetentionsAndReleaseWorkers", new SqlParameter("@DetentionId", id), new SqlParameter("@WorkerId", detention.ReleaseWorker.Worker.Id));
        }

        public void DeleteDetention(int Id)
        {
            Executer.ExecuteNonQuery(connectionString, "Delete_DetDel", new SqlParameter("@Id", Id));
            Executer.ExecuteNonQuery(connectionString, "Delete_DD", new SqlParameter("@Id", Id));
            Executer.ExecuteNonQuery(connectionString, "Delete_DR", new SqlParameter("@Id", Id));
            Executer.ExecuteNonQuery(connectionString, "Delete_Detention", new SqlParameter("@Id", Id));
        }

        public Detention GetDetentionById(int Id)
        {
            Detention detention = Executer.ExecuteRead(connectionString, "SelectDetentionById",new ReadDetention(), new SqlParameter("@Id", Id));

            detention.Id = Id;
            detention.DetainWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(detention.Id, "SelectDetainWorkerId"));
            detention.DeliveryWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(detention.Id, "SelectDeliveryWorkerId"));
            detention.ReleaseWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(detention.Id, "SelectReleaseWorkerId"));
            Department mydepartment = department.GetDepartmnetnById(detention.DepartmentId);
            detention.DepartmentId = mydepartment.Id;
            detention.Address = mydepartment.Address;

            return detention;
        }

        public void EditDetention(Detention detention)
        {
           
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",detention.Id),
                new SqlParameter("@DetentionDate",detention.DetentionDate),
                new SqlParameter("@DeliveryDate",detention.DeliveryDate),
                new SqlParameter("@LiberationDate",detention.LiberationDate),
                new SqlParameter("@DepartmentId",detention.DepartmentId),
                new SqlParameter("@AccruedAmount",detention.AccruedAmount),
                new SqlParameter("@PaidAmount",detention.PaidAmount),
            };
            Executer.ExecuteNonQuery(connectionString, "UpdateDetention", parameters);
            Executer.ExecuteNonQuery(connectionString, "UpdateInDetensionsAndDetainWorkers", new SqlParameter("@DetentionId", detention.Id), new SqlParameter("@WorkerId", detention.DetainWorker.Worker.Id));
            Executer.ExecuteNonQuery(connectionString, "AddInDetentionsAndDetainWorkers", new SqlParameter("@DetentionId", detention.Id), new SqlParameter("@WorkerId", detention.DeliveryWorker.Worker.Id));
            Executer.ExecuteNonQuery(connectionString, "AddInDetentionsAndReleaseWorkers", new SqlParameter("@DetentionId", detention.Id), new SqlParameter("@WorkerId", detention.ReleaseWorker.Worker.Id));

        }

        public void DeleteDetentionByDetaineeId(int Id)
        {
            List<int> idList = GetDetentionsIdByDetaineeId(Id);
            foreach(var item in idList)
            {
                DeleteDetention(item);
            }
            Executer.ExecuteNonQuery(connectionString, "DeleteDetentionByDetaineeId",new SqlParameter("@Id",Id));
        }

        public List<int> GetDetentionsIdByDetaineeId(int Id)
        {
            return Executer.ExecuteCollectionRead(connectionString, "SelectDetentionsIdByDetaineeId",new ReadId(),new SqlParameter("@Id",Id));
        }
    }
}
