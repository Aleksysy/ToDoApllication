using System;
using ToDoApplication.Classes.Views;

namespace ToDoApplication.Classes.Controllers
{
  public class DisplayController
  {
    private AuthSession authSession = new AuthSession();

    public void UpdateDisplay(string viewName)
    {
      Console.CursorVisible = false;
      List<ViewOption> selectOptions;
      int selectIndex = 0;
      bool selecting = true;

      IView currentView = new Home(authSession);
      string? targetView = null;

      switch (viewName)
      {
        case "login":
          currentView = new Login(authSession);
          break;
        case "register":
          currentView = new Register(authSession);
          break;
        case "taskitems":
          currentView = new TaskItems(authSession);
          break;
      }

      selectOptions = currentView.Options;

      while (selecting)
      {
        Console.Clear();

        currentView.PrintAppHeader();

        for (int i = 0; i < selectOptions.Count; i++)
        {
          if (i > 0 && selectOptions[i - 1].ItmType != OptionType.Action &&
          selectOptions[i].ItmType == OptionType.Action) Console.WriteLine();

          if (i == selectIndex)
          {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{selectOptions[i].ItmLabel} <");
            Console.ResetColor();
          }
          else
          {
            Console.WriteLine(selectOptions[i].ItmLabel);
          }
        }  

        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
      
        switch (keyInfo.Key)
        {
          case ConsoleKey.DownArrow:
            selectIndex++;
            if (selectIndex >= selectOptions.Count) selectIndex = 0;
            break;
          case ConsoleKey.UpArrow:
            selectIndex--;
            if (selectIndex < 0) selectIndex = selectOptions.Count - 1;
            break;
          case ConsoleKey.Enter:
            if (selectOptions[selectIndex].ItmType == OptionType.Input)
            {
              currentView.EditInputField(selectIndex);
            }
            else if (selectOptions[selectIndex].ItmType == OptionType.Password)
            {
              currentView.EditPasswordField(selectIndex);
            }
            else if (selectOptions[selectIndex].ItmType == OptionType.Action)
            {
              targetView = currentView.ExecuteOption(selectIndex);
              selecting = targetView == null ? true : false;
            }
            else if (selectOptions[selectIndex].ItmType == OptionType.Back)
            {
              currentView.ExecuteOption(selectIndex);
              selecting = false;
            }

            break;
        }
      }

      if (targetView != null) UpdateDisplay(targetView);
      else UpdateDisplay("home");
    }

    public static void QuitApp()
    {
      Console.Clear();
      Console.CursorVisible = true;
      
      Environment.Exit(0);
    }
  }
}