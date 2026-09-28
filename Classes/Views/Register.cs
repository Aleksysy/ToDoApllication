using ToDoApplication.Classes.Controllers;

namespace ToDoApplication.Classes.Views
{
  class Register : IView
  {
    private string[] selectOptions = {"Register", "Back"};

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
            Console.WriteLine("Registering...");
            Environment.Exit(0);
            break;
        case 1:
            displayController.UpdateDisplay("home");
            break;
      }
    }
  }
}