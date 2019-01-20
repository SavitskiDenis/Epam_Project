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

        public bool AddPost(Post post)
        {
            try
            {
                Executer.ExecuteNonQuery(connectionString, "AddPost", new SqlParameter("@Post", post.PostName));
            }
            catch
            {
                return false;
            }
            return true;
            
        }

        public bool DeletePostById(int Id)
        {
            try
            {
                Executer.ExecuteNonQuery(connectionString, "DeletePost", new SqlParameter("@Id", Id));
            }
            catch
            {
                return false;
            }
            return true;
            
        }

        public bool EditPost(Post post)
        {
            try
            {
                Executer.ExecuteNonQuery(connectionString,
                                    "UpdatePost",
                                    new SqlParameter("@Id", post.Id),
                                    new SqlParameter("@Post", post.PostName));
            }
            catch
            {
                return false;
            }
            return true;
            
        }

        public List<Post> GetAllPosts()
        {
            List<Post> posts;
            try
            {
                posts = Executer.ExecuteCollectionRead(connectionString, "SelectAllPosts", new ReadPost());
            }
            catch
            {
                return null;
            }
            return posts;
        }

        public Post GetPostById(int Id)
        {
            Post post;
            try
            {
                post = Executer.ExecuteRead(connectionString, "SelectPostById", new ReadPost(), new SqlParameter("@Id", Id));
            }
            catch
            {
                return null;
            }
            return post;
        }

        public List<int> GetUsingIds()
        {
            List<int> ids;
            try
            {
                ids = Executer.ExecuteCollectionRead(connectionString, "SelectAllPostIdsFromWorkers",new ReadId());
            }
            catch
            {
                return null;
            }
            return ids;
        }

        
    }
}
