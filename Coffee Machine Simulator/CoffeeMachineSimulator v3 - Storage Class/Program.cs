using System;
using System.Collections.Generic;


static class Program
{
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