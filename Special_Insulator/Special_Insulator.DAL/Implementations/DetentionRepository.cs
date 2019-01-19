using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Reader;
using SpecialInsulator.Common.SQLExecuter;
using SpecialInsulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace SpecialInsulator.DAL.Implementations
{
    class DetentionRepository : IDetentionRepository
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
        private WorkerRepository worker = new WorkerRepository();
        private DetentionPlaceRepository placeData = new DetentionPlaceRepository();

        public List<Detention> GetDetentionsByDetaineeId(int id)
        {
            List<Detention> detentions;
            try
            {
                detentions = Executer.ExecuteCollectionRead(connectionString,
                                                            "SelectDetentionsByDetaineeId",
                                                            new ReadDetention(),
                                                            new SqlParameter("@DetaineeId", id));
                foreach (var item in detentions)
                {
                    item.DetainWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(item.Id, "SelectDetainWorkerId"));

                    item.DeliveryWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(item.Id, "SelectDeliveryWorkerId"));

                    item.ReleaseWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(item.Id, "SelectReleaseWorkerId"));
                }
            }
            catch
            {
                return null;
            }
            
            return detentions;
        }

        public bool AddDetention(Detention detention)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@DetaineeId",detention.DetaineeId),
                    new SqlParameter("@DetentionDate",detention.DetentionDate),
                    new SqlParameter("@DeliveryDate",detention.DeliveryDate),
                    new SqlParameter("@LiberationDate",detention.LiberationDate),
                    new SqlParameter("@DetentionPlaceId",detention.DetentionPlace.Id),
                    new SqlParameter("@AccruedAmount",detention.AccruedAmount),
                    new SqlParameter("@PaidAmount",detention.PaidAmount),
                };
                var id = Executer.ExecuteScalar(connectionString, "AddDetention", parameters);

                Executer.ExecuteNonQuery(connectionString,
                                        "AddInDetentionsAndDeliveryWorkers",
                                        new SqlParameter("@DetentionId", id),
                                        new SqlParameter("@WorkerId", detention.DeliveryWorker.Worker.Id));

                Executer.ExecuteNonQuery(connectionString,
                                        "AddInDetentionsAndDetainWorkers",
                                        new SqlParameter("@DetentionId", id),
                                        new SqlParameter("@WorkerId", detention.DetainWorker.Worker.Id));

                Executer.ExecuteNonQuery(connectionString,
                                        "AddInDetentionsAndReleaseWorkers",
                                        new SqlParameter("@DetentionId", id),
                                        new SqlParameter("@WorkerId", detention.ReleaseWorker.Worker.Id));
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool DeleteDetention(int Id)
        {
            try
            {
                Executer.ExecuteNonQuery(connectionString, "Delete_DetDel", new SqlParameter("@Id", Id));

                Executer.ExecuteNonQuery(connectionString, "Delete_DD", new SqlParameter("@Id", Id));

                Executer.ExecuteNonQuery(connectionString, "Delete_DR", new SqlParameter("@Id", Id));

                Executer.ExecuteNonQuery(connectionString, "Delete_Detention", new SqlParameter("@Id", Id));
            }
            catch
            {
                return false;
            }
            return true;
            

        }

        public Detention GetDetentionById(int Id)
        {
            Detention detention;
            try
            {
                detention = Executer.ExecuteRead(connectionString,
                                            "SelectDetentionById",
                                            new ReadDetention(),
                                            new SqlParameter("@Id", Id));

                detention.Id = Id;

                detention.DetainWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(detention.Id,
                                                                                                "SelectDetainWorkerId"));

                detention.DeliveryWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(detention.Id,
                                                                                                "SelectDeliveryWorkerId"));

                detention.ReleaseWorker = worker.GetWorkerById(worker.GetWorkerIdByDetentionId(detention.Id,
                                                                                                "SelectReleaseWorkerId"));
            }
            catch
            {
                return null;
            }
            

            return detention;
        }

        public bool EditDetention(Detention detention)
        {
           
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Id",detention.Id),
                    new SqlParameter("@DetentionDate",detention.DetentionDate),
                    new SqlParameter("@DeliveryDate",detention.DeliveryDate),
                    new SqlParameter("@LiberationDate",detention.LiberationDate),
                    new SqlParameter("@DetentionPlaceId",detention.DetentionPlace.Id),
                    new SqlParameter("@AccruedAmount",detention.AccruedAmount),
                    new SqlParameter("@PaidAmount",detention.PaidAmount),
                };
                Executer.ExecuteNonQuery(connectionString, "UpdateDetention", parameters);

                Executer.ExecuteNonQuery(connectionString,
                                        "UpdateInDetensionsAndDetainWorkers",
                                        new SqlParameter("@DetentionId", detention.Id),
                                        new SqlParameter("@WorkerId",
                                        detention.DetainWorker.Worker.Id));

                Executer.ExecuteNonQuery(connectionString,
                                        "UpdateInDetentionsAndDeliveryWorkers",
                                        new SqlParameter("@DetentionId", detention.Id),
                                        new SqlParameter("@WorkerId",
                                        detention.DeliveryWorker.Worker.Id));

                Executer.ExecuteNonQuery(connectionString,
                                        "UpdateInDetentionsAndReleaseWorkers",
                                        new SqlParameter("@DetentionId", detention.Id),
                                        new SqlParameter("@WorkerId", detention.ReleaseWorker.Worker.Id));
            }
            catch
            {
                return false;
            }
            return true;

        }

        public bool DeleteDetentionByDetaineeId(int Id)
        {
            try
            {
                List<int> idList = GetDetentionsIdByDetaineeId(Id);
                foreach (var item in idList)
                {
                    DeleteDetention(item);
                }
                Executer.ExecuteNonQuery(connectionString, "DeleteDetentionByDetaineeId", new SqlParameter("@Id", Id));
            }
            catch
            {
                return false;
            }
            return true;
            
        }

        public List<int> GetDetentionsIdByDetaineeId(int Id)
        {
            List<int> ids;
            try
            {
                ids =  Executer.ExecuteCollectionRead(connectionString,
                                                "SelectDetentionsIdByDetaineeId",
                                                new ReadId(),
                                                new SqlParameter("@Id", Id));
            }
            catch
            {
                return null;
            }
            return ids;
            
        }

        public DateTime GetLastDetentionDateByDetaineeId (int Id)
        {
            DateTime lastDate;
            try
            {
                lastDate = Executer.ExecuteRead(connectionString,
                                        "SelectLastDetentionDateByDetaineeId",
                                        new ReadLastDate(),
                                        new SqlParameter("@Id", Id));
            }
            catch
            {
                return default(DateTime);
            }
            return lastDate;


        }
    }
}
