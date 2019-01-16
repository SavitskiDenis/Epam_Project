using SpecialInsulator.Common.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SpecialInsulator.Common.Reader
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
