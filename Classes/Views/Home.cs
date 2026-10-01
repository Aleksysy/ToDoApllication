using ToDoApplication.Classes.Controllers;
using ToDoApplication.Classes.Views;

namespace ToDoApplication.Classes.Views
{
  public class Home : IView
  {
    private AuthSession authSession;

    private List<ViewOption> options = [
      new("Login", OptionType.Action, ""),
      new("Register", OptionType.Action, ""),
      new("exit", OptionType.Action, ""),
    ];

    public List<ViewOption> Options
    {
      get { return options; }
    }

    public Home(AuthSession authSession)
    {
      this.authSession = authSession;
    }

    public void EditInputField(int index) {}
    public void EditPasswordField(int index) {}

    public string? ExecuteOption(int selectedIndex)
    {
      DisplayController displayController = new DisplayController();

      switch (selectedIndex)
      {
        case 0:
            displayController.UpdateDisplay("login");
            break;
        case 1:
            displayController.UpdateDisplay("register");
            break;
        case 2:
            DisplayController.QuitApp();
            break;
      }

      return null;
    }

    public string GetAppHeader()
    {
      return "ToDoApplication CLI\n" +
             "Use up/down keys to navigate and enter to select:\n\n";
    }

    public void PrintAppHeader()
    {
      Console.WriteLine(GetAppHeader());
    }
  }
}