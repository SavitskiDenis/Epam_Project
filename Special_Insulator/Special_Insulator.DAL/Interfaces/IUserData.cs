using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL.Interfaces
{
    public interface IUserData
    {
        void AddUser(User user );

        List<User> GetAllUsers();

        void DeleteUserById(int Id);
    }
}
