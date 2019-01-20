using SpecialInsulator.Common.Entity;
using SpecialInsulator.BLL.Interfaces;
using SpecialInsulator.DAL.Interfaces;
using System.Collections.Generic;

namespace SpecialInsulator.BLL.Implementations
{
    public class PostService : IPostService
    {
        IPostRepository postRepository;

        public PostService(IPostRepository postData)
        {
            this.postRepository = postData;
        }

        public bool AddPost(Post post)
        {
            if(post != null)
            {
                return postRepository.AddPost(post);
            }
            return false;
        }

        public bool DeletePostById(int? Id)
        {
            if(Id != null)
            {
                return postRepository.DeletePostById(int.Parse(Id.ToString()));
            }
            return false;
        }

        public bool EditPost(Post post)
        {
            if(post != null)
            {
                return postRepository.EditPost(post);
            }
            return false;
        }

        public List<Post> GetAllPosts()
        {
            return postRepository.GetAllPosts();
        }

        public Post GetPostById(int? Id)
        {
            if(Id != null)
            {
                return postRepository.GetPostById(int.Parse(Id.ToString()));
            }
            return null;
        }

        public bool IsNewPost(string postName)
        {
            List<Post> posts = GetAllPosts();
            if(posts != null)
            {
                foreach (var item in posts)
                {
                    if (item.PostName.ToLower() == postName.ToLower())
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        public bool IsUsing(int? Id)
        {
            if(Id != null)
            {
                List<int> ids = postRepository.GetUsingIds();
                int id = int.Parse(Id.ToString());

                if (ids != null)
                {
                    foreach(var item in ids)
                    {
                        if(item == id)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public List<Post> SwapPost(int? Id)
        {
            List<Post> posts = GetAllPosts();
            Post post = null;
            if (Id != null && posts!= null && posts.Count>0 && Id>0 && Id <= posts.Count)
            {
                int id = int.Parse(Id.ToString());
                post = posts[0];
                posts[0] = posts[id - 1];
                posts[id - 1] = post;
            }
            return posts;
        }

    }
}
