using ToDoApplication.Classes.Controllers;
using ToDoApplication.Classes.Models;

namespace ToDoApplication.Classes.Views
{
  public class TaskItems : IView
  {
    private AuthSession authSession;
    TaskItemsController taskItemsController = new TaskItemsController();

    private List<ViewOption> options = [
      new("logout", OptionType.Action, ""),
      new("Create", OptionType.Action, "spaceb"),
    ];

    public List<ViewOption> Options
    {
      get { return options; }
    }

    public TaskItems(AuthSession authSession)
    {
      this.authSession = authSession;

      LoadTaskOptions();
    }

    private void LoadTaskOptions()
    {
      options = [
        new("logout", OptionType.Action, ""),
        new("Create", OptionType.Action, "spaceb"),
      ];

      List<TaskItem> taskItems = 
        taskItemsController.GetUserTaskItems(this.authSession);

      foreach (TaskItem taskItem in taskItems)
      {
        string itmLable = taskItem.IsCompleted ? 
          taskItem.Title + "[]" : taskItem.Title + "[x]";

        options.Add(
          new(taskItem.Title, OptionType.Action, "" + taskItem.Id)
        );
      }
    }

    private void CreateUserTaskItem(string title, string description)
    {
      taskItemsController.CreateUserTaskItem(authSession, title, description);
    }

    public void EditInputField(int index) {}

    public void EditPasswordField(int index) {}

    private void CreateTaskField()
    {
      Console.Clear();

      Console.CursorVisible = true;

      Console.Write("Enter task title: ");
      string taskTitle = Console.ReadLine();

      if (taskTitle == "") return;

      Console.Write("Enter task description: ");
      string taskDescription = Console.ReadLine();

      Console.CursorVisible = false;

      CreateUserTaskItem(taskTitle, taskDescription);
    }

    public string? ExecuteOption(int selectIndex)
    {
      switch (selectIndex)
      {
        case 0:
          authSession.Logout();

          return "home";
        case 1:
          CreateTaskField();

          return "taskitems";
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