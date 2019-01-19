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

        public bool AddUser(User user)
        {
            try
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
            catch
            {
                return false;
            }
            return true;
            
            
        }

        public bool DeleteUser(int Id)
        {
            try
            {
                roleData.DeleteRoleFromUser(Id,1);
                roleData.DeleteRoleFromUser(Id,2);
                roleData.DeleteRoleFromUser(Id,3);
                Executer.ExecuteNonQuery(connectionString, "Delete_User",new SqlParameter("@Id",Id));
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteUserById(int Id)
        {
            try
            {
                Executer.ExecuteNonQuery(connectionString, "Delete_User", new SqlParameter("@Id", Id));
            }
            catch
            {
                return false;
            }
            return true;
            
        }

        public bool EditUserInfo(User user)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id",user.Id),
                    new SqlParameter("@Login",user.Login),
                    new SqlParameter("@Password",user.Password),
                    new SqlParameter("@Email",user.Email),
                };
                Executer.ExecuteNonQuery(connectionString, "UpdateUser", sqlParameters);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<User> GetAllUsers()
        {
            List<User> users;
            try
            {
                users = Executer.ExecuteCollectionRead(connectionString, "SelectAllUsers", new ReadUser());
                foreach (var item in users)
                {
                    item.Roles = roleData.GetUserRolesByUserId(item.Id);
                }
            }
            catch
            {
                return null;
            }
            
            return users;
        }
    }
}
