using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Reader;
using SpecialInsulator.Common.SQLExecuter;
using SpecialInsulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace SpecialInsulator.DAL.Implementations
{
    class UserRepository : IUserRepository
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
        private RoleRepository roleData = new RoleRepository();

        public void AddUser(User user)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Login",user.Login),
                new SqlParameter("@Password",user.Password),
                new SqlParameter("@Email",user.Email),
            };
            int id = int.Parse(Executer.ExecuteScalar(connectionString, "AddUser", parameters).ToString());
            if (id != 0)
            {
                roleData.AddRoleToUser(id, 1);
            }
            else
            {
                throw new Exception();
            }
            
        }

        public void DeleteUserById(int Id)
        {
            Executer.ExecuteNonQuery(connectionString, "Delete_User",new SqlParameter("@Id",Id));
        }

        public List<User> GetAllUsers()
        {
            List<User> users = Executer.ExecuteCollectionRead(connectionString, "SelectAllUsers",new ReadUser());
            foreach(var item in users)
            {
                item.Roles = roleData.GetUserRolesByUserId(item.Id);
            }
            return users;
        }
    }
}
