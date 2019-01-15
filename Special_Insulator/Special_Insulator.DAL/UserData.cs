using Common.Entity;
using Common.Reader;
using Common.SQLExecuter;
using Special_Insulator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Special_Insulator.DAL
{
    class UserData : IUserData
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
        private RoleData roleData = new RoleData();

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
