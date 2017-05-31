using Rhythm.Domain.Entities;
using System.Data.Entity;

namespace Rhythm.Domain.Context
{
    public class DogCodingContext : DbContext
    {
        public DogCodingContext() : base("name=DogCodingContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ChiefUser> ChiefUsers { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Portfolio> Portfolios { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
    }
}
