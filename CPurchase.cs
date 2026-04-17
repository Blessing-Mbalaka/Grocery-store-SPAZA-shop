using System;

abstract class CPurchase : GItems
{
    protected string[] cartNames = new string[50];
    protected int[] cartQty = new int[50];
    protected double[] cartSubtotals = new double[50];
    protected int cartCount = 0;

    public void AddToCart(string name, int qty)
    {
        double price = FindPrice(name);

        if (price == -1)
        {
            Console.WriteLine($"'{name}' was not found in the grocery list.");
            return;
        }

        for (int i = 0; i < cartCount; i++)
        {
            if (cartNames[i].Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                cartQty[i] += qty;
                cartSubtotals[i] = cartQty[i] * price;
                Console.WriteLine($"Updated '{name}' — qty now {cartQty[i]}");
                return;
            }
        }

        if (cartCount < 50)
        {
            cartNames[cartCount] = name;
            cartQty[cartCount] = qty;
            cartSubtotals[cartCount] = qty * price;
            cartCount++;
            Console.WriteLine($"Added {qty}x '{name}' to cart  (R{price} each)");
        }
        else
        {
            Console.WriteLine("Cart is full.");
        }
    }

    public double CalculateTotal()
    {
        double total = 0;
        for (int i = 0; i < cartCount; i++)
        {
            total += cartSubtotals[i];
        }
        return total;
    }

    public void DisplayCart()
    {
        Console.WriteLine("\nYOUR CART");
        Console.WriteLine("=========");

        if (cartCount == 0)
        {
            Console.WriteLine("Cart is empty.");
        }
        else
        {
            for (int i = 0; i < cartCount; i++)
            {
                Console.WriteLine($"{cartNames[i],-20} x{cartQty[i],-4}  R{cartSubtotals[i],8}");
            }
        }

        Console.WriteLine();
    }

    public abstract void Checkout();
}
