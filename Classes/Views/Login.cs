using System.Dynamic;
using ToDoApplication.Classes.Controllers;

namespace ToDoApplication.Classes.Views
{
  class Login : IView
  {
    private List<ViewOption> options = [
      new("Username: []", OptionType.Input, ""),
      new("Password: []", OptionType.Password, ""),
      new("Login", OptionType.Action, ""),
      new("back", OptionType.Back, ""),
    ];

    public List<ViewOption> Options
    { 
      get { return options; } 
    }

    public void EditInputField(int index)
    {
      if (index == 0) EditUsernameField(index);
    }

    public void EditPasswordField(int index)
    {
      if (index == 1) EditPasswordField1(index);
    }

    private void EditUsernameField(int index)
    {
      // Ask for username
      Console.Clear();

      Console.Write("Enter username: ");
      string fieldValue = Console.ReadLine();

      // Check errors in input

      options[index].ItmValue = fieldValue;

      // Update all
      options[0].ItmLabel = $"Username: [{options[0].ItmValue}]";

      string maskedPassword = new string('*', options[1].ItmValue.Length);
      options[1].ItmLabel = $"Password: [{maskedPassword}]";
    }

    private void EditPasswordField1(int index)
    {
      Console.Clear();

      Console.Write("Enter password: ");
      string fieldValue = Console.ReadLine();

      options[index].ItmValue = fieldValue;

      // Update all
      options[0].ItmLabel = $"Username: [{options[0].ItmValue}]";

      string maskedPassword = new string('*', options[1].ItmValue.Length);
      options[1].ItmLabel = $"Password: [{maskedPassword}]";
    }

    public void ExecuteOption(int selectedIndex)
    {
      DisplayController displayController = new DisplayController();

      switch (selectedIndex)
      {
        case 2:
            Console.WriteLine("Logging in...");
            DisplayController.QuitApp();
            break;
        case 3:
            displayController.UpdateDisplay("home");
            break;
      }
    }

    public string GetAppHeader()
    {
      return "ToDoApplication CLI\n" +
             "===LOGIN===\n\n";
    }

    public void PrintAppHeader()
    {
      Console.WriteLine(GetAppHeader());
    }
  }
}