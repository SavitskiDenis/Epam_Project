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
        IWorkerRepository workerData;

        public WorkerService(IWorkerRepository workerData)
        {
            this.workerData = workerData;
        }

        public bool AddWorker(Worker worker,Person person)
        {
            if(worker != null && person != null)
            {
                return workerData.AddWorker(worker, person);
            }
            return false;
        }

        public List<WorkerAndName> GetAllWorkers()
        {
            return workerData.GetAllWorkers();
        }

        public WorkerAndName GetWorkerById(int? Id)
        {
            if(Id != null)
            {
                return workerData.GetWorkerById(int.Parse(Id.ToString()));
            }
            return null;
        }

        public bool DeleteWorkerById(int? Id)
        {
            if(Id != null)
            {
                return workerData.DeleteWorkerById(int.Parse(Id.ToString()));
            }
            return false;
        }

        public bool EditWorker(WorkerAndName workerAndName)
        {
            if(workerAndName != null)
            {
                return workerData.EditWorker(workerAndName);
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
    }
}
