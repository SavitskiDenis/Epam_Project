using System;

namespace SpecialInsulator.Common.Entity
{
    public class Detention
    {
        public int Id { get; set; }
        public DateTime DetentionDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime LiberationDate { get; set; }
        public WorkerAndName DetainWorker { get; set; }
        public WorkerAndName DeliveryWorker { get; set; }
        public WorkerAndName ReleaseWorker { get; set; }
        public string AccruedAmount { get; set; }
        public string PaidAmount { get; set; }
        public int DetaineeId { get; set; }
        public int DepartmentId { get; set; }
        public string Address { get; set; }

    }
}
