using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.BLL.Interfaces
{
    public interface IWorkerService
    {
        bool AddWorker(Worker worker,Person person);

        List<WorkerAndName> GetAllWorkers();

        WorkerAndName GetWorkerById(int? Id);

        bool DeleteWorkerById(int? Id);

        bool EditWorker(WorkerAndName workerAndName);

        List<T> SwapItems<T>(List<WorkerAndName> workers, int Id) where T : class, new();


    }
}
