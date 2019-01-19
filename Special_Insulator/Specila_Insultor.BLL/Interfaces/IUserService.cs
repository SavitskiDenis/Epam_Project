using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.BLL.Interfaces
{
    public interface IUserService
    {
        bool checkUser(User user);

        List<User> GetAllUsers();

        bool AddUser(User user);

        bool AddCookies(User user);

        User checkUserAndGet(User user);

        void DeleteCookies();

        void EditRoles(int Id, string type);

        User GetUserByLoginAndEmail(string login,string email);

        bool EditUserInfo(User user);

        bool DeleteUser(int? Id);
    }
}
