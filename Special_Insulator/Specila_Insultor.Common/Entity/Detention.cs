using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class Detention
    {
        public int Id { get; set; }
        public DateTime DetentionDate { get; set; }
        public DateTime LiberationDate { get; set; }
        public Worker DetainWorker { get; set; }
        public Worker ReleaseWorker { get; set; }
        public decimal AccruedAmount { get; set; }
        public decimal PaidAmount  { get; set; }
        public int DetaineeId { get; set; }

    }
}
