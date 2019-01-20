using SpecialInsulator.Common.Entity;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using SpecialInsulator.Common.Mapper;

namespace SpecialInsulator.BLL.Implementations
{
    public class WorkerService : IWorkerService
    {
        private IWorkerRepository workerRepository;

        public WorkerService(IWorkerRepository workerData)
        {
            this.workerRepository = workerData;
        }

        public bool AddWorker(Worker worker,Person person)
        {
            if(worker != null && person != null)
            {
                return workerRepository.AddWorker(worker, person);
            }
            return false;
        }

        public List<WorkerAndName> GetAllWorkers()
        {
            return workerRepository.GetAllWorkers();
        }

        public WorkerAndName GetWorkerById(int? Id)
        {
            if(Id != null)
            {
                return workerRepository.GetWorkerById(int.Parse(Id.ToString()));
            }
            return null;
        }

        public bool DeleteWorkerById(int? Id)
        {
            if(Id != null)
            {
                return workerRepository.DeleteWorkerById(int.Parse(Id.ToString()));
            }
            return false;
        }

        public bool EditWorker(WorkerAndName workerAndName)
        {
            if(workerAndName != null)
            {
                return workerRepository.EditWorker(workerAndName);
            }
            return false;
        }

        public List<T> SwapItems<T>(List<WorkerAndName> workers, int Id) where T:class,new ()
        {
            int index = workers.IndexOf(workers.Where(item => item.Worker.Id == Id).FirstOrDefault());
            if(index > 0)
            {
                WorkerAndName worker = workers[index];
                workers[index] = workers[0];
                workers[0] = worker;
            }
            return Mapper.MapCollection<T>(workers);
        }

        public bool IsUsing(int? Id)
        {
            List<int> ids = workerRepository.GetUsingIds("Detain");
            if(ExistId(Id,ids))
            {
                return true;
            }

            ids = workerRepository.GetUsingIds("Delivery");
            if (ExistId(Id, ids))
            {
                return true;
            }

            ids = workerRepository.GetUsingIds("Release");
            if (ExistId(Id, ids))
            {
                return true;
            }
            return false;
        }

        private bool ExistId(int? Id,List<int> collection)
        {
            if(Id != null && collection != null)
            {
                int id = int.Parse(Id.ToString());

                foreach(var item in collection)
                {
                    if(item == id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
