using System;

namespace ToDoApllication.Classes.Views
{
  class ContentDisplay
  {
    public static void PrintAppHeader()
    {
      Console.WriteLine("Welcome to ToDoApplication CLI\n");
      Console.WriteLine("Use up/down keys to navigate and enter to select:\n\n");
    }

    public static void PrintOptions()
    {
      Console.CursorVisible = false;

      string[] selectOptions = {"Login", "Register", "Close"};
      int selectIndex = 0;

      bool selecting = true;

      while (selecting)
      {
        Console.Clear();

        PrintAppHeader();

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
            Console.CursorVisible = true;
            Environment.Exit(0);
            break;
        }
      }

      Console.CursorVisible = true;
      Console.Clear();
      Console.WriteLine($"You have selected {selectOptions[selectIndex]}");
      Console.WriteLine("\nPress any key to exit...");
      Console.ReadKey();
    }
  }
}