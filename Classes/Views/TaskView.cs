using ToDoApplication.Classes.Controllers;
using ToDoApplication.Classes.Models;

namespace ToDoApplication.Classes.Views
{
  public class TaskView : IView
  {
    private AuthSession authSession;
    TaskItemsController taskItemsController = new TaskItemsController();

    private List<ViewOption> options = [
      new("Title: []", OptionType.Action, ""),
      new("Description: []", OptionType.Action, ""),
      new("done: []", OptionType.Action, ""),
      new("delete", OptionType.Action, ""),
      new("back", OptionType.Back, ""),
    ];

    public List<ViewOption> Options
    {
      get { return options; }
    }

    public TaskView(AuthSession authSession, int taskId)
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
          // change title
          return "home";
        case 1:
          // change description
          return "taskitems";
        case 2:
          // check
          return "taskitems";
        case 3:
          // delete
          return "taskitems";
        case 4:
          return "taskitems";
      }

      return null;
    }

    public string GetAppHeader()
    {
      return "ToDoApplication CLI\n" +
             "===Task===\n\n";
    }

    public void PrintAppHeader()
    {
      Console.WriteLine(GetAppHeader());
    }
  }
}