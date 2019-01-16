using System.Collections.Generic;

namespace SpecialInsulator.Common.Entity
{
    public class User
    {
        public int Id { get; set; }
        public List<string>  Roles { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
