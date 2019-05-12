using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
 
namespace TvSeriesApp.Models
{
    // >dotnet ef migration add testMigration in AspNet5MultipleProject
    public class TvSeriesDataContext : DbContext
    {
        public TvSeriesDataContext(DbContextOptions<TvSeriesDataContext> options) :base(options)
        {
        }
         
        public DbSet<Series> Series { get; set; }
 
        public DbSet<Character> Characters { get; set; }
 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Character>().HasKey(m => m.Id);
            builder.Entity<Series>().HasKey(m => m.Id);
 
            base.OnModelCreating(builder);
        }
    }
}