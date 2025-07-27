using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;

namespace Application.Posts.Commands
{
    public class DeletePost : IRequest<Post>
    {
        public int PostId { get; set; }
    }
}
