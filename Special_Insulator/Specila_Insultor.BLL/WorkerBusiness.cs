using Common.Entity;
using Common.Mapper;
using Special_Insulator.DAL.Interfaces;
using Specila_Insultor.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specila_Insultor.BLL
{
    public class WorkerBusiness : IWorkerBusiness
    {
        IWorkerData workerData;

        public WorkerBusiness(IWorkerData workerData)
        {
            this.workerData = workerData;
        }

        public void AddWorker(Worker worker,Person person)
        {
            workerData.AddWorker(worker,person);
        }

        public List<WorkerAndName> GetAllWorkers()
        {
            return workerData.GetAllWorkers();
        }

        public WorkerAndName GetWorkerById(int Id)
        {
            return workerData.GetWorkerById(Id);
        }

        public void DeleteWorkerById(int Id)
        {
            workerData.DeleteWorkerById(Id);
        }

        public void EditWorker(WorkerAndName workerAndName)
        {
            workerData.EditWorker(workerAndName);
        }

        public List<WorkerAndName> SwapItems(List<WorkerAndName> workers, int Id)
        {
            int index = workers.IndexOf(workers.Where(item => item.Worker.Id == Id).FirstOrDefault());
            if(index > 0)
            {
                WorkerAndName worker = workers[index];
                workers[index] = workers[0];
                workers[0] = worker;
            }
            
            return workers;
        }
    }
}
