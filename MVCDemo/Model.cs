using System;
using System.Collections.Generic;


static class Model
{
    public static Dictionary<string, int> basket = new Dictionary<string, int>{
        {"apple", 2},
        {"banana", 3}
    };


    public static void TakeItem(string? name) {
        
        // Item name is not specified.
        if (name == null)
        {
            View.DisplayTakeItemUnspecified();
            return;
        }

        // Item does not exist, cannot take it.
        if (!basket.ContainsKey(name) || basket[name] <= 0)
        {
            View.DisplayTakeItemFailed(name);
            return;
        }

        // The item exists, take it.
        basket[name] -= 1;
        View.DisplayTakeItemSucceeded(name);
    }

    public static void AddItem(string? name) {
        
        // Item name is not specified.
        if (name == null)
        {
            View.DisplayAddItemUnspecified();
            return;
        }

        // Adding item to dict if not listed.
        if (!basket.ContainsKey(name)) basket.Add(name, 0);

        // Incrementing quantity of that item.
        basket[name] += 1;
        View.DisplayAddItemSucceeded(name);
        return;
    }
}