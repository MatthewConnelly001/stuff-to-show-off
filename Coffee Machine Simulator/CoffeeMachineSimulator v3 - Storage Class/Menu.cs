using System;
using System.Collections.Generic;


public abstract class Menu
{
    protected const string exitInput = "exit";

    public abstract void DisplayTitle();
    public abstract bool ApplyInput(String input); // Returns true if menu must change or exiting.
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