using System;

class GroceryStore : CPurchase
{
    private Discount discountHelper = new Discount();

    public override void LoadDefaultItems()
    {
        AddItem("Milk (2L)", 45.99);
        AddItem("Bread", 22.50);
        AddItem("Eggs (12)", 59.99);
        AddItem("Butter (500g)", 89.99);
        AddItem("Sugar (2kg)", 49.99);
        AddItem("Rice (5kg)", 119.99);
        AddItem("Chicken Breast", 189.99);
        AddItem("Beef Mince (1kg)", 159.99);
        AddItem("Apples (1kg)", 39.99);
        AddItem("Cheese (400g)", 109.99);
        AddItem("Yoghurt (1L)", 59.99);
        AddItem("Orange Juice", 49.99);
        AddItem("Pasta (500g)", 29.99);
        AddItem("Tomato Sauce", 34.99);
        AddItem("Cooking Oil (2L)", 89.99);
    }

    public override void Checkout()
    {
        DisplayCart();

        if (cartCount == 0)
        {
            Console.WriteLine("Your cart is empty. Nothing to checkout.\n");
            return;
        }

        double rawTotal = CalculateTotal();
        double discountAmt = discountHelper.GetDiscount(rawTotal);
        double finalTotal = rawTotal - discountAmt;

        Console.WriteLine("==================================================");
        Console.WriteLine($"Subtotal          :  R{rawTotal,10:F2}");

        discountHelper.PrintDiscountInfo(rawTotal);

        if (discountAmt > 0)
        {
            Console.WriteLine($"Final Total       :  R{finalTotal,10:F2}");
        }
        else
        {
            Console.WriteLine($"Total             :  R{rawTotal,10:F2}");
        }

        Console.WriteLine("==================================================");
        Console.WriteLine("\nThank you for shopping with us!\n");
    }
}
