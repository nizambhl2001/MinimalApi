using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;

namespace Application.Posts.QueryHandler
{
    public class GetAllPostHandler : IRequestHandler<GetAllPost, ICollection<Post>>
    {
        private readonly IPostRepository _postRepo;

        public GetAllPostHandler(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }
        public async Task<ICollection<Post>> Handle(GetAllPost request, CancellationToken cancellationToken)
        {
            return await _postRepo.GetAllPost();
        }
    }
}
