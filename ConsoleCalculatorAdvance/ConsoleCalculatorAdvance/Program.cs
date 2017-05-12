using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    class Program
    {
        static void Main(string[] args)
        {

            bool keepAsking = true;
            do
            {
                try
                {
                    Console.WriteLine("Please Enter an equation.");
                    string input = Console.ReadLine();

                    double answer = EvaluateOrderOfOperations(input);
                    Console.WriteLine(answer);
                    Console.WriteLine("");
                    Console.WriteLine("Again?");
                    string again = Console.ReadLine();
                    if (again != "y")
                    {
                        keepAsking = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (keepAsking);




        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        public static double EvaluateOrderOfOperations(string input)
        {
            double answer = 0;
            var foundIndexesADD = new List<int>();
            var foundIndexesSUB = new List<int>();
            var foundIndexesMUL = new List<int>();
            var foundIndexesDIV = new List<int>();
            var allOperands = new List<int>();

            if (input.Contains("+"))
            {
                for (int i = input.IndexOf('+'); i > -1; i = input.IndexOf('+', i + 1))
                {
                    foundIndexesADD.Add(i);
                    allOperands.Add(i);
                }
            }

            if (input.Contains("-"))
            {
                for (int i = input.IndexOf('-'); i > -1; i = input.IndexOf('-', i + 1))
                {
                    foundIndexesSUB.Add(i);
                    allOperands.Add(i);
                }
            }

            if (input.Contains("*"))
            {
                for (int i = input.IndexOf('*'); i > -1; i = input.IndexOf('*', i + 1))
                {
                    foundIndexesMUL.Add(i);
                    allOperands.Add(i);
                }
            }

            if (input.Contains("/"))
            {
                for (int i = input.IndexOf('/'); i > -1; i = input.IndexOf('/', i + 1))
                {
                    foundIndexesDIV.Add(i);
                    allOperands.Add(i);
                }
            }

            allOperands.Sort();
            int y = 0;
            string[] parts;
            int index = 1;
            int lastIndex = 0;
            int operandIndex = 0;
            var connectingOperators = new List<string>();

            if (IsOdd(allOperands.Count))
            {
                parts = new string[(allOperands.Count + 1) / 2];
                for (var x = 0; x <= allOperands.Count; x++)
                {
                    if (index != allOperands.Count + 1)
                    {
                        operandIndex = allOperands[x];
                        if (!IsOdd(index))
                        {
                            parts[y] = input.Substring(lastIndex, operandIndex - lastIndex);
                            lastIndex = operandIndex + 1;
                            connectingOperators.Add(input.Substring(operandIndex, 1));
                            y++;
                        }

                        index++;
                    }
                    else
                    {
                        operandIndex = input.Length;
                        if (!IsOdd(index))
                        {
                            parts[y] = input.Substring(lastIndex, operandIndex - lastIndex);
                            lastIndex = operandIndex + 1;

                            y++;
                        }

                        index++;
                    }
                }
            }
            else
            {
                parts = new string[((allOperands.Count + 1) / 2) + 1];
                for (var x = 0; x <= allOperands.Count; x++)
                {


                    if (index != allOperands.Count + 1)
                    {
                        operandIndex = allOperands[x];
                        if (!IsOdd(index))
                        {
                            parts[y] = input.Substring(lastIndex, operandIndex - lastIndex);
                            lastIndex = operandIndex + 1;
                            connectingOperators.Add(input.Substring(operandIndex, 1));
                            y++;
                        }

                        index++;
                    }
                    else
                    {
                        operandIndex = input.Length;
                        if (IsOdd(index))
                        {
                            parts[y] = input.Substring(lastIndex, operandIndex - lastIndex);
                        }

                        index++;
                    }
                }
            }


            foreach (string part in parts)
            {
                if (part.Contains("+"))
                {
                    string[] split = part.Split('+');
                    answer = answer + Add(Convert.ToDouble(split[0]), Convert.ToDouble(split[1]));
                }

                if (part.Contains("-"))
                {
                    string[] split = part.Split('-');
                    answer = answer + Subt(Convert.ToDouble(split[0]), Convert.ToDouble(split[1]));
                }

                if (part.Contains("*"))
                {
                    string[] split = part.Split('*');
                    answer = answer + Mult(Convert.ToDouble(split[0]), Convert.ToDouble(split[1]));
                }

                if (part.Contains("/"))
                {
                    string[] split = part.Split('/');
                    answer = answer + Divide(Convert.ToDouble(split[0]), Convert.ToDouble(split[1]));
                }

                if (!part.Contains("+") && !part.Contains("-") && !part.Contains("*") && !part.Contains("/"))
                {
                    switch (connectingOperators[0])
                    {
                        case "+":
                            answer = answer + Convert.ToDouble(part);
                            break;
                        case "-":
                            answer = answer - Convert.ToDouble(part);
                            break;
                        case "*":
                            answer = answer * Convert.ToDouble(part);
                            break;
                        case "/":
                            answer = answer / Convert.ToDouble(part);
                            break;
                    }

                }

            }


            return answer;
        }



        public static double Add(double a, double b)
        {
            double x = 0f;
            x = a + b;
            return x;
        }
        public static double Subt(double a, double b)
        {
            double x = 0f;
            x = a - b;
            return x;
        }
        public static double Mult(double a, double b)
        {
            double x = 0f;
            x = a * b;
            return x;
        }
        public static double Divide(double a, double b)
        {
            double x = 0f;
            x = a / b;
            return x;
        }
    }
}