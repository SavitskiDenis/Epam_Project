using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.BLL.Interfaces
{
    public interface IPostService
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
