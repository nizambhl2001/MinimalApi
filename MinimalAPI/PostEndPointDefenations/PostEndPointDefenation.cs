﻿using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using MinimalAPI.Abstractions;

namespace MinimalAPI.PostEndPointDefenations
{
    public class PostEndPointDefenation : IEndPointDefenation
    {
        public void ResisterEndPoints(WebApplication app)
        {
            var posts = app.MapGroup("/api/posts");

            posts.MapGet("/{id}", async (IMediator mediator, int id) =>
            {
                var getPost = new GetPostById { PostId = id };
                var post = await mediator.Send(getPost);
                return Results.Ok(post);

            }) .WithName("GetPostById");

            posts.MapPost("/", async (IMediator mediator, Post post) =>
            {
                var createPost = new CreatePost { PostContent = post.Content };
                var createdPost = await mediator.Send(createPost);
                return Results.CreatedAtRoute("GetPostById", new { createdPost.Id }, createdPost);
            });

            posts.MapGet("/", async (IMediator mediator) =>
            {

                var getCommand = new GetAllPost();
                var posts = await mediator.Send(getCommand);
                return Results.Ok(posts);

            });

            posts.MapPut("/{id}", async (IMediator mediator, Post post, int id) =>
            {

                var updatePost = new UpdatePost { PostId = id, PostContent = post.Content };
                var updatedPost = await mediator.Send(updatePost);
                return Results.Ok(updatedPost);

            });


            posts.MapDelete("/{id}", async (IMediator mediator, int id) =>
            {

                var deletePost = new DeletePost { PostId = id };
                await mediator.Send(deletePost);
                return Results.NoContent();

            });
        }
    }
}
