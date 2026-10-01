using ToDoApplication.Classes.Models;

namespace ToDoApplication.Classes.Controllers
{
  public class AuthSession
  {
    public User? CurrentUser { get; private set; }
    public bool IsAuthenticated => CurrentUser != null;
    
    public void Login(User user)
    {
      CurrentUser = user;
    }

    public void Logout()
    {
      CurrentUser = null;
    }
  }
}