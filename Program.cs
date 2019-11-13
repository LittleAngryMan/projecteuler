using System;
using System.Collections.Generic;

namespace projecteuler
{
    class Program
    {
        public static bool IsPrime(int number)
        {
            // Two is the only exception to the modulus rule and thus a prime number.
            if (number == 2)
            {
                return true;
            }
            // One or less doesn't constitute a prime. Neither does anything that can be divided by two and have no remainder. Rule them out at the beginning.
            if (number <= 1 || number % 2 == 0)
            {
                return false;
            }
            

            //Make the upper boundary for the for loop, the sqaure root of the number being passed.
            int boundary = (int)Math.Floor(Math.Sqrt(number));
            //Similarily to the first step of the method, if the number can be used with any other number (up to its square root) in division to procude a remainder of 0, the number is not a prime.
            for (int i = 3; i <= boundary; i = i + 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static string TransformNumber(int number)
        {
            string result = "";
            string[] single = new[] {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            string[] teen = new[] {"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
            string[] ten = new[] {"zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};

            List<int> parts = new List<int>();

            foreach (char c in number.ToString())
            {
                parts.Add((int)Char.GetNumericValue(c));
            }

            if (parts.Count == 1)
            {
                result = single[number];
            }
            else if (parts.Count == 2)
            {
                if (number > 9 && number < 20)
                {
                    result = teen[number - 10];
                }
                else if (number > 19)
                {
                    result = ten[parts[0]];
                    if (parts[1] != 0)
                    {
                        result = result + single[parts[1]];
                    }
                }
            }
            else if (parts.Count == 3)
            {
                result = single[parts[0]] + "hundred";
                if (parts[1] == 0)
                {
                    if (parts[2] != 0)
                    {
                        result = result + "and" + single[parts[2]];
                    }
                }
                else if (parts[1] == 1)
                {
                    result = result + "and" + teen[parts[2]];
                }
                else
                {
                    if (parts[2] != 0)
                    {
                        result = result + "and" + ten[parts[1]] + single[parts[2]];
                    }
                    else
                    {
                        result = result + "and" + ten[parts[1]];
                    }
                }
            }
            else if (number == 1000)
            {
                result = "onethousand";
            }

            return result;
        }

        static void Main(string[] args)
        {
            //Problem 8
            const String series = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
            long highestValue = 0;

            //Iterate for each group of thirteen integers.
            for (int i = 0; i < 988; i++)
            {
                //Create a base value for finding the product.
                long result = 1;

                String group = series.Substring(i, 13);
                foreach (char c in group)
                {
                    int charValue;
                    //Try to parse the character in question and output it to an int if it can be parsed.
                    bool parseable = int.TryParse(c.ToString(), out charValue);

                    //If it can't be parsed, terminate the program. Input data is invalid.
                    if (!parseable)
                    {
                        Console.WriteLine("Character cannot be converted to an int. Terminating program.");
                        return;
                    }

                    //Otherwise, use the value as part of the product.
                    result = result * charValue;
                }

                //Update the highest value if the new result is higher.
                if (result > highestValue)
                {
                    highestValue = result;
                }
            }
            
            Console.WriteLine("Problem 8 result = {0}", highestValue);

            //Problem 10
            long primeSum = 0;
            for (int i = 0; i < 2000000; i++)
            {
                if (IsPrime(i) == true)
                {
                    primeSum = primeSum + i;
                }
            }

            Console.WriteLine("Problem 10 result = {0}", primeSum);

            //Problem 17
            string oneToOneThousand = "";
            for (int i = 1; i <= 1000; i++)
            {
                oneToOneThousand = oneToOneThousand + TransformNumber(i);
            }

            Console.WriteLine("Problem 17 result = {0}", oneToOneThousand.Length);
        }
    }
}
