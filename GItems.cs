using System;

abstract class GItems
{
    protected string[] itemNames = new string[20];
    protected double[] itemPrices = new double[20];
    protected int itemCount = 0;

    public void AddItem(string name, double price)
    {
        if (itemCount < 20)
        {
            itemNames[itemCount] = name;
            itemPrices[itemCount] = price;
            itemCount++;
            Console.WriteLine($"'{name}' added at R{price:F2}");
        }
        else
        {
            Console.WriteLine("Storage full – cannot add more items.");
        }
    }

    public void DisplayItems()
    {
        Console.WriteLine("\nAVAILABLE GROCERIES");
        Console.WriteLine("===================");

        if (itemCount == 0)
        {
            Console.WriteLine("No items available.");
        }
        else
        {
            for (int i = 0; i < itemCount; i++)
            {
                Console.WriteLine($"{i + 1,2}. {itemNames[i],-20} R{itemPrices[i],8:F2}");
            }
        }

        Console.WriteLine();
    }

    public double FindPrice(string name)
    {
        for (int i = 0; i < itemCount; i++)
        {
            if (itemNames[i].Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return itemPrices[i];
            }
        }
        return -1;
    }

    public bool ItemExists(string name)
    {
        return FindPrice(name) != -1;
    }

    public abstract void LoadDefaultItems();
}
