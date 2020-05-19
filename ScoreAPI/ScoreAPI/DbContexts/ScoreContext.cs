using Microsoft.EntityFrameworkCore;
using ScoreAPI.Entity;
using System;

namespace ScoreAPI.DbContexts
{
    public class ScoreContext : DbContext
    {
        public ScoreContext(DbContextOptions<ScoreContext> options) : base(options)
        {

        }

        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Score>().HasData(new Score()
            {
                Id = Guid.Parse("6b1eea43-5597-45a6-bdea-e68c60564247"),
                UserName = "Edgar",
                Points = 12

            },
            new Score
            {
                Id = Guid.Parse("a052a63d-fa53-44d5-a197-83089818a676"),
                UserName = "Ianko",
                Points = 31
            },
            new Score
            {
                Id = Guid.Parse("cb554ed6-8fa7-4b8d-8d90-55cc6a3e0074"),
                UserName = "Fernando",
                Points = 63
            },
            new Score
            {
                Id = Guid.Parse("8e2f0a16-4c09-44c7-ba56-8dc62dfd792d"),
                UserName = "Paul",
                Points = 99
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
