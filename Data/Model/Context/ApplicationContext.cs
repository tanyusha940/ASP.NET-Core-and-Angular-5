using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Data.Model.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConspectTag>()
                .HasKey(ct => new { ct.ConspectId, ct.TagId });

            modelBuilder.Entity<ConspectTag>()
                .HasOne(ct => ct.Conspect)
                .WithMany(c => c.ConspectTags)
                .HasForeignKey(ct => ct.ConspectId);

            modelBuilder.Entity<ConspectTag>()
                .HasOne(ct => ct.Tag)
                .WithMany(t => t.ConspectTags)
                .HasForeignKey(ct => ct.TagId);

        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Conspect> Conspects { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ConspectTag> ConspectTags { get; set; }
    }
}
