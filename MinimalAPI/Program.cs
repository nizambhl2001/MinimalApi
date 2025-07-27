
using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;
using MinimalAPI.Extensions;



var builder = WebApplication.CreateBuilder(args);
builder.ResistaionExtensions();

// Add services to the container.P

var app = builder.Build();




// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.RegisterEndpointoefinitions();

app.Run();

