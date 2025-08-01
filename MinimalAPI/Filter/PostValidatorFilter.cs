using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace MinimalAPI.Filter
{
    public class PostValidatorFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var post = context.GetArgument<Post>(1);
            if (string.IsNullOrEmpty(post.Content)) return await Task.FromResult(Results.BadRequest("Post Not Valided"));
            return await next(context);
        }
    }
}
