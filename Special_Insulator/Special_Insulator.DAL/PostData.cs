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
    public class PostData : IPostData
    {
        public string connectionString = WebConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;

        public void AddPost(Post post)
        {
            Executer.ExecuteNonQuery(connectionString, "AddPost",new SqlParameter("@Post",post.PostName));
        }

        public void DeletePostById(int Id)
        {
            Executer.ExecuteNonQuery(connectionString, "DeletePost", new SqlParameter("@Id", Id));
        }

        public void EditPost(Post post)
        {
            Executer.ExecuteNonQuery(connectionString,
                                    "UpdatePost",
                                    new SqlParameter("@Id",post.Id),
                                    new SqlParameter("@Post",post.PostName));
        }

        public List<Post> GetAllPosts()
        {
            return Executer.ExecuteCollectionRead(connectionString, "SelectAllPosts",new ReadPost());
        }

        public Post GetPostById(int Id)
        {
            return Executer.ExecuteRead(connectionString, "SelectPostById", new ReadPost(),new SqlParameter("@Id",Id));
        }
    }
}
