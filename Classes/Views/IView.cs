using ToDoApplication.Classes.Controllers;
using ToDoApplication.Classes.Views;

namespace ToDoApplication.Classes.Views
{
  public interface IView 
  {
    string[] SelectOptions { get; }

    void ExecuteOption(int index);
  }
}