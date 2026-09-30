using System.Reflection.Emit;
using ToDoApplication.Classes.Controllers;
using ToDoApplication.Classes.Views;

namespace ToDoApplication.Classes.Views
{
  public enum OptionType
  {
    Input,
    Password,
    Action,
    Back
  };

  public class ViewOption 
  {
    public string ItmLabel;
    public OptionType ItmType;
    public string ItmValue;

    public ViewOption(string itmLabel, OptionType itmType, string itmValue)
    {
      ItmLabel = itmLabel;
      ItmType = itmType;
      ItmValue = itmValue;
    }
  }

  public interface IView 
  {
    public List<ViewOption> Options { get; }

    public void EditInputField(int index);
    public void EditPasswordField(int index);

    string? ExecuteOption(int index);

    public string GetAppHeader();
    public void PrintAppHeader();
  }
}