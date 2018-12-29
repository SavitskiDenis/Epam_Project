using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL.Interfaces
{
    public interface IWorkerData
    {
        void AddWorker(Worker worker,Person person);

        List<WorkerAndName> GetAllWorkers();

        WorkerAndName GetWorkerById(int Id);

        void DeleteWorkerById(int Id);

        void EditWorker(WorkerAndName workerAndName);
    }
}
