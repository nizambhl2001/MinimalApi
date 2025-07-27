using Application.Abstractions;
using Application.Posts.Commands;
using Infrastructure.Repositories;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Abstractions;

namespace MinimalAPI.Extensions
{
    public static class MinimalAPIExtensions
    {

        public static void ResistaionExtensions(this WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<SocialDbContext>(options => options.UseSqlServer(cs));
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddMediatR(typeof(CreatePost));
        }

         public static void RegisterEndpointoefinitions(this WebApplication app)
         {

            var endpointoefinition = typeof(Program).Assembly
                        .GetTypes()
                        .Where(t => t.IsAssignableTo(typeof(IEndPointDefenation))
                        && !t.IsAbstract && !t.IsInterface)
                        .Select(Activator.CreateInstance)
                        .Cast<IEndPointDefenation>();

            foreach (var endpoint in endpointoefinition)
            {
                endpoint.ResisterEndPoints(app);
            }

         }

    }
}