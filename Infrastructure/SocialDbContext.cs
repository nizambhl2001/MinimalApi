using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class SocialDbContext : DbContext
    {
        public SocialDbContext(DbContextOptions options) :base(options)
        {
            
        }
        public DbSet<Post> posts { get; set; }

    }
}
