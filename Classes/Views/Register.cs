using ToDoApplication.Classes.Controllers;
using ToDoApplication.Data;

namespace ToDoApplication.Classes.Views
{
  public class Register : IView
  {
    private AuthSession authSession;

    private bool inputErr = false;

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

    public Register(AuthSession authSession)
    {
      this.authSession = authSession;
    }

    public void EditInputField(int index)
    {
      if (index == 0) EditUsernameField(index);
      
      options[3].ItmLabel = "Register";
    }

    public void EditPasswordField(int index)
    {
      if (index == 1) EditPasswordField1(index);
      else if (index == 2) EditPasswordField2(index);

      options[3].ItmLabel = "Register";
    }

    private void EditUsernameField(int index)
    {
      Console.Clear();

      Console.Write("Enter username: ");
      string fieldValue = Console.ReadLine();

      options[index].ItmValue = fieldValue;

      options[0].ItmLabel = $"Username: [{options[0].ItmValue}]";
    }

    private void EditPasswordField1(int index)
    {
      Console.Clear();

      Console.Write("Enter password: ");
      string fieldValue = Console.ReadLine();

      options[index].ItmValue = fieldValue;

      string maskedPassword = new string('*', options[1].ItmValue.Length);
      options[1].ItmLabel = $"Password: [{maskedPassword}]";
    }

    private void EditPasswordField2(int index)
    {
      Console.Clear();

      Console.Write("Repeat password: ");
      string fieldValue = Console.ReadLine();

      options[index].ItmValue = fieldValue;

      string maskedPassword = new string('*', options[2].ItmValue.Length);

      if (options[1].ItmValue != options[2].ItmValue)
      {
        options[2].ItmLabel = $"Verify Password: [{maskedPassword}] passwords do not match!";
        inputErr = true;
      } 
      else
      {
        options[2].ItmLabel = $"Verify Password: [{maskedPassword}]";
        inputErr = false;
      }
    }

    public string? ExecuteOption(int selectedIndex)
    {
      DisplayController displayController = new DisplayController();

      switch (selectedIndex)
      {
        case 3:
          if (inputErr) return null;

          AuthService authService = new AuthService();

          string username = options[0].ItmValue;
          string password = options[1].ItmValue;

          if (authService.Register(username, password) == 1)
          {
            options[3].ItmLabel = "Register | Username or password too short";
            return null;
          }

          return "login";
        case 4:
          return "home";
      }

      return null;
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