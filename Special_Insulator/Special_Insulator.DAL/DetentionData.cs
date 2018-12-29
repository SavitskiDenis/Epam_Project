using Common.Entity;
using Special_Insulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL
{
    class DetentionData : IDetentionData
    {
        public string connectionString = @"Data Source=.\;Initial Catalog=SIDb;Integrated Security=True";
        public WorkerData worker = new WorkerData();
        public DepartmentData department = new DepartmentData();

        public List<Detention> GetDetentionsByDetaineeId(int id)
        {
            List<Detention> detentions = new List<Detention>();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand getDetentions = new SqlCommand("SelectDetentionsByDetaineeId", connection);
                getDetentions.CommandType = System.Data.CommandType.StoredProcedure;
                getDetentions.Parameters.Add(new SqlParameter("@DetaineeId", id));

                SqlDataReader DReader = getDetentions.ExecuteReader();
                Detention detention;


                if (DReader.HasRows)
                {
                    while (DReader.Read())
                    {
                        detention = new Detention()
                        {
                            Id = (int)DReader.GetValue(0),
                            DetaineeId = (int)DReader.GetValue(1),
                            DetentionDate = (DateTime)DReader.GetValue(2),
                            DeliveryDate = (DateTime)DReader.GetValue(3),
                            LiberationDate = (DateTime)DReader.GetValue(4),
                            DepartmentId = (int)DReader.GetValue(5),
                            AccruedAmount = (decimal)DReader.GetValue(6),
                            PaidAmount = (decimal)DReader.GetValue(7),

                        };
                        detention.DetainWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(detention.Id, "SelectDetainWorkerId"));
                        detention.DeliveryWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(detention.Id, "SelectDeliveryWorkerId"));
                        detention.ReleaseWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(detention.Id, "SelectReleaseWorkerId"));
                        Department mydepartment = department.GetDepartmnetnById(detention.DepartmentId);
                        detention.DepartmentId = mydepartment.Id;
                        detention.Address = mydepartment.Address;


                        detentions.Add(detention);
                    }
                }
                DReader.Close();
            }


            return detentions;
        }

        public void AddDetention(Detention detention)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand addDetention = new SqlCommand("AddDetention", connection);
                addDetention.CommandType = System.Data.CommandType.StoredProcedure;

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
                addDetention.Parameters.AddRange(parameters);
                var id = addDetention.ExecuteScalar();

                SqlCommand addDeliveryWorker = new SqlCommand("AddInDetentionsAndDeliveryWorkers", connection);
                addDeliveryWorker.CommandType = System.Data.CommandType.StoredProcedure;
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@DetentionId",id),
                    new SqlParameter("@WorkerId",detention.DeliveryWorker.Worker.Id),
                };
                addDeliveryWorker.Parameters.AddRange(parameters);
                addDeliveryWorker.ExecuteNonQuery();

                SqlCommand addDetainWorker = new SqlCommand("AddInDetentionsAndDetainWorkers", connection);
                addDetainWorker.CommandType = System.Data.CommandType.StoredProcedure;
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@DetentionId",id),
                    new SqlParameter("@WorkerId",detention.DetainWorker.Worker.Id),
                };
                addDetainWorker.Parameters.AddRange(parameters);
                addDetainWorker.ExecuteNonQuery();

                SqlCommand addReleaseWorker = new SqlCommand("AddInDetentionsAndReleaseWorkers", connection);
                addReleaseWorker.CommandType = System.Data.CommandType.StoredProcedure;
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@DetentionId",id),
                    new SqlParameter("@WorkerId",detention.ReleaseWorker.Worker.Id),
                };
                addReleaseWorker.Parameters.AddRange(parameters);
                addReleaseWorker.ExecuteNonQuery();
            }
        }

        
    }
}
