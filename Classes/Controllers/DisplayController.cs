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
      int scrollOffset = 0;
      int visibleItems = Console.WindowHeight - 8;

      int selectIndex = 0;
      bool selecting = true;
      List<ViewOption> selectOptions;
      
      IView currentView = new Home(authSession);
      string? targetView = null;
      
      if (viewName.StartsWith("task:"))
      {
        string taskIdString = viewName.Substring(viewName.IndexOf(':') + 1);
        int taskId = Convert.ToInt32(taskIdString);

        currentView = new TaskView(authSession, taskId);
      }

      switch (viewName)
      {
        case "login":
          currentView = new Login(authSession);
          break;
        case "register":
          currentView = new Register(authSession);
          break;
        case "taskitems":
          selectIndex = 1;
          currentView = new TasksView(authSession);
          break;
      }

      selectOptions = currentView.Options;

      while (selecting)
      {
        Console.Clear();

        currentView.PrintAppHeader();

        int endIndex = Math.Min(
          scrollOffset + visibleItems, 
          currentView.Options.Count
        );

        for (int i = scrollOffset; i < endIndex; i++)
        {
          if (i > 0 && selectOptions[i - 1].ItmType != OptionType.Action &&
          selectOptions[i].ItmType == OptionType.Action) Console.WriteLine();

          if (i > 0 && selectOptions[i - 1].ItmType == OptionType.Action && 
          selectOptions[i - 1].ItmValue == "spaceb") Console.WriteLine();

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

            scrollOffset = GetScrollPos(selectIndex, scrollOffset, visibleItems);

            break;
          case ConsoleKey.UpArrow:
            selectIndex--;
            if (selectIndex < 0) selectIndex = selectOptions.Count - 1;

            scrollOffset = GetScrollPos(selectIndex, scrollOffset, visibleItems);
            
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
              targetView = currentView.ExecuteOption(selectIndex);
              selecting = false;
            }

            break;
        }
      }

      if (targetView != null) UpdateDisplay(targetView);
      else UpdateDisplay("home");
    }

    private int GetScrollPos(
      int selectedIndex,
      int currentOffset,
      int visibleItems
    )
    {
      if (selectedIndex < currentOffset) return selectedIndex;

      if (selectedIndex >= currentOffset + visibleItems) return selectedIndex - visibleItems + 1;

      return currentOffset;
    }

    public static void QuitApp()
    {
      Console.Clear();
      Console.CursorVisible = true;
      
      Environment.Exit(0);
    }
  }
}