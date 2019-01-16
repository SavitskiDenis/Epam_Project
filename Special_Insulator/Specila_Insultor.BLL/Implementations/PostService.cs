using SpecialInsulator.Common.Entity;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.DAL.Interfaces;
using System.Collections.Generic;

namespace SpecialInsulator.BLL.Implementations
{
    public class PostService : IPostService
    {
        IPostRepository postData;

        public PostService(IPostRepository postData)
        {
            this.postData = postData;
        }

        public void AddPost(Post post)
        {
            postData.AddPost(post);
        }

        public void DeletePostById(int Id)
        {
            postData.DeletePostById(Id);
        }

        public void EditPost(Post post)
        {
            postData.EditPost(post);
        }

        public List<Post> GetAllPosts()
        {
            return postData.GetAllPosts();
        }

        public Post GetPostById(int Id)
        {
            return postData.GetPostById(Id);
        }

        public List<Post> SwapPost(int Id)
        {
            List<Post> posts = GetAllPosts();
            Post post = null;
            if (posts.Count>1 && Id>0 && Id < posts.Count)
            {
                post = posts[0];
                posts[0] = posts[Id];
                posts[Id] = post;
            }
            return posts;
        }

    }
}
