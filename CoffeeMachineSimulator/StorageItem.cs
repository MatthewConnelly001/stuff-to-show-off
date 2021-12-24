using System;
using System.Collections.Generic;


public class StorageItem
{
    public String name;
    public Decimal value;
    public int quantity;
    public bool transactable;

    public StorageItem(String name, Decimal value, int quantity, bool transactable) 
    {
        this.name = name;
        this.value = value;
        this.quantity = quantity;
        this.transactable = transactable;
    }
}