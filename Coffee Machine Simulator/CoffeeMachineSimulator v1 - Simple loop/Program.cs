using System;
using System.Collections.Generic;


static class Program
{
    // Coin data: array of tuples (value, name, validity)
    static (Decimal Value, String Name, bool IsValid)[] coins = new (Decimal Value, String Name, bool IsValid)[] {
       
        (2.00m, "$2", true), 
        (1.00m, "$1", true),
        (0.50m, "50¢", true),
        (0.20m, "20¢", true),
        (0.10m, "10¢", true),
        (0.05m, "5¢", true),
        (0.02m, "2¢", false),
        (0.01m, "1¢", false),
    };

    // Coffee data: array of tuples (cost, name)
    static (Decimal Value, String Name)[] coffees = new (Decimal Value, String Name)[] {
        (3.00m, "Latte"),
        (3.50m, "Cappuccino"),
        (4.00m, "Decaf"),
    };

    const string exitInput = "exit";


    static void Main()
    {
        MenuLoop();
    }


    static void MenuLoop() 
    {
        int? coffeeId = 0;
        while(coffeeId != null)
        {
            coffeeId = SelectCoffee();
            if (coffeeId != null)
            {
                Decimal? change = InsertCoins((int)coffeeId);
                if (change != null)
                {
                    dispenceChange((Decimal)change);
                }
            }
        }
    }


    // Selects a coffee. Returns coffee index or null if none selected.
    static int? SelectCoffee()
    {
        // displaying menu information. 
        Console.WriteLine("Select a coffee:");
        for (int i=0; i<coffees.Length; i++) 
            Console.WriteLine($"{i+1}) ${coffees[i].Value} - {coffees[i].Name}");

        // input loop.
        String input = "";
        while(input != exitInput)
        {
            Console.Write(">");
            input = Console.ReadLine().ToLower();

            // Attempt to convert input to an index of coffees array.
            if (int.TryParse(input, out int i) && 0 < i && i <= coffees.Length)
            {
                return i - 1; // Decrementing id to match index from input values starting at 1.
            }
            else if (input != exitInput)
            {
                Console.WriteLine($"Invalid input. Please type a number or '{exitInput}' to leave this menu.");
            }
        }
        return null;
    }


    // Allows user to insert coins. Returns change or null if price not met.
    static Decimal? InsertCoins(int coffeeId)
    {
        Decimal valueInserted = 0.00m;
        Decimal valueRequired = coffees[coffeeId].Value;
        
        // Displaying menu information.
        Console.WriteLine($"{coffees[coffeeId].Name} requested. Cost: ${valueRequired}");
        Console.WriteLine("Type a number to insert a coin:");
        for (int i=0; i<coins.Length; i++) 
            Console.WriteLine($"{i+1}) {coins[i].Name}");

        // Input loop.
        String input = "";
        while(input != exitInput)
        {
            // inputing selection.
            Console.Write($"${valueInserted}/${valueRequired}>");
            input = Console.ReadLine().ToLower();

            // Attempt to convert input to an index of coins array.
            if (int.TryParse(input, out int i) && 1 <= i && i <= coins.Length)
            {
                i -= 1; // Decrementing id to match index from input values starting at 1.

                // Coin is inserted, adding to valueInserted if valid.
                if (coins[i].Item3)
                {
                    valueInserted += coins[i].Value;
                    Console.WriteLine($"{coins[i].Name} inserted");
                    
                    // checking and displaying value.
                    if (valueRequired <= valueInserted)
                    {
                        Console.WriteLine($"{coffees[coffeeId].Name} purchased!");
                        return Math.Abs(valueInserted - valueRequired);
                    }
                }
                else 
                {
                    Console.WriteLine($"Coin rejected. {coins[i].Name} is not accepted.");
                }
            }
            else if (input != exitInput)
            {
                Console.WriteLine($"Invalid input. Please type a number or '{exitInput}' to leave this menu.");
            }
        }

        return null;
    }


    // Calculates and states change returned in coins.
    static void dispenceChange(Decimal valueRequired) 
    {
        Decimal valueDispenced = 0.00m;
        List<String> changeCoins = new List<string>();

        // looping each coin type
        foreach ((Decimal Value, String Name, bool IsValid) coin in coins) 
        {
            while (valueDispenced + coin.Value <= valueRequired)
            {
                valueDispenced += coin.Value;
                changeCoins.Add(coin.Name);
            }
            if (valueDispenced == valueRequired )
            {
                break;
            }
        }

        // Calculate coins...
         Console.WriteLine($"Change: {string.Join(", ", changeCoins)}");
    }
}