using System;

class Item
{
    public string Name { get; }
    private int Quantity { get; set; }
    private DateTime CreatedDate { get; set; }

    public Item(string name, int quantity, DateTime createdDate){
        if (quantity < 0)
        {
            Console.WriteLine("quantity should be positive");
        }
        Name = name;
        Quantity = quantity;
        CreatedDate = createdDate;
    }

}
