using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL.Interfaces
{
    public interface IPersonData
    {
        Person GetPersonById(int id);
        string GetPhoneByDetaineeId(int id);
    }
}
