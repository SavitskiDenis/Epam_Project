﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{

    public class Detainee
    {
        public int Id { get; set; }
        public int PeopleId { get; set; }
        public DateTime BornDate { get; set; }
        public string Status { get; set; }
        public string Workplace { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public string AdditionalInformation { get; set; }
        public List<Detention> Detentions { get; set; }
    }
}
