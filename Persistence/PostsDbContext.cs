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

        public DbSet<User> Users { get; set; }

        public PostsDbContext(DbContextOptions<PostsDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.Property(e => e.Subscribed).HasDefaultValue(false);
            });

            builder.Entity<Post>(entity =>
            {
                entity.HasOne(post => post.AudienceGroup)
                                .WithMany(audience => audience.Posts)
                            .HasForeignKey(post => post.Audience);

                entity.Property(post => post.PostID)
                        .ValueGeneratedOnAdd();
            });

            builder.Entity<PostAudienceGroup>(entity =>
            {
                entity.HasMany(audience => audience.Posts)
                            .WithOne(post => post.AudienceGroup);

                entity.Property(audience => audience.AudienceGroupID)
                        .ValueGeneratedOnAdd();
            });

        }

    }

}