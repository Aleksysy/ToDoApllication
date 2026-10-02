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

    public List<TaskItem> GetUserTaskItems(AuthSession authSession)
    {
      int userId = authSession.CurrentUser!.Id;
      return db.TaskItems
        .Where(x => x.UserId == userId)
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
  }
}