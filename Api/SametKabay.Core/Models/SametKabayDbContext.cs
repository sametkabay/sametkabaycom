using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SametKabay.Core.Models;
using System.Configuration;

namespace SametKabay.Core
{
    public class SametKabayDbContext : DbContext
    {
        public SametKabayDbContext()
        {

        }

        public SametKabayDbContext(DbContextOptions<SametKabayDbContext> options)
            : base(options)
        {
           
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogPostCategory> BlogPostCategories { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogPostTag> BlogPostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
