using Portfolio.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Api.Data;

public class ProjectStoreContext(DbContextOptions<ProjectStoreContext> options) : DbContext(options) {
  
  public DbSet<Project> Projects => Set<Project>();

  public DbSet<ProjectType> ProjectTypes => Set<ProjectType>();

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<ProjectType>().HasData(
          new {Id = 1, Name = "Learning",},
          new {Id = 2, Name = "React",},
          new {Id = 3, Name = "Dotnet",}
        );
    }
}