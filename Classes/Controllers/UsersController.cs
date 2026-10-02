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
  }
}