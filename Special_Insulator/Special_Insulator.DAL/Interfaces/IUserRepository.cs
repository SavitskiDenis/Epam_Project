using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IUserRepository
    {
        bool AddUser(User user );

        List<User> GetAllUsers();

        //bool DeleteUserById(int Id);

        bool EditUserInfo(User user);

        bool DeleteUser(int Id);
    }
}
