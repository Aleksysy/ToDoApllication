using System;
using ToDoApplication.Classes.Views;

namespace ToDoApplication.Classes.Controllers
{
  class DisplayController
  {
    public void UpdateDisplay(string viewName)
    {
      Console.CursorVisible = false;
      string[] selectOptions = [];
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

      selectOptions = currentView.SelectOptions;

      while (selecting)
      {
        Console.Clear();

        AppHeader appHeader = new AppHeader();
        appHeader.PrintAppHeader();

        for (int i = 0; i < selectOptions.Length; i++)
        {
          if (i == selectIndex)
          {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{selectOptions[i]}*");
            Console.ResetColor();
          }
          else
          {
            Console.WriteLine(selectOptions[i]);
          }
        }  

        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
      
        switch (keyInfo.Key)
        {
          case ConsoleKey.DownArrow:
            selectIndex++;
            if (selectIndex >= selectOptions.Length) selectIndex = 0;
            break;
          case ConsoleKey.UpArrow:
            selectIndex--;
            if (selectIndex < 0) selectIndex = selectOptions.Length - 1;
            break;
          case ConsoleKey.Enter:
            selecting = false;
            break;
        }
      }

      currentView.ExecuteOption(selectIndex);
    }
  }
}