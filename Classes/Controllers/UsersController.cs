using ToDoApplication.Classes.Models;
using ToDoApplication.Data;

namespace ToDoApplication.Classes.Controllers
{
  public class UsersController
  {
    private readonly AppDbContext db;

    public UsersController()
    {
      db = new AppDbContext();
    }

    public void ShowUsers()
    {
      List<User> users = db.Users.OrderBy(x => x.Id).ToList();

      foreach (User user in users)
      {
        Console.WriteLine(user.Username);
      }
    }
  }
}