using System;

sealed class Discount
{
    private const double DISCOUNT_THRESHOLD = 10000.00;
    private const double DISCOUNT_RATE = 0.10;

    public double GetDiscount(double total)
    {
        if (total > DISCOUNT_THRESHOLD)
        {
            return total * DISCOUNT_RATE;
        }
        return 0;
    }

    public void PrintDiscountInfo(double total)
    {
        double discountAmount = GetDiscount(total);

        if (discountAmount > 0)
        {
            Console.WriteLine($"\nGreat news! You qualify for a {DISCOUNT_RATE * 100:F0}% discount!");
            Console.WriteLine($"Discount applied : -R{discountAmount:F2}");
        }
        else
        {
            double remaining = DISCOUNT_THRESHOLD - total;
            Console.WriteLine($"\nSpend R{remaining:F2} more to get a 10% discount!");
        }
    }
}
