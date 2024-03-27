﻿using System;

class Item
{
    public string? Name { get; }
    private int Quantity { get; private set; }
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
        return $"Item Name: {Name}, Quantity: {Quantity}, Created Date: {CreatedDate}";
    }

}

public class Store
{
    private List<Item> items = new List<Item>();
    private int maximumCapacity;
    public Store(int maximumCapacity){
        this.maximumCapacity = maximumCapacity;
    }

    public void AddItem (Item item){
        if (GetCurrentVolume() + item.Quantity > maximumCapacity)
        {
            Console.WriteLine("By adding this item you Exceed the capacity of the store");
            return;
        }
        bool isItemExist = items.Any((i) => i.Name == item.Name);
        if (isItemExist)
        {
            Console.WriteLine("this item is already exists.");
            return;
        }
        items.Add(item);
        Console.WriteLine("item added successfully");
    }

    public void printItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine($"{item}");
        }
    }
    public void DeleteItem(string itemName)
    {
        Item? itemToBeDeleted = items.FirstOrDefault(i => i.Name == itemName);
        if (itemToBeDeleted != null)
        {
            items.Remove(itemToBeDeleted);
            Console.WriteLine("item Deleted successfully");
        }
        else
        {
            Console.WriteLine("item was not found");
        }
    }

    public int GetCurrentVolume(){
        return items.Sum(items => item.Quantity);
    }

    public Item FindItemByName(string itemName){
        return items.FirstOrDefault(i => i.Name == itemName);
    }

    public List<Item> SortByNameAsc(){
        return items.OrderBy(i => i.Name).ToList();
    }
    public IEnumerable<Item> SortByDate(SortOrder sortOrder)
    {
        if (sortOrder == SortOrder.ASC)
        {
            return items.OrderBy(item => item.CreatedDate);
        }else{
            return items.OrderByDescending(item => item.CreatedDate);
        }
    }
    public enum SortOrder {
        ASC,
        DESC
    }

}


class Program
{
    public static void Main(string[] args)
    {
        // items example - You do not need to follow exactly the same
        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
        var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
        var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
        var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
        var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
        var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));
        var coffee = new Item("Coffee", 20);
        var sandwich = new Item("Sandwich", 15);
        var batteries = new Item("Batteries", 10);
        var umbrella = new Item("Umbrella", 5);
        var sunscreen = new Item("Sunscreen", 8);
        Console.WriteLine($"{waterBottle} \n{chocolateBar} \n{notebook} \n{pen} \n{coffee} \n{sunscreen}");
    }
}
