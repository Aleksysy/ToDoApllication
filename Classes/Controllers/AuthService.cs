using ToDoApplication.Classes.Models;
using ToDoApplication.Data;

namespace ToDoApplication.Classes.Controllers
{
  class AuthService
  {
    private readonly AppDbContext db;

    public AuthService(AppDbContext db)
    {
      this.db = db;
    }

    public int Register(
      string username,
      string password)
    {
      bool exists = db.Users.Any(x => x.Username == username);

      if (exists) return 1;

      User user = new User
      {
        Username = username,
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
      };

      db.Users.Add(user);

      db.SaveChanges();

      return 0;
    }

    public User? Login(
      string username,
      string password)
    {
      User? user = db.Users.FirstOrDefault(x => x.Username == username);

      if (user == null) return null;

      bool isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

      if (!isValid) return null;

      return user;
    }
  }
}