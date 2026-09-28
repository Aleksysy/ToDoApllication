using ToDoApplication.Classes.Controllers;

namespace ToDoApplication.Classes.Views
{
  class Login : IView
  {
    private string[] selectOptions = {"Login", "Back"};

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
            Console.WriteLine("Logging...");
            Environment.Exit(0);
            break;
        case 1:
            displayController.UpdateDisplay("home");
            break;
      }
    }
  }
}