using System.Text.RegularExpressions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Persistence
{

    public class PostsDbContext : DbContext
    {

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostAudienceGroup> AudienceGroups { get; set; }

        public DbSet<EmailSubscription> EmailSubscriptions { get; set; }

        public PostsDbContext(DbContextOptions<PostsDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Post>(entity =>
            {
                entity.HasOne(post => post.AudienceGroup)
                                .WithMany(audience => audience.Posts)
                            .HasForeignKey(post => post.Audience);
            });

            builder.Entity<PostAudienceGroup>(entity =>
            {
                entity.HasMany(audience => audience.Posts)
                            .WithOne(post => post.AudienceGroup);
            });

        }

    }

}