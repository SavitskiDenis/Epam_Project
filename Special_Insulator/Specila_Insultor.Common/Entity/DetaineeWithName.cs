using System;

namespace SpecialInsulator.Common.Entity
{
    public class DetaineeWithName:IComparable
    {
        public Detainee detainee  { get; set; }
        public Person person { get; set; }
        public DateTime lastDetention { get; set; }

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

        public int CompareTo(object obj)
        {
            DetaineeWithName detainee = (DetaineeWithName)obj;
            if(person.LastName.CompareTo(detainee.person.LastName) == 1)
            {
                return 1;
            }
            else if(person.LastName.CompareTo(detainee.person.LastName) == -1)
            {
                return -1;
            }
            else
            {
                return person.FirstName.CompareTo(detainee.person.FirstName);
            }
        }
    }
}
