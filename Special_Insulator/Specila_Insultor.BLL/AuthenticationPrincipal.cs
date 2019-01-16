using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Specila_Insultor.BLL
{
    public class AuthenticationPrincipal : IPrincipal
    {
        public AuthenticationPrincipal(int id, List<string> roles, string login, string email)
        {
            Id = id;
            Roles = roles;
            Login = login;
            Email = email;
            Identity = new GenericIdentity(login);
        }

        public int Id { get;}
        public List<string> Roles { get; }
        public string Login { get; }
        public string Email { get;}
        public IIdentity Identity { get;}

        public bool IsInRole(string role)
        {
            if(Roles.Where(item => item == role).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
    }
}
