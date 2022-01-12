using System;
using System.Collections.Generic;


static class Storage
{
    // Coffee data: array of tuples (cost, name)
    public static List<StorageItem> coffees = new List<StorageItem>()
    {
        new StorageItem("Latte", 3.00m, 2, true),
        new StorageItem("Cappuccino", 3.50m, 2, true),
        new StorageItem("Decaf", 4.00m, 2, true)
    };

    // Coin data: array of tuples (value, name, validity)
    public static List<StorageItem> coins = new List<StorageItem>()
    {
        new StorageItem("$2", 2.00m, 2, true),
        new StorageItem("$1", 1.00m, 2, true),
        new StorageItem("50¢", 0.50m, 2, true),
        new StorageItem("20¢", 0.20m, 2, true),
        new StorageItem("10¢",0.10m, 2, true),
        new StorageItem("5¢", 0.05m, 2, true),
        new StorageItem("2¢", 0.02m, 2, false),
        new StorageItem("1¢", 0.01m, 2, false)
    };

    // Tracked value of coins inserted by user.
    public static Decimal balanceValue = 0.00m;


    // Attempts to purchase a coin with the value of coins inserted.
    public static void Purchase(int coffeeIndex)
    {
        // insufficient funds.
        if (coffees[coffeeIndex].value > balanceValue)
        {
            Console.WriteLine($"Cannot purchase {coffees[coffeeIndex].name}. Insufficent balance.");
            return;
        }
        
        // coffee not available.
        if (coffees[coffeeIndex].quantity <= 0)
        {
            Console.WriteLine($"Cannot purchase {coffees[coffeeIndex].name}. Out of stock.");
            return;
        }

        // Purchase successful.
        Console.WriteLine($"Purchased {coffees[coffeeIndex].name} for ${coffees[coffeeIndex].value}");
        coffees[coffeeIndex].quantity -= 1;

       // Change if price exceded.
       if (coffees[coffeeIndex].value < balanceValue)
       {
            Console.WriteLine($"Change: ${balanceValue - coffees[coffeeIndex].value}");
            DispenseCoins(balanceValue - coffees[coffeeIndex].value);
       }
    }


    public static void InsertCoin(int coinIndex)
    {
        if (coins[coinIndex].transactable)
        {
            balanceValue += coins[coinIndex].value;
            coins[coinIndex].quantity += 1;
            Console.WriteLine($"{coins[coinIndex].name} inserted. Current balance: ${balanceValue}");
        }
        else
        {
            Console.WriteLine($"{coins[coinIndex].name} is not accepted. Returned. Current balance: ${balanceValue}");
        }
    }

    // Calculates and states change returned in coins.
    public static void DispenseCoins(Decimal valueRequired) 
    {
        Decimal valueDispenced = 0.00m;
        List<String> coinsList = new List<string>();

        // looping each coin type. Sorted from highest to lowest is assumed.
        foreach (StorageItem coinType in coins) 
        {
            while (valueDispenced + coinType.value <= valueRequired && coinType.quantity > 0)
            {
                valueDispenced += coinType.value;
                coinType.quantity -= 1;
                coinsList.Add(coinType.name);
            }
            if (valueDispenced == valueRequired)
            {
                Console.WriteLine($"Dispensed: {string.Join(", ", coinsList)}");
                balanceValue -= valueDispenced;
                return;
            }
        }
        Console.WriteLine($"Insufficient coins stored. Dispensed: {string.Join(", ", coinsList)}");
        balanceValue -= valueDispenced;
        Console.WriteLine($"New balance: ${balanceValue}");
    }


    public static void ShowInfo()
    {
        Console.WriteLine($"STORAGE INFORMATION");
        Console.WriteLine($"User balance: ${Storage.balanceValue}");
        
        foreach (StorageItem coffee in coffees)
        {
             Console.WriteLine(String.Format(
                 "|{0,10}| Price:{1,10}| Stock:{2,10}|",
                 coffee.name, 
                 coffee.value,
                 coffee.quantity));
        }
        foreach (StorageItem coinType in coins)
        {
             Console.WriteLine(String.Format(
                 "|{0,10}| Value:{1,10}| Stock:{2,10}| Accepted:{3,10}|",
                 coinType.name,
                 coinType.value,
                 coinType.quantity,
                 coinType.transactable));
        }
    }
}