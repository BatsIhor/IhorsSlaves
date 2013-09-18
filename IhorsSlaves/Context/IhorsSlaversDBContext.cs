using System.Data.Entity;
using IhorsSlaves.Models;

namespace IhorsSlaves.Context
{
    public class IhorsSlaversDbContext : DbContext
    {
            public DbSet<Post> Posts { get; set; }
            public DbSet<Comment> Comments { get; set; }
            public DbSet<ImagesAlbum> ImagesAlbum { get; set; }
            public DbSet<Image> Images { get; set; }
    }
}