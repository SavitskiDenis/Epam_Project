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
    public class WorkerData : IWorkerData
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
        private PersonData personData = new PersonData();
        private PostData postData = new PostData();

        public void AddWorker(Worker worker,Person person)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FirstName", person.FirstName),
                new SqlParameter("@LastName", person.LastName),
                new SqlParameter("@Patronymic", person.Patronymic)
            };
            var id = Executer.ExecuteScalar(connectionString, "AddPeople",parameters);
            Executer.ExecuteNonQuery(connectionString,
                                    "AddWorker",
                                    new SqlParameter("@PeopleId", id),
                                    new SqlParameter("@WorkerPostId", worker.WorkerPost.Id));
        }

        public List<WorkerAndName> GetAllWorkers()
        {
            List<WorkerAndName> fullList = new List<WorkerAndName>();
            List<Worker> workers = Executer.ExecuteCollectionRead(connectionString, "SelectAllWorkers",new ReadWorker());

            foreach (var item in workers)
            {
                item.WorkerPost = postData.GetPostById(item.WorkerPost.Id);
            }

            foreach (var item in workers)
            {
                fullList.Add(new WorkerAndName(item, personData.GetPersonById(item.PeopleId)));
            }


            return fullList;
        }

        public WorkerAndName GetWorkerById(int Id)
        {
            WorkerAndName workerWithName;
            Worker worker = Executer.ExecuteRead(connectionString,
                                                "SelectWorkerById",
                                                new ReadWorker(),
                                                new SqlParameter("@Id", Id));
            worker.WorkerPost = postData.GetPostById(worker.WorkerPost.Id);
            workerWithName = new WorkerAndName(worker, personData.GetPersonById(worker.PeopleId));
            return workerWithName;

        }

        public void DeleteWorkerById(int Id)
        {
            int person_id = Executer.ExecuteRead(connectionString,
                                                "Delete_Worker",
                                                new ReadId(),
                                                new SqlParameter("@Id", Id));
            personData.DeletePersonById(person_id);
        }

        public void EditWorker(WorkerAndName workerAndName)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id",workerAndName.Worker.Id),
                new SqlParameter("@WorkerPostId",workerAndName.Worker.WorkerPost.Id),
                new SqlParameter("@PeopleId",workerAndName.Worker.PeopleId),
            };
            workerAndName.Person.Id = workerAndName.Worker.PeopleId;
            personData.EditPerson(workerAndName.Person);
            Executer.ExecuteNonQuery(connectionString, "UpdateWorker", parameters);
        }

        public int GetWorkerIdByDetentionId(int Id, string procedure)
        {
            return Executer.ExecuteRead(connectionString, procedure,new ReadId(), new SqlParameter("@DetentionId", Id));
        }

    }
}
