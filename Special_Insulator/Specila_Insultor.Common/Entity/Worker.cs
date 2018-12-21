using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class Worker
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public string WorkerPost { get; set; }
        public int? UserId { get; set; }
    }
}
