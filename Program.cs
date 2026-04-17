using System;

class Program
{
    static GroceryStore store = new GroceryStore();

    static void Main(string[] args)
    {
        Console.WriteLine("SPAZA DELUX");
        Console.WriteLine("==========");

        // Load all grocery items into the arrays
        store.LoadDefaultItems();

        bool running = true;

        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine().Trim();

            switch (choice)
            {
                case "1":
                    store.DisplayItems();
                    break;

                case "2":
                    BuyGroceries();
                    break;

                case "3":
                    store.DisplayCart();
                    break;

                case "4":
                    store.Checkout();
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("\n  Goodbye! 👋\n");
                    break;

                default:
                    Console.WriteLine("  ✘  Invalid option. Please choose 1-5.\n");
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\nMAIN MENU");
        Console.WriteLine("=========");
        Console.WriteLine("1. View all groceries");
        Console.WriteLine("2. Buy groceries");
        Console.WriteLine("3. View my cart");
        Console.WriteLine("4. Checkout");
        Console.WriteLine("5. Exit");
        Console.Write("Enter choice: ");
    }

    // Handle the buying process
    static void BuyGroceries()
    {
        store.DisplayItems();
        bool shopping = true;

        while (shopping)
        {
            Console.Write("Enter item name to buy (or 'done' to stop): ");
            string name = Console.ReadLine()?.Trim();

            if (name.Equals("done", StringComparison.OrdinalIgnoreCase))
            {
                shopping = false;
                break;
            }

            if (!store.ItemExists(name))
            {
                Console.WriteLine($"'{name}' not found. Please check the name and try again.\n");
                continue;
            }

            Console.Write($"How many '{name}' would you like? ");
            string qtyInput = Console.ReadLine()?.Trim();

            if (int.TryParse(qtyInput, out int qty) && qty > 0)
            {
                store.AddToCart(name, qty);
            }
            else
            {
                Console.WriteLine("Invalid quantity. Please enter a positive whole number.\n");
            }

            Console.WriteLine();
        }
    }
}