using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Reader;
using SpecialInsulator.Common.SQLExecuter;
using SpecialInsulator.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace SpecialInsulator.DAL.Implementations
{
    public class WorkerRepository : IWorkerRepository
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
        private IPersonRepository personRepository = new PersonRepository();
        private IPostRepository postRepository = new PostRepository();

        public bool AddWorker(Worker worker,Person person)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FirstName", person.FirstName),
                    new SqlParameter("@LastName", person.LastName),
                    new SqlParameter("@Patronymic", person.Patronymic)
                };
                var id = Executer.ExecuteScalar(connectionString, "AddPeople", parameters);
                Executer.ExecuteNonQuery(connectionString,
                                        "AddWorker",
                                        new SqlParameter("@PeopleId", id),
                                        new SqlParameter("@WorkerPostId", worker.WorkerPost.Id));
            }
            catch
            {
                return false;
            }
            return true;
            
        }

        public List<WorkerAndName> GetAllWorkers()
        {
            List<WorkerAndName> fullList = new List<WorkerAndName>();
            try
            {
                List<Worker> workers = Executer.ExecuteCollectionRead(connectionString, "SelectAllWorkers", new ReadWorker());

                foreach (var item in workers)
                {
                    item.WorkerPost = postRepository.GetPostById(item.WorkerPost.Id);
                }

                foreach (var item in workers)
                {
                    fullList.Add(new WorkerAndName(item, personRepository.GetPersonById(item.PeopleId)));
                }
            }
            catch
            {
                return null;
            }
            
            return fullList;
        }

        public WorkerAndName GetWorkerById(int Id)
        {
            WorkerAndName workerWithName;
            try
            {
                Worker worker = Executer.ExecuteRead(connectionString,
                                                "SelectWorkerById",
                                                new ReadWorker(),
                                                new SqlParameter("@Id", Id));
                worker.WorkerPost = postRepository.GetPostById(worker.WorkerPost.Id);
                workerWithName = new WorkerAndName(worker, personRepository.GetPersonById(worker.PeopleId));
            }
            catch
            {
                return null;
            }
            
            return workerWithName;

        }

        public bool DeleteWorkerById(int Id)
        {
            int personId;
            try
            {
                personId = Executer.ExecuteRead(connectionString,
                                           "Delete_Worker",
                                           new ReadId(),
                                           new SqlParameter("@Id", Id));
                personRepository.DeletePersonById(personId);
            }
            catch
            {
                return false;
            }
            return true;
           
        }

        public bool EditWorker(WorkerAndName workerAndName)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Id",workerAndName.Worker.Id),
                    new SqlParameter("@WorkerPostId",workerAndName.Worker.WorkerPost.Id),
                    new SqlParameter("@PeopleId",workerAndName.Worker.PeopleId),
                };
                workerAndName.Person.Id = workerAndName.Worker.PeopleId;
                personRepository.EditPerson(workerAndName.Person);
                Executer.ExecuteNonQuery(connectionString, "UpdateWorker", parameters);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public int GetWorkerIdByDetentionId(int Id, string procedure)
        {
            int id;
            try
            {
                id =  Executer.ExecuteRead(connectionString, procedure, new ReadId(), new SqlParameter("@DetentionId", Id));
            }
            catch
            {
                return 0;
            }
            return id;
        }

        public List<int> GetUsingIds(string type)
        {
            List<int> ids;
            try
            {
                if(type == "Detain")
                {
                    ids = Executer.ExecuteCollectionRead(connectionString,
                                                        "SelectAllWorkerIdsFromDetainWorkers",
                                                        new ReadId());
                }
                else if(type == "Delivery")
                {
                    ids = Executer.ExecuteCollectionRead(connectionString,
                                                        "SelectAllWorkerIdsFromDeliveryWorkers", 
                                                        new ReadId());
                }
                else if(type == "Release")
                {
                    ids = Executer.ExecuteCollectionRead(connectionString,
                                                        "SelectAllWorkerIdsFromReleaseWorkers",
                                                        new ReadId());
                }
                else
                {
                    ids = new List<int>();
                }
            }
            catch
            {
                return null;
            }
            return ids;
        }
    }
}
