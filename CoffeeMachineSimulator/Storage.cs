using System;
using System.Collections.Generic;


static class Storage
{
    // Coffee data. Transactable field is never used.
    public static List<StorageItem> coffees = new List<StorageItem>()
    {
        new StorageItem("Latte", 3.00m, 2, true),
        new StorageItem("Cappuccino", 3.50m, 2, true),
        new StorageItem("Decaf", 4.00m, 2, true)
    };

    // Coin data. NOTE: Order will affect priority of DispenseCoins method.
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


    // Attempts to purchase a coin with the user's balance value.
    public static void Purchase(int coffeeIndex)
    {
        // coffee not available.
        if (coffees[coffeeIndex].quantity <= 0)
        {
            Console.WriteLine($"Cannot purchase {coffees[coffeeIndex].name}. Out of stock.");
            return;
        }

        // insufficient funds.
        if (coffees[coffeeIndex].value > balanceValue)
        {
            Console.WriteLine($"Cannot purchase {coffees[coffeeIndex].name}. Insufficent balance.");
            return;
        }
        
        // Purchase successful.
        Console.WriteLine($"Purchased {coffees[coffeeIndex].name} for ${coffees[coffeeIndex].value}");
        coffees[coffeeIndex].quantity -= 1;
        balanceValue -= coffees[coffeeIndex].value;
        
        // Returning balance to user.
        if (balanceValue > 0.00m)
        {
            Console.WriteLine($"Change: ${balanceValue}");
            DispenseCoins(balanceValue);
        }
    }

    // Adds a coin to storage and adds it's value to user's balance.
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

        // looping each coin type. NOTE: It is assumed (though not necessary) coins list is sorted highest to lowest.
        foreach (StorageItem coinType in coins) 
        {
            // NOTE: It is possible to calculate number of coins without a while loop.
            while (valueDispenced + coinType.value <= valueRequired && coinType.quantity > 0)
            {
                valueDispenced += coinType.value;
                coinType.quantity -= 1;
                coinsList.Add(coinType.name);
            }
            if (valueDispenced == valueRequired)
            {
                Console.WriteLine($"Dispensed ${valueDispenced}: {string.Join(", ", coinsList)}");
                balanceValue -= valueDispenced;
                return;
            }
        }
        // All coins were iterated: either value insufficient or exact coin value unattainable.
        Console.WriteLine($"Insufficient coins stored. Dispensed ${valueDispenced}: {string.Join(", ", coinsList)}");
        balanceValue -= valueDispenced;
        Console.WriteLine($"New balance: ${balanceValue}");
    }


    // Displays all storage information.
    public static void ShowInfo()
    {
        Console.WriteLine($"STORAGE INFORMATION");
        Console.WriteLine($"User balance: ${Storage.balanceValue}");
        
        foreach (StorageItem coffee in coffees)
        {
             Console.WriteLine(String.Format(
                 "| {0,10} | Price: {1,5} | Stock: {2,5} |",
                 coffee.name, 
                 coffee.value,
                 coffee.quantity));
        }
        foreach (StorageItem coinType in coins)
        {
             Console.WriteLine(String.Format(
                 "| {0,10} | Value: {1,5} | Stock: {2,5} | Accepted: {3,5} |",
                 coinType.name,
                 coinType.value,
                 coinType.quantity,
                 coinType.transactable));
        }
    }
}