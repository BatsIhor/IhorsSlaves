using System;
using System.Collections.Generic;
using System.Linq;
using IhorsSlaves.Context;
using IhorsSlaves.Models;

namespace IhorsSlaves.Repository
{
    public class PostRepository : IPostRepository
    {
        private IhorsSlaversDbContext context = new IhorsSlaversDbContext();
        
        public IEnumerable<Post> GetPosts()
        {
           // Post first = context.Posts.First();
            
            //first.Comments = new List<Comment>();
            //first.Comments.Add(new Comment(){Content = "comment", Date = DateTime.Now, Email = "m@il", User = "megacool"});
            //context.SaveChanges();
            
            return context.Posts.OrderByDescending(p => p.PostDate);
        }

        public void AddPost(Post post, string user, DateTime date)
        {
            post.PostUser = user;
            post.PostDate = date;
            context.Posts.Add(post);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public Post FindPostById(int id)
        {
            Post post = context.Posts.Find(id);
            return post;
        }

        public void EditPost(Post post)
        {
            context.Entry(post).State = System.Data.EntityState.Modified;
        }

        public void DeletePost(Post post)
        {
            context.Posts.Remove(post);
        }
    }
}