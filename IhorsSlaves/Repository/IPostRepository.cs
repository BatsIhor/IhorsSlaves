using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IhorsSlaves.Models;

namespace IhorsSlaves.Repository
{
   public interface IPostRepository
    {
       void SaveChanges();

       IEnumerable<Post> GetPosts();

       void AddPost(Post addform, string user, DateTime date);

       Post FindPostById(int id);
       
       void EditPost(Post post);

       void DeletePost(Post post);

       void AddComment(Comment comment);
    }
}
