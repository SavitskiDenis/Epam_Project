using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specila_Insultor.BLL.Interfaces
{
    public interface IPostBusiness
    {
        void AddPost(Post post);

        List<Post> GetAllPosts();

        Post GetPostById(int Id);

        void DeletePostById(int Id);

        void EditPost(Post post);

        List<Post> SwapPost(int Id);

        //List<WorkerAndName> SetPostsToWorkers(List<WorkerAndName> workers);
    }
}
