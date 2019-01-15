using Common.Entity;
using Special_Insulator.DAL.Interfaces;
using Specila_Insultor.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specila_Insultor.BLL
{
    public class PostBusiness : IPostBusiness
    {
        IPostData postData;

        public PostBusiness(IPostData postData)
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

        //public List<WorkerAndName> SetPostsToWorkers(List<WorkerAndName> workers)
        //{
        //    var posts = GetAllPosts();
        //    Post post = null;
        //    if(posts != null)
        //    {
        //        foreach(var item in workers)
        //        {
        //            post = posts.FirstOrDefault(p => p.Id == item.Worker.WorkerPost.Id);
        //            if(post!=null)
        //            {
        //                item.Worker.
        //            }
        //        }
        //    }

        //    return workers;
        //}
    }
}
