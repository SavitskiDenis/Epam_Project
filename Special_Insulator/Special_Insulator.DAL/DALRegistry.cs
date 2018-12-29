using Special_Insulator.DAL.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL
{
    public class DALRegistry : Registry
    {
        public DALRegistry()
        {
            For<IDetaineeData>().Singleton().Use<DetaineeData>();
            For<IPersonData>().Singleton().Use<PersonData>();
            For<IDetentionData>().Singleton().Use<DetentionData>();
            For<IWorkerData>().Singleton().Use<WorkerData>();
            For<IDepartmentData>().Singleton().Use<DepartmentData>();
        }
    }
}
