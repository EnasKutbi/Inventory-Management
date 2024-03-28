using System;
using System.Collections.Generic;
using System.Linq;

public class Store
{
    private List<Item> items = new List<Item>();
    private int maximumCapacity;
    public Store(int maximumCapacity)
    {
        this.maximumCapacity = maximumCapacity;
    }

    public void AddItem(Item item)
    {
        if (GetCurrentVolume() + item.Quantity > maximumCapacity)
        {
            Console.WriteLine("By adding this item you exceed the capacity of the store");
            return;
        }

        bool isItemExist = items.Any(i => i.Name == item.Name);
        if (isItemExist)
        {
            Console.WriteLine("This item already exists.");
            return;
        }

        items.Add(item);
        Console.WriteLine("Item added successfully");
    }

    public void PrintItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine($"{item}");
        }
    }

    public void DeleteItem(string itemName)
    {
        Item itemToBeDeleted = items.FirstOrDefault(i => i.Name == itemName);
        if (itemToBeDeleted != null)
        {
            items.Remove(itemToBeDeleted);
            Console.WriteLine("Item deleted successfully");
        }
        else
        {
            Console.WriteLine("Item was not found");
        }
    }

    public int GetCurrentVolume()
    {
        return items.Sum(item => item.Quantity);
    }

    public Item FindItemByName(string itemName)
    {
        return items.FirstOrDefault(i => i.Name == itemName);
    }

    public List<Item> SortByNameAsc()
    {
        return items.OrderBy(i => i.Name).ToList();
    }

    public IEnumerable<Item> SortByDate(SortOrder sortOrder)
    {
        if (sortOrder == SortOrder.ASC)
        {
            return items.OrderBy(item => item.CreatedDate);
        }
        else
        {
            return items.OrderByDescending(item => item.CreatedDate);
        }
    }
    public enum SortOrder
    {
        ASC,
        DESC
    }

    public Dictionary<string, List<Item>> GroupByDate()
    {
        Dictionary<string, List<Item>> groupedItems = new Dictionary<string, List<Item>>();
        List<Item> old = new List<Item>();
        List<Item> newArrival = new List<Item>();
        foreach (Item item in items)
        {
            if (item.CreatedDate >= DateTime.Now.AddMonths(-3))
            {
                newArrival.Add(item);
            }
            else
            {
                old.Add(item);
            }
        }
        groupedItems.Add("New Arrival", newArrival);
        groupedItems.Add("Old", old);

        return groupedItems;
    }
}
