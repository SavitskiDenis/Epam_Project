using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class User
    {
        public int Id { get; set; }
        public int  Role_Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string E_mail { get; set; }
        public int People_Id { get; set; }
    }
}
