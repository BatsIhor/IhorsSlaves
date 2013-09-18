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

        public void AddComment(Comment comment)
        {
            context.Comments.Add(comment);
        }

        public void AddImage(Image image)
        {
            context.Images.Add(image);
        }
    }
}