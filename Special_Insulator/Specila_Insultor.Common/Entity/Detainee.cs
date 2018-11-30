using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    enum Marital_status
    {
        Married,
        Single,
        Divorced
    }

    class Detainee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BornDate { get; set; }
        public Marital_status Status { get; set; }
        public string Workplace { get; set; }
        public string Phone { get; set; }
        public Url Photo { get; set; }
        public string Address { get; set; }
        public string Additional_information { get; set; }
        public ICollection<Detention> Detentions { get; set; }

    }
}
