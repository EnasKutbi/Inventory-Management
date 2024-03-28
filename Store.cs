public class Store
{
    private List<Item> _items = new List<Item>();

    private int _maximumCapacity;

    public Store(int maximumCapacity)
    {
        _maximumCapacity = maximumCapacity;
    }

    public void AddItem(Item item)
    {
        if (GetCurrentVolume() + item.Quantity > _maximumCapacity)
        {
            Console.WriteLine("By adding this item you exceed the capacity of the store");
            return;
        }

        bool isItemExist = _items.Any(i => i.Name == item.Name);
        if (isItemExist)
        {
            Console.WriteLine("This item already exists.");
            return;
        }

        _items.Add(item);
        Console.WriteLine("Item added successfully");
    }

    public void PrintItems()
    {
        foreach (var item in _items)
        {
            Console.WriteLine($"{item}");
        }
    }

    public void DeleteItem(string itemName)
    {
        Item itemToBeDeleted = _items.FirstOrDefault(i => i.Name == itemName);
        if (itemToBeDeleted != null)
        {
            _items.Remove(itemToBeDeleted);
            Console.WriteLine("Item deleted successfully");
        }
        else
        {
            Console.WriteLine("Item was not found");
        }
    }

    public int GetCurrentVolume()
    {
        return _items.Sum(item => item.Quantity);
    }

    public Item FindItemByName(string itemName)
    {
        Item findItem = _items.FirstOrDefault(i => i.Name == itemName);
        if (findItem != null)
        {
            return findItem;
        }
        return null;
    }

    public List<Item> SortByNameAsc()
    {
        return _items.OrderBy(i => i.Name).ToList();
    }

    public IEnumerable<Item> SortByDate(SortOrder sortOrder)
    {
        if (sortOrder == SortOrder.ASC)
        {
            return _items.OrderBy(item => item.CreatedDate);
        }
        else
        {
            return _items.OrderByDescending(item => item.CreatedDate);
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
        foreach (Item item in _items)
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
