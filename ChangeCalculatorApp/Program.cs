using ChangeCalculatorApp;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        // Promp user for initial amount and price
        Console.WriteLine("Enter initial amount in whole pounds and pence (e.g £2.5)");
        string initial = Console.ReadLine();

        int initialConverted = ChangeCalculator.ConvertToPence(initial);
        while (initialConverted == -1)
        {
            Console.WriteLine("Invalid input for initial amount. Please enter a valid amount in whole pounds and pence (e.g £2.5)");
            initial = Console.ReadLine();
            initialConverted = ChangeCalculator.ConvertToPence(initial);
        }


        Console.WriteLine("Enter product price in whole pounds and pence (e.g £2.5)");
        string price = Console.ReadLine();

        int priceConverted = ChangeCalculator.ConvertToPence(price);
        while (priceConverted == -1)
        {
            Console.WriteLine("Invalid input for product price. Please enter a valid amount in whole pounds and pence (e.g £2.5)");
            price = Console.ReadLine();
            priceConverted = ChangeCalculator.ConvertToPence(price);
        }

        // Find out how much is left over and calculate change
        int leftOverAmuount = initialConverted - priceConverted;

        if (leftOverAmuount < 0)
        {
            Console.WriteLine("Not enough money provided.");
            return;
        }

        List<(string, int)> result = ChangeCalculator.CalculateChange(leftOverAmuount);

        // Output branching based on whether change is needed or not
        if (result.Count == 0)
        {
            Console.WriteLine("No change is needed.");
            return;
        }
        else
        {
            Console.WriteLine("Your change is: \n");

            foreach (var (denomination, count) in result)
            {
                Console.WriteLine("{0:D}x {1}", count, denomination);
            }
        }
    }
}
