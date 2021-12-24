using System;
using System.Collections.Generic;


static class Program
{
    public static Menu currentMenu = new SelectionMenu();

    static void Main()
    {
        currentMenu.DisplayTitle();
        currentMenu.InputLoop();
    }
}