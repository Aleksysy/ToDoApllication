using Microsoft.EntityFrameworkCore;
using ToDoApplication.Classes.Models;

namespace ToDoApplication.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      options.UseSqlite("Data Source=app.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>()
        .HasIndex(x => x.Username)
        .IsUnique();
    }
  }
}