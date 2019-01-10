using Common.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Reader
{
    public class ReadWorker : IReader<Worker>
    {
        public List<Worker> GetCollection(SqlDataReader dataReader)
        {
            List<Worker> workers = new List<Worker>();
            Worker worker;
            try
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        worker = new Worker()
                        {
                            Id = (int)dataReader.GetValue(0),
                            WorkerPost = (string)dataReader.GetValue(1),
                            PeopleId = (int)dataReader.GetValue(2),
                        };
                        workers.Add(worker);
                    }
                }
            }
            catch { }

            return workers;
        }

        public Worker GetModel(SqlDataReader dataReader)
        {
            Worker worker = null;
            try
            {
                dataReader.Read();
                worker = new Worker()
                {
                    Id = dataReader.GetInt32(0),
                    WorkerPost = dataReader.GetString(1),
                    PeopleId = dataReader.GetInt32(2),
                };
            }
            catch { }

            return worker;
        }
    }
}
