using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IhorsSlaves.Models;

namespace IhorsSlaves.Context
{
    public class IhorsSlaversDBContext : DbContext
    {
            public DbSet<Post> Posts { get; set; }
    }
}