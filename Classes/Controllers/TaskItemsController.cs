using ToDoApplication.Classes.Models;
using ToDoApplication.Data;

namespace ToDoApplication.Classes.Controllers
{
  public class TaskItemsController
  {
    private readonly AppDbContext db;

    public TaskItemsController()
    {
      db = new AppDbContext();
    }

    public TaskItem? GetTaskItem(AuthSession authSession, int taskId)
    {
      int userId = authSession.CurrentUser!.Id;
      return db.TaskItems
        .FirstOrDefault(x => 
        x.UserId == userId &&
        x.Id == taskId);
    }

    public void EditTaskItem(
      AuthSession authSession,
      int taskId,
      string title,
      string description,
      bool isCompleted)
    {
      int userId = authSession.CurrentUser!.Id;
      TaskItem? taskItem = db.TaskItems
        .FirstOrDefault(x =>
          x.UserId == userId &&
          x.Id == taskId);

      taskItem.Title = title;
      taskItem.Description = description;
      taskItem.IsCompleted = isCompleted;

      db.SaveChanges();
    }

    public List<TaskItem> GetUserTaskItems(AuthSession authSession)
    {
      int userId = authSession.CurrentUser!.Id;
      return db.TaskItems
        .Where(x => x.UserId == userId)
        .OrderByDescending(p => p.Id)
        .ToList();
    }

    public void CreateUserTaskItem(
      AuthSession authSession, 
      string title, 
      string description)
    {
      TaskItem taskItem = new TaskItem
      {
        Title = title,
        Description = description,
        UserId = authSession.CurrentUser!.Id
      };

      db.TaskItems.Add(taskItem);

      db.SaveChangesAsync();
    }

    public void RemoveUserTaskItem(
      AuthSession authSession,
      int taskId)
    {
      int userId = authSession.CurrentUser!.Id;
      TaskItem? taskItem = db.TaskItems
        .FirstOrDefault(x =>
          x.UserId == userId &&
          x.Id == taskId);

      db.TaskItems.Remove(taskItem);

      db.SaveChanges();
    }
  }
}