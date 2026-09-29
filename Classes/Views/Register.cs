using ToDoApplication.Classes.Controllers;

namespace ToDoApplication.Classes.Views
{
  class Register : IView
  {
    private List<ViewOption> options = [
      new("Username: []", OptionType.Input, ""),
      new("Password: []", OptionType.Password, ""),
      new("Verify Password: []", OptionType.Password, ""),
      new("Register", OptionType.Action, ""),
      new("back", OptionType.Back, ""),
    ];

    public List<ViewOption> Options
    {
      get { return options; }
    }

    public void EditInputField(int index) {}
    public void EditPasswordField(int index) {}

    public void ExecuteOption(int selectedIndex)
    {
      DisplayController displayController = new DisplayController();

      switch (selectedIndex)
      {
        case 0:
            Console.WriteLine("Registering...");
            DisplayController.QuitApp();
            break;
        case 1:
            displayController.UpdateDisplay("home");
            break;
      }
    }

    public string GetAppHeader()
    {
      return "ToDoApplication CLI\n" +
             "===REGISTER===\n\n";
    }

    public void PrintAppHeader()
    {
      Console.WriteLine(GetAppHeader());
    }
  }
}