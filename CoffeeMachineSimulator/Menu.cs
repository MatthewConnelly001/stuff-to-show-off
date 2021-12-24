using System;
using System.Collections.Generic;


public abstract class Menu
{
    // exit input is always "exit" across all menus.
    protected const string exitInput = "exit";

    // Displays the title of the menu.
    public abstract void DisplayTitle();
    
    // Used in Input loop. Returns true to leave input loop.
    public abstract bool ApplyInput(String input); 
    
    // Loops all user input commands until ApplyInput returns false.
    public virtual void InputLoop()
    {
        bool breakLoop = false;
        while(!breakLoop)
        {
            Console.Write(">");
            breakLoop = ApplyInput(Console.ReadLine().ToLower());
        }
    }
}