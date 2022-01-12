using System;
using System.Collections.Generic;


public class SelectionMenu : Menu
{
    private readonly String[] coffeeInputs = {"z", "x", "c"};
    private readonly String[] coinInputs = {"1", "2", "3", "4", "5", "6", "7", "8"};
    private const String addBalanceInput = "set";
    private const String returnInput = "return";
    private const String infoInput = "info";
    private const String menuInput = "menu";

    public override void DisplayTitle() 
    {
        Console.WriteLine("COFFEE MACHINE");

        // displaying menu information. 
        for (int i = 0; i < coffeeInputs.Length; i++)
        {
            Console.WriteLine($"{coffeeInputs[i]})\tPurchase {Storage.coffees[i].name} (${Storage.coffees[i].value})");
        }
        // Coins to insert.
        for (int i = 0; i < coinInputs.Length; i++)
        {
            Console.WriteLine($"{coinInputs[i]})\tInsert {Storage.coins[i].name}");
        }
        
        Console.WriteLine($"{returnInput})\tReturn coins");
        Console.WriteLine($"{addBalanceInput})\tSet custom balance");
        Console.WriteLine($"{menuInput})\tRedisplay menu");
        Console.WriteLine($"{infoInput})\tShow storage info");
        Console.WriteLine($"{exitInput})\tExit program");
    }

    
    public override bool ApplyInput(String input)
    {
        switch (input)
        {
            // Leaving the program.
            case exitInput:
                Console.WriteLine($"Closing program.");
                Program.currentMenu = null;
                return true;
            // Returning coins.
            case returnInput:
                Console.WriteLine($"Returning balance: ${Storage.balanceValue}");
                Storage.DispenseCoins(Storage.balanceValue);
                return false;
            // Adding a custom value to the user's balance.
            case addBalanceInput:
                Console.Write("Balance value>");
                if (Decimal.TryParse(Console.ReadLine(), out Decimal val))
                {
                    Storage.balanceValue = val;
                }
                return false;
            // Redisplaying the title of the menu (by breaking the input loop).
            case menuInput:
                DisplayTitle();
                return false;
            // Showing storage information.
            case infoInput:
                Storage.ShowInfo();
                return false;
        }

        // trying to purchase a coffee.
        int coffeeIndex = Array.IndexOf(coffeeInputs, input);
        if (coffeeIndex > -1)
        {
            Storage.Purchase(coffeeIndex);
            return false;
        }

        // trying to insert a coin.
        int coinIndex = Array.IndexOf(coinInputs, input);
        if (coinIndex > -1)
        {
            Storage.InsertCoin(coinIndex);
            return false;
        }

        // Unknown input.
        Console.WriteLine($"Invalid input. Please type a number or '{exitInput}' to leave this menu.");
        return false; 
    }
}