using ToDoApplication.Classes.Controllers;
using ToDoApplication.Classes.Views;

namespace ToDoApplication.Classes.Views
{
  public class Home : IView
  {
    private string[] selectOptions = {"Login", "Register", "Exit"};

    public string[] SelectOptions
    {
      get { return this.selectOptions; }
    }

    public void ExecuteOption(int selectedIndex)
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
            Console.CursorVisible = true;
            Environment.Exit(0);
            break;
      }
    }
  }
}