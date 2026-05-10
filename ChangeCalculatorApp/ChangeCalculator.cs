using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChangeCalculatorApp
{
    public static class ChangeCalculator
    {
        public static int ConvertToPence(string amount)
        {
            // Sanity checks
            if(amount == null || amount == "")
            {
                return -1;
            }

            // Check if amount is given in correct format (pounds.pence or pounds)
            bool validFormat = Regex.IsMatch(amount, @"^£{0,1}(\d+.\d{1,2})|(\d+)p{0,1}$");
            if (!validFormat)
            {
                return -1;
            }

            // Case 1: amount is just in pence
            if(Regex.IsMatch(amount, @"^\d+p{1}$"))
            {
                if (amount[amount.Length - 1] == 'p')
                {
                    amount = amount.Substring(0, amount.Length - 1);
                }
                int pence = int.Parse(amount);
                return pence;
            }

            // we can now remove symbols as they are irellevant for the remaining cases
            if (amount[0] == '£')
            {
                amount = amount.Substring(1);
            }

            if (amount[amount.Length - 1] == 'p')
            {
                amount = amount.Substring(0, amount.Length - 1);
            }


            // Case 2: amount is just in pounds
            if (Regex.IsMatch(amount, @"^\d+$"))
            {
                return int.Parse(amount) * 100;
            }

            // Case 3: amount is in pounds and pence with 2 digit pence
            else if (Regex.IsMatch(amount, @"^\d+.\d{2}$"))
            {
                string[] parts = amount.Split('.');
                int pounds = int.Parse(parts[0]);
                int pence = int.Parse(parts[1]);
                return (pounds * 100) + pence;
            }

            // Case 4: amount is in pounds and pence with 1 digit pence

            else if (Regex.IsMatch(amount, @"^\d+.\d{1}$"))
            {
                string[] parts = amount.Split('.');
                int pounds = int.Parse(parts[0]);
                int pence = int.Parse(parts[1]) * 10;

                return (pounds * 100) + pence;
            }


            return -1;

        }

        public static List<(string, int)> CalculateChange(int amount)
        {

            // All possible denominations and their values in pence
            Dictionary<int, string> currency = new Dictionary<int, string>()
            {
                {5000, "£50"},
                {2000, "£20"},
                {1000, "£10"},
                {500, "£5"},
                {200, "£2"},
                {100, "£1"},
                {50, "50p"},
                {20, "20p"},
                {10, "10p"},
                {5, "5p"},
                {2, "2p" },
                {1, "1p"}
            };

            List<(string, int)> change = new List<(string, int)>();

            int amountRemaining = amount;

            // denominations are in descending order so by working down the dictionary it gets ordered correctly
            foreach (var (key, val) in currency)
            {
                if (amountRemaining >= key)
                {
                    int divisor = (int)(amountRemaining / key);
                    amountRemaining -= (divisor * key);

                    change.Add((val, divisor));
                }
            }

            return change;
        }
    }
}
