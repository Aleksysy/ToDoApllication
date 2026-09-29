using System;
using ToDoApplication.Classes.Views;

namespace ToDoApplication.Classes.Controllers
{
  class DisplayController
  {
    public void UpdateDisplay(string viewName)
    {
      Console.CursorVisible = false;
      List<ViewOption> selectOptions;
      int selectIndex = 0;
      bool selecting = true;

      IView currentView = new Home();

      switch (viewName)
      {
        case "home":
          currentView = new Home();
          break;
        case "login":
          currentView = new Login();
          break;
        case "register":
          currentView = new Register();
          break;
      }

      selectOptions = currentView.Options;

      while (selecting)
      {
        Console.Clear();

        currentView.PrintAppHeader();

        for (int i = 0; i < selectOptions.Count; i++)
        {
          if (i == selectIndex)
          {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{selectOptions[i].ItmLabel}*");
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
            else
            {
              selecting = false;
            }

            break;
        }
      }

      currentView.ExecuteOption(selectIndex);
    }

    public static void QuitApp()
    {
      Console.Clear();
      Console.CursorVisible = true;
      
      Environment.Exit(0);
    }
  }
}