using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandler
{
    public class DeletePostHandler : IRequestHandler<DeletePost, Post>
    {
        private readonly IPostRepository _postRepo;

        public DeletePostHandler(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }
        public async Task<Post> Handle(DeletePost request, CancellationToken cancellationToken)
        {
            await _postRepo.DeletePost(request.PostId);
            return new Post();
        }
    }
}
