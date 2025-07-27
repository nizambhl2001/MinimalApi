using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialDbContext _context;

        public PostRepository(SocialDbContext context)
        {
            _context = context;
        }
        public async Task<Post> CreatePost(Post toCreate)
        {
           toCreate.DateCreated = DateTime.Now;
            toCreate.LastModified = DateTime.Now;
            _context.posts.Add(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;
        }

        public async Task DeletePost(int postId)
        {
            var post = await _context.posts.FirstOrDefaultAsync(x => x.Id == postId);
            if (post == null) return;
            _context.posts.Remove(post);
            await _context.SaveChangesAsync();

        }

        public async Task<ICollection<Post>> GetAllPost()
        {
           return await _context.posts.ToListAsync();   
        }

        public async Task<Post> GetPostById(int postId)
        {
            return  await _context.posts.FirstOrDefaultAsync(x => x.Id == postId);
           

        }

        public async Task<Post> UpdatePost(string updateContent, int postId)
        {
            var post = await _context.posts.FirstOrDefaultAsync(x => x.Id == postId);
            post.DateCreated = DateTime.Now;
            post.Content = updateContent;

            await _context.SaveChangesAsync();
            return post;

        }
    }
}
