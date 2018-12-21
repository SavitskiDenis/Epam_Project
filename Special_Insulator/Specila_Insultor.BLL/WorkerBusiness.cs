using Common.Entity;
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
    }
}
