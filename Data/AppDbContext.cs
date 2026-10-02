using Microsoft.EntityFrameworkCore;
using ToDoApplication.Classes.Models;

namespace ToDoApplication.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<User> Users => Set<User>();
    public DbSet<TaskItem> TaskItems => Set<TaskItem>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      options.UseSqlite("Data Source=app.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>()
        .HasIndex(x => x.Username)
        .IsUnique();
      
      modelBuilder.Entity<User>()
        .HasMany(x => x.TaskItems)
        .WithOne(x => x.User)
        .HasForeignKey(x => x.UserId)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}