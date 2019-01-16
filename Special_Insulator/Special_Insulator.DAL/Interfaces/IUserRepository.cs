using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user );

        List<User> GetAllUsers();

        void DeleteUserById(int Id);
    }
}
