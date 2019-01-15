using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specila_Insultor.BLL.Interfaces
{
    public interface IUserBusiness
    {
        bool checkUser(User user);

        List<User> GetAllUsers();

        bool AddUser(User user);

        bool AddCookies(User user);

        User checkUserAndGet(User user);

        void DeleteCookies();

        void EditRoles(int Id, string type);
    }
}
