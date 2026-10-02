using System.Collections.Generic;

namespace ToDoApplication.Classes.Models
{
  public class User
  {
    public int Id { get; set; }
    public string Username { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public List<TaskItem> TaskItems { get; set; } = [];
  }
}