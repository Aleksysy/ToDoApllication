using System;
using ToDoApplication.Classes.Controllers;
using ToDoApplication.Data;

namespace ToDoApplication
{
  class Program
  {
    static void Main(string[] args)
    {
      DisplayController displayController = new DisplayController();
      displayController.UpdateDisplay("home");
    }
  }
}