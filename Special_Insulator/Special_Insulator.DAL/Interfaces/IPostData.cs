using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Insulator.DAL.Interfaces
{
    public interface IPostData
    {
        void AddPost(Post post);

        List<Post> GetAllPosts();

        Post GetPostById(int Id);

        void DeletePostById(int Id);

        void EditPost(Post post);
    }
}
