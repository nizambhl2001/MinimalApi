using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetAllPost();
        Task<Post> GetPostById(int postId);
        Task<Post> CreatePost(Post toCreate);
        Task<Post> UpdatePost(string updateContent,int postId);
        Task DeletePost(int postId);

    }
}
