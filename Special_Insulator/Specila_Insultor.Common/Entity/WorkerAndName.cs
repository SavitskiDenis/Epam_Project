using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class WorkerAndName
    {
        public WorkerAndName(Worker worker, Person person)
        {
            Worker = worker;
            Person = person;
        }

        public Worker Worker { get; set; }

        public Person Person { get; set; }
    }
}
