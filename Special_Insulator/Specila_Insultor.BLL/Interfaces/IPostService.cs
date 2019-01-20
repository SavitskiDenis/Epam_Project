using SpecialInsulator.Common.Entity;
using System.Collections.Generic;

namespace SpecialInsulator.BLL.Interfaces
{
    public interface IPostService
    {
        bool AddPost(Post post);

        List<Post> GetAllPosts();

        Post GetPostById(int? Id);

        bool DeletePostById(int? Id);

        bool EditPost(Post post);

        List<Post> SwapPost(int? Id);

        bool IsNewPost(string postName);

        bool IsUsing(int? Id);
    }
}
