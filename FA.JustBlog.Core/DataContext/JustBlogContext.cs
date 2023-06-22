using FA.JustBlog.Core.Configs;
using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.DataContext
{
    public class JustBlogContext : IdentityDbContext<FAJustBlogUser>
    {
        public JustBlogContext() { }
        public JustBlogContext(DbContextOptions<JustBlogContext> options) : base(options)
        {

        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<PostTagMap> PostTagMaps { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<FAJustBlogUser> FAJustBlogUser { get; set; }

        public DbSet<IdentityRole> IdentityRole { get; set; }

        public DbSet<IdentityUserRole<string>> IdentityUserRole { get; set; }

        /// <summary>
        /// ket noi voi database
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.;database=DBJustBlog;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        /// <summary>
        /// ket noi toi cac class congfigs
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasKey(ur => new { ur.RoleId, ur.UserId });
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostConfigs).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostTagMapConfigs).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TagConfigs).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommentConfigs).Assembly);
            modelBuilder.SeedData();
        }
    }
}
