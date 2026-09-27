using System;
using ToDoApllication.Classes.Views;
using ToDoApplication.Data;

namespace ToDoApplication
{
  class Program
  {
    static void Main(string[] args)
    {
      using AppDbContext db = new AppDbContext();
      
      ContentDisplay.PrintOptions();
    }
  }
}