using ToDoApplication.Classes.Controllers;
using ToDoApplication.Classes.Models;

namespace ToDoApplication.Classes.Views
{
  public class TaskView : IView
  {
    private AuthSession authSession;
    TaskItemsController taskItemsController = new TaskItemsController();

    private int taskItemId;

    private List<ViewOption> options = [
      new("Title: []", OptionType.Input, ""),
      new("Description: []", OptionType.Input, ""),
      new("Done: []", OptionType.Input, ""),
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

      taskItemId = taskId;

      ShowTaskItemOptions(authSession);
    }

    private void ShowTaskItemOptions(AuthSession authSession)
    {
      TaskItem taskItem = taskItemsController.GetTaskItem(authSession, taskItemId);

      options[0].ItmValue = taskItem.Title;
      options[0].ItmLabel = $"Title: [{taskItem.Title}]";

      options[1].ItmValue = taskItem.Description;
      options[1].ItmLabel = $"Title: [{taskItem.Description}]";

      options[2].ItmValue = Convert.ToString(taskItem.IsCompleted);
      options[2].ItmLabel = !taskItem.IsCompleted ? "Done: []" : "Done: [x]";
    }

    public void EditInputField(int index)
    {
      if (index == 0) TitleInputField();
      else if (index == 1) DescriptionInputField();
      else if (index == 2) DoneInputField();
    }

    public void EditPasswordField(int index) {}

    private void TitleInputField()
    {
      Console.Clear();

      Console.CursorVisible = true;

      Console.Write("Edit title: ");
      string? title = Console.ReadLine();

      Console.CursorVisible = false;

      options[0].ItmValue = title;
      options[0].ItmLabel = $"Title: [{title}]";

      taskItemsController.EditTaskItem(
        authSession,
        taskItemId,
        options[0].ItmValue,
        options[1].ItmValue,
        Convert.ToBoolean(options[2].ItmValue)
      );
    }

    private void DescriptionInputField()
    {
      Console.Clear();

      Console.CursorVisible = true;

      Console.Write("Edit description: ");
      string? description = Console.ReadLine();

      Console.CursorVisible = false;

      options[1].ItmValue = description;
      options[1].ItmLabel = $"Description: [{description}]";

      taskItemsController.EditTaskItem(
        authSession,
        taskItemId,
        options[0].ItmValue,
        options[1].ItmValue,
        Convert.ToBoolean(options[2].ItmValue)
      );
    }

    private void DoneInputField()
    {
      bool isCompleted = !Convert.ToBoolean(options[2].ItmValue);

      options[2].ItmValue = Convert.ToString(isCompleted);
      options[2].ItmLabel = !isCompleted ? "Done: []" : "Done: [x]";

      taskItemsController.EditTaskItem(
        authSession,
        taskItemId,
        options[0].ItmValue,
        options[1].ItmValue,
        isCompleted
      );
    }

    public string? ExecuteOption(int selectIndex)
    {
      switch (selectIndex)
      {
        case 3:
          taskItemsController.RemoveUserTaskItem(authSession, taskItemId);

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