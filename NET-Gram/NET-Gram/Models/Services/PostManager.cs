using NET_Gram.Data;
using NET_Gram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NET_Gram.Models.Services
{
    public class PostManager : IPost
    {
        private readonly PostDbContext _context;

        public PostManager(PostDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            Post post = await _context.Posts.FindAsync(id);

            if (post != null)
            {
                _context.Remove(post);
                
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Post> FindPost(int id)
        {       
            Post post = await _context.Posts.FirstOrDefaultAsync(p => p.ID == id);

            return post;
        }

        public async Task<List<Post>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task SaveAsync(Post post)
        {
            if (await _context.Posts.FirstOrDefaultAsync(p => p.ID == post.ID) == null)
            {
                _context.Posts.Add(post);
            }
            else
            {
                _context.Posts.Update(post);
            }
            await _context.SaveChangesAsync();
        }
    }
}