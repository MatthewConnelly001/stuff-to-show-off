using System;
using System.Collections.Generic;


public class PaymentMenu : Menu
{
    // Coin data: array of tuples (value, name, validity)
    public static (Decimal value, String name, bool isValid)[] coins = new (Decimal value, String name, bool isValid)[] 
    {
        (2.00m, "$2", true), 
        (1.00m, "$1", true),
        (0.50m, "50¢", true),
        (0.20m, "20¢", true),
        (0.10m, "10¢", true),
        (0.05m, "5¢", true),
        (0.02m, "2¢", false),
        (0.01m, "1¢", false),
    };

    
    private Decimal valueInserted = 0.00m;
    private Decimal valueRequired = 0.00m;// coffees[coffeeId].Value
    private String coffeeName = "";

    public PaymentMenu(Decimal _valueRequired, String _coffeeName)
    {
        valueRequired = _valueRequired;
        coffeeName = _coffeeName;
    }
    

    public override void DisplayTitle() 
    {
        Console.WriteLine($"{coffeeName} requested. Cost: ${valueRequired}");
        Console.WriteLine("Type a number to insert a coin:");
        for (int i = 0; i < coins.Length; i++) 
        {
            Console.WriteLine($"{i+1}) {coins[i].name}");
        }
    }


    public override bool ApplyInput(String input)
    {
        // input (-1) is a valid index of coins array indicating which is inserted.
        if (int.TryParse(input, out int i) && 1 <= i && i <= coins.Length)
        {
            // Checking that coin is valid.
            if (coins[i-1].isValid)
            {
                valueInserted += coins[i-1].value;
                Console.WriteLine($"{coins[i-1].name} inserted. Value paid: ${valueInserted}/${valueRequired}");

                // checking and displaying value.
                if (valueRequired <= valueInserted)
                {
                    Console.WriteLine($"{coffeeName} purchased!");
                    dispenceChange(valueInserted - valueRequired);
                    Program.currentMenu = new SelectionMenu();
                    return true;
                }
            }
            // Coin is invalid.
            else
            {
                Console.WriteLine($"Coin rejected. {coins[i-1].name} returned.");
            }
        }
        // Leaving the menu, returning coins inserted.
        else if (input == Program.exitInput)
        {
            Console.WriteLine($"Payment cancelled.");
            dispenceChange(valueInserted);
            Program.currentMenu = new SelectionMenu();
            return true;
        }
        // invalid input.
        else
        {
            Console.WriteLine($"Invalid input. Please type a number or '{Program.exitInput}' to leave this menu.");
        }
        // Do not leave menu by default.
        return false;
    }

    // Calculates and states change returned in coins.
    private void dispenceChange(Decimal changeRequired) 
    {
        Decimal changeDispenced = 0.00m;
        List<String> changeCoins = new List<string>();

        // looping each coin type
        foreach ((Decimal value, String name, bool isValid) coin in coins) 
        {
            while (changeDispenced + coin.value <= changeRequired)
            {
                changeDispenced += coin.value;
                changeCoins.Add(coin.name);
            }
            if (changeDispenced == changeRequired )
            {
                break;
            }
        }

        // Calculate coins...
         Console.WriteLine($"Change: {string.Join(", ", changeCoins)}");
    }
}