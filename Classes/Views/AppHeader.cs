using System;

namespace ToDoApplication.Classes.Views
{
  class AppHeader
  {
    public string GetAppHeader()
    {
      return "Welcome to ToDoApplication CLI\n" +
             "Use up/down keys to navigate and enter to select:\n\n";
    }

    public void PrintAppHeader()
    {
      Console.WriteLine(GetAppHeader());
    }
  }
}