using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.BLL.Interfaces
{
    public interface IWorkerService
    {
        void AddWorker(Worker worker,Person person);

        List<WorkerAndName> GetAllWorkers();

        WorkerAndName GetWorkerById(int Id);

        void DeleteWorkerById(int Id);

        void EditWorker(WorkerAndName workerAndName);

        List<WorkerAndName> SwapItems(List<WorkerAndName> workers,int Id);


    }
}
