using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using MinimalAPI.Abstractions;
using MinimalAPI.Filter;

namespace MinimalAPI.PostEndPointDefenations
{
    public class PostEndPointDefenation : IEndPointDefenation
    {
        public void ResisterEndPoints(WebApplication app)
        {
            var posts = app.MapGroup("/api/posts");

            posts.MapGet("/{id}",GetPostById) .WithName("GetPostById");

            posts.MapPost("/",CreatePost).AddEndpointFilter<PostValidatorFilter>();

            posts.MapGet("/",GetAllPost);

            posts.MapPut("/{id}", UpdatePost).AddEndpointFilter<PostValidatorFilter>(); ;


            posts.MapDelete("/{id}", DeletePost);

            
        }

        private async Task<IResult> GetPostById(IMediator mediator, int id)
        {
            var getPost = new GetPostById { PostId = id };
            var post = await mediator.Send(getPost);
            return TypedResults.Ok(post);
        } 

        private async Task<IResult> CreatePost(IMediator mediator, Post post)
        {
            var createPost = new CreatePost { PostContent = post.Content };
            var createdPost = await mediator.Send(createPost);
            return Results.CreatedAtRoute("GetPostById", new { createdPost.Id }, createdPost);
        }

        private async Task<IResult> GetAllPost(IMediator mediator)
        {
            var getCommand = new GetAllPost();
            var posts = await mediator.Send(getCommand);
            return TypedResults.Ok(posts);
        }

        private async Task<IResult> UpdatePost(IMediator mediator, Post post, int id)
        {

            var updatePost = new UpdatePost { PostId = id, PostContent = post.Content };
            var updatedPost = await mediator.Send(updatePost);
            return TypedResults.Ok(updatedPost);
        }

        private async Task<IResult> DeletePost(IMediator mediator, int id) 
        {

            var deletePost = new DeletePost { PostId = id };
            await mediator.Send(deletePost);
            return TypedResults.NoContent();

        }

}
}
