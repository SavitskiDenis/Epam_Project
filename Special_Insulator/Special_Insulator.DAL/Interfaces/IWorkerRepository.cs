using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IWorkerRepository
    {
        bool AddWorker(Worker worker,Person person);

        List<WorkerAndName> GetAllWorkers();

        WorkerAndName GetWorkerById(int Id);

        bool DeleteWorkerById(int Id);

        bool EditWorker(WorkerAndName workerAndName);

        int GetWorkerIdByDetentionId(int Id, string procedure);

        List<int> GetUsingIds(string type);
    }
}
