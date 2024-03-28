using System;
using System.Collections.Generic;
using System.Linq;

public class Item
{
    public string Name { get; }
    public int Quantity { get; private set; }
    public DateTime CreatedDate { get; private set; }

    public Item(string name, int quantity, DateTime createdDate = default)
    {
        if (quantity < 0)
        {
            Console.WriteLine("quantity should be positive");
        }
        Name = name;
        Quantity = quantity;
        CreatedDate = createdDate == default ? DateTime.Now : createdDate;
    }

    public override string ToString()
    {
        return ($"Item Name: {Name} \t|\t Quantity: {Quantity} \t|\t Created Date: {CreatedDate}"
        + "\n-------------------------------------------------------------------------------------------- \n");
    }
}