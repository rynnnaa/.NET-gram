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
               },
               new Post
               {
                   ID = 2,
                   Title = "bubbles",
                   Caption = "In a bathtub",
                   Rating = 3,
                   URL = "bubbles.jpg"
               },
               new Post
               {
                   ID = 3,
                   Title = "clouds",
                   Caption = "On cloud nine",
                   Rating = 4,
                   URL = "cloud.jpg"
               },
               new Post
               {
                   ID = 4,
                   Title = "food",
                   Caption = "I love food",
                   Rating = 5,
                   URL = "food.jpg"
               },
               new Post
               {
                   ID = 5,
                   Title = "makeup",
                   Caption = "I like it",
                   Rating = 4,
                   URL = "makeup.jpg"
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
