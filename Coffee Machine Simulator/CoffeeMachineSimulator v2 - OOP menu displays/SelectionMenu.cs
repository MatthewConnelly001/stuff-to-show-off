using System;
using System.Collections.Generic;


public class SelectionMenu : Menu
{
    // Coffee data: array of tuples (cost, name)
    public static (Decimal price, String name)[] coffees = new (Decimal price, String name)[] 
    {
        (3.00m, "Latte"),
        (3.50m, "Cappuccino"),
        (4.00m, "Decaf"),
    };

    public override void DisplayTitle() 
    {
        // displaying menu information. 
        Console.WriteLine("Select a coffee:");
        for (int i = 0; i < coffees.Length; i++)
        {
            Console.WriteLine($"{i+1}) ${coffees[i].price} - {coffees[i].name}");
        }
    }
    
    public override bool ApplyInput(String input)
    {
        // Input (-1) is a valid index indicating which coffee is selected.
        if (int.TryParse(input, out int i) && 0 < i && i <= coffees.Length)
        {
            Program.currentMenu = new PaymentMenu(coffees[i-1].price, coffees[i-1].name);
            return true;
        }
        // Exiting the program.
        else if (input == Program.exitInput)
        {
            Program.currentMenu = null;
            return true;
        }
        // Unknown input.
        else 
        {
            Console.WriteLine($"Invalid input. Please type a number or '{Program.exitInput}' to leave this menu.");
        }
        // Do not leave menu by default.
        return false; 
    }
}