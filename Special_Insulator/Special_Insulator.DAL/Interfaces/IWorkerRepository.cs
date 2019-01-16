using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IWorkerRepository
    {
        void AddWorker(Worker worker,Person person);

        List<WorkerAndName> GetAllWorkers();

        WorkerAndName GetWorkerById(int Id);

        void DeleteWorkerById(int Id);

        void EditWorker(WorkerAndName workerAndName);
    }
}
