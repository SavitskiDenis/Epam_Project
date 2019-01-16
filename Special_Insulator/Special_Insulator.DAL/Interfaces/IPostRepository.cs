using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IPostRepository
    {
        void AddPost(Post post);

        List<Post> GetAllPosts();

        Post GetPostById(int Id);

        void DeletePostById(int Id);

        void EditPost(Post post);
    }
}
