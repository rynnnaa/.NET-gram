using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET_Gram.Models;
using Microsoft.EntityFrameworkCore;

namespace NET_Gram.Data
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
               new Post
               {
                   ID = 1,
                   Title = "flowers",
                   Caption = "In a field of dreams",
                   Rating = 4,
                   URL = "flowers.jpg"
               }
                );
        }

        internal void Remove(Post post)
        {
            throw new NotImplementedException();
        }

        //db table
        public DbSet<Post> Posts { get; set; }
    }
}
