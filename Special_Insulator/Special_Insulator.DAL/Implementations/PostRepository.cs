using SpecialInsulator.Common.Entity;
using SpecialInsulator.Common.Reader;
using SpecialInsulator.Common.SQLExecuter;
using SpecialInsulator.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace SpecialInsulator.DAL.Implementations
{
    public class PostRepository : IPostRepository
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
