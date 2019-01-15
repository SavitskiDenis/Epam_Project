using Common.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Reader
{
    public class ReadPost : IReader<Post>
    {
        public List<Post> GetCollection(SqlDataReader dataReader)
        {
            List<Post> posts = new List<Post>();
            Post post = null;
            try
            {
                if (dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        post = new Post
                        {
                            Id = (int)dataReader["Id"],
                            PostName = (string)dataReader["Post"]
                        };
                        posts.Add(post);
                    }
                }
            }
            catch
            {
                throw;
            }
            return posts;
        }

        public Post GetModel(SqlDataReader dataReader)
        {
            Post post = null;
            try
            {
                dataReader.Read();
                post = new Post
                {
                    Id = (int)dataReader["Id"],
                    PostName = (string)dataReader["Post"]
                };
            }
            catch
            {
                throw;
            }
            return post;
        }
    }
}
