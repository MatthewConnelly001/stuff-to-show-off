using System;
using System.Collections.Generic;


static class Program
{
    public const string exitInput = "exit";
    public static Menu? currentMenu = new SelectionMenu();


    static void Main()
    {
        while(currentMenu != null)
        {
            currentMenu.DisplayTitle();
            currentMenu.InputLoop();
        }
    }
}