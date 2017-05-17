using System;

namespace FizzBuzz
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number: ");
            int UserInput = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 1; i<=UserInput; i++)
            {
                Console.WriteLine(FizzBuzz(i));
            }
        }

        public static string FizzBuzz(int x)
        {

            if (x % 3 == 0 && x % 5 == 0)
            {
                return ">>>FizzBuzz<<<";
            }
            else
            if (x % 5 == 0)
            {
                return ">>Buzz<<";
            }
            else
            if (x % 3 == 0)
            {
                return ">>Fizz<<";
            }
            else
                return x.ToString();
        }


    }
}
