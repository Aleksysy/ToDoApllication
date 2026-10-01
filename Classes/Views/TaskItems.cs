using ToDoApplication.Classes.Controllers;
using ToDoApplication.Classes.Models;

namespace ToDoApplication.Classes.Views
{
  public class TaskItems : IView
  {
    private AuthSession authSession;

    private List<ViewOption> options = [
      new("Create", OptionType.Action, ""),
      new("Logout", OptionType.Action, ""),
    ];

    public List<ViewOption> Options
    {
      get { return options; }
    }

    public TaskItems(AuthSession authSession)
    {
      this.authSession = authSession;
    }

    public void EditInputField(int index) {}

    public void EditPasswordField(int index) {}

    public string? ExecuteOption(int selectIndex)
    {
      switch (selectIndex)
      {
        case 0:
          return "home";
          return "taskitem";
        case 1:
          authSession.Logout();

          return "home";
      }

      return null;
    }

    public string GetAppHeader()
    {
      User? user = authSession.CurrentUser;

      return "ToDoApplication CLI\n" +
             "===Tasks=== Welcome " + user?.Username + "\n\n";
    }

    public void PrintAppHeader()
    {
      Console.WriteLine(GetAppHeader());
    }
  }
}