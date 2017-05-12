using System;

namespace ConsoleCalulator
{
    class Program
    {
        /// <summary>
        /// This is the main driver that runs the calculator.
        /// </summary>
        static void Main()
        {
            Say.Write("Welcome to the Console Calculator!", true, 20f, ConsoleColor.Green);

            bool UserCont = true;
            string UserChoice;
            
            //Checks to see if User wants to run another calculation.
            while (UserCont == true)
            {
                Calculator Calc = new Calculator();
                Calc.Calculate();

                Say.Write("Run another Calculation? (Yes/No)", true, 20f, ConsoleColor.Green);
                UserChoice = Console.ReadLine().ToLower();

                if (UserChoice == "no" || UserChoice == "n")
                {
                    UserCont = false;
                    Say.Write("Thank You", true, 20f, ConsoleColor.Green);
                }
            }

        }
    }

    class Calculator
    {
        /// <summary>
        /// This is the main calculator method for the basic functions
        /// </summary>
        public void Calculate()
        {
            int num1 = 0;
            int num2 = 0;
            char UserOp;

            Say.Write("Please enter the first number", true, 25f, ConsoleColor.Green);
            Say.Write(">>", false, 20f, ConsoleColor.Green);
            String input1 = Console.ReadLine();

            //User validation for integer
            while (!Int32.TryParse(input1, out num1))
            {
                Say.Write("Not a valid number. Please try again!", true, 25f, ConsoleColor.Red);
                Say.Write(">>", false, 20f, ConsoleColor.Green);
                input1 = Console.ReadLine();
            }

            Say.Write("Please enter an operator: +, -, *, /, %, ^, s ", true, 25f, ConsoleColor.Green);
            Say.Write(">>", false, 50f, ConsoleColor.Green);
            UserOp = Console.ReadKey().KeyChar;
            Console.WriteLine();

            //User validation for math operators
            while (!CheckOperation(UserOp))
            {
                Say.Write("That is not a valid operator!", true, 25f, ConsoleColor.Red);
                Say.Write("Please enter an operator: +, -, *, /, %, ^, s", true, 25f, ConsoleColor.Green);
                Say.Write(">>", false, 50f, ConsoleColor.Green);
                UserOp = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }

            //skip second input prompt if user selects squareroot operator.
            if (UserOp != 's')
            {
                //User validation for integer
                Say.Write("Please enter the second number", true, 25f, ConsoleColor.Green);
                Say.Write(">>", false, 50f, ConsoleColor.Green);
                string input2 = Console.ReadLine();

                while (!Int32.TryParse(input2, out num2))
                {
                    Say.Write("Not a valid number. Please try again!", true, 25f, ConsoleColor.Red);
                    Say.Write(">>", false, 20f, ConsoleColor.Green);
                    input2 = Console.ReadLine();
                }
            }

            //This is prompt for output
            Say.Write(">>>>", false, 20f, ConsoleColor.Yellow);

            //Calculation functions
            switch (UserOp)
            {
                //case '+': Console.WriteLine(num1 + num2); break;
                case '+': Console.WriteLine(Addition(num1, num2)); break;

                case '-': Console.WriteLine(Subtraction(num1, num2)); break;

                case '*': Console.WriteLine(Multiplication(num1, num2)); break;

                case '^': Console.WriteLine(PowerOf(num1, num2)); break;

                case '%': Console.WriteLine(Modulo(num1, num2)); break;

                case '/':

                    if (num2 == 0)
                    {
                        Say.Write("Error! The denominator cannot be 0", true, 25f, ConsoleColor.Red);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(Division(num1, num2)); break;
                    }

                case 's': Console.WriteLine(SquareRoot(num1)); break;
            }
        }

#region MathFunctions
        /// <summary>
        /// Math functions for switch cases.
        /// </summary>
        /// <param name="num1">user's first input</param>
        /// <param name="num2">user's second input</param>
        /// <returns></returns>
        public int Addition(int num1, int num2)
        {
            int Answer = num1 + num2;
            return Answer;
        }

        public int Subtraction (int num1, int num2)
        {
            int Answer = num1 - num2;
            return Answer;
        }

        public int Multiplication(int num1, int num2)
        {
            int Answer = num1 * num2;
            return Answer;
        }

        public int Division(int num1, int num2)
        {
            int Answer = num1 / num2;
            return Answer;
        }

        public int Modulo(int num1, int num2)
        {
            int Answer = num1 % num2;
            return Answer;
        }

        public double PowerOf(int num1, int num2)
        {
            double Answer = Math.Pow(num1, num2);
            return Answer;
        }

        public double SquareRoot(int num1)
        {
            double Answer = Math.Sqrt(num1);
            return Answer;
        }
#endregion 

        /// <summary>
        /// This method validates the operator enter by the user
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public bool CheckOperation(char operation)
        {
            switch (operation)
            {
                case '*':
                    return true;
                    break;
                case '+':
                    return true;
                    break;
                case '-':
                    return true;
                    break;
                case '/':
                    return true;
                    break;
                case '^':
                    return true;
                    break;
                case '%':
                    return true;
                    break;
                case 's':
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }

    }

    /// <summary>
    /// This class is for customizable console output.
    /// </summary>
    class Say
    {
        /// <summary>
        /// This method is for custom console output with text lag and color
        /// </summary>
        /// <param name="toSay">string to output</param>
        /// <param name="newLine">if a new line is required after text</param>
        /// <param name="speed">speed the text is displayed</param>
        /// <param name="color">color of the text</param>
        public static void Write(string toSay, bool newLine, float speed, ConsoleColor color)
        {
            Console.ForegroundColor = color;

            foreach (char toWrite in toSay)
            {
                Console.Write(toWrite);
                System.Threading.Thread.Sleep((int)speed);
            }
            if (newLine == true)
            {
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}