using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.DAL.Interfaces
{
    public interface IPostRepository
    {
        bool AddPost(Post post);

        List<Post> GetAllPosts();

        Post GetPostById(int Id);

        bool DeletePostById(int Id);

        bool EditPost(Post post);
    }
}
