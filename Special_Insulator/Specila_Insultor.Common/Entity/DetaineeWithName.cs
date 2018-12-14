using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class DetaineeWithName
    {
        public Detainee detainee  { get; set; }
        public Person person { get; set; }

        public DetaineeWithName()
        {
            detainee = new Detainee();
            person = new Person();
        }

        public DetaineeWithName(Detainee detainee, Person person)
        {
            this.detainee = detainee;
            this.person = person;
        }
    }
}
