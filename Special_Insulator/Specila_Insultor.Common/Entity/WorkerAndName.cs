namespace SpecialInsulator.Common.Entity
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
