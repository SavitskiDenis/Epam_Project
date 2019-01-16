namespace SpecialInsulator.Common.Entity
{
    public class Worker
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public Post WorkerPost { get; set; }
        public int? UserId { get; set; }
    }
}
