using System;
using System.Collections.Generic;


static class View
{
    // Getting the input.
    public static string[] Input(string prompt="")
    {
        Console.Write($"{prompt}>");
        return Console.ReadLine().Split(' ');
    }

    // Invalid input scenarios.
    public static void DisplayNoInput()
    {
        Console.WriteLine($"No input made. Please type a command.");
    }
    public static void DisplayUnknownInput(string inputToken)
    {
        Console.WriteLine($"'{inputToken}' is not defined. Please type a command.");
    }

    // Taking item outcomes.
    public static void DisplayTakeItemFailed(string name) { Console.WriteLine($"There is no {name} in basket. Could not take any."); }
    public static void DisplayTakeItemSucceeded(string name) { Console.WriteLine($"Took {name} from basket."); }
    public static void DisplayTakeItemUnspecified() { Console.WriteLine($"Could not take item from basket. Item name not specified."); }
    
    // Adding item outcomes. (No scenarios of failure exists)
    public static void DisplayAddItemFailed(string name) { Console.WriteLine($"Cannot add not add {name} to basket."); }
    public static void DisplayAddItemSucceeded(string name) { Console.WriteLine($"Added {name} to basket."); }
    public static void DisplayAddItemUnspecified() { Console.WriteLine($"Cannot add item to basket. Item name not specified."); }
    
    // Displays all commands in Controller.
    public static void DisplayHelp(Dictionary<string, string> inputDescriptions)
    {
        Console.WriteLine("You have a basket of apples and bananas (initially starting with 2 and 3 respectively).");
        Console.WriteLine("You can add items or take them from the basket.");
        Console.WriteLine("Commands:");
        foreach(KeyValuePair<string, string> entry in inputDescriptions)
            Console.WriteLine($"{entry.Key, -12} - {entry.Value, -80}");
    }

    // Displays all items in the basket.
    public static void DisplayShowBasket(Dictionary<string, int> basket)
    {
        Console.WriteLine("Basket contents:");
        foreach(KeyValuePair<string, int> entry in basket)
            Console.WriteLine($"{entry.Key, -8} - {entry.Value, -8}");
    }

}