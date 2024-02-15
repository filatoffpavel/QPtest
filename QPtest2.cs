using System;

namespace SumNumerals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            keySniffer();
        }

        static void keySniffer()
        {
            Console.WriteLine("Please enter an integer value:");
            char ch = Char.MinValue;
            char stringEnd = '\r';
            int x = 0;
            int zeroASCIIcod = 48;
            bool firstSymbol = true;
            bool noWrongSymbol = false;
            long maxSum = 0, tempSum = 0;
            ConsoleKeyInfo keyInfo;
            while (true)
            {
                do
                {
                    keyInfo = Console.ReadKey();
                    try
                    {
                        if (firstSymbol)
                        {
                            firstSymbol = false;
                            if (keyInfo.Key == ConsoleKey.Subtract || keyInfo.Key == ConsoleKey.OemMinus || keyInfo.Key == ConsoleKey.Add || (keyInfo.Key == ConsoleKey.OemPlus && keyInfo.Modifiers == ConsoleModifiers.Shift))
                                continue;
                        }

                        ch = keyInfo.KeyChar;
                        x = ch - zeroASCIIcod;
                        if (x > -1 && x < 10)
                        {
                            noWrongSymbol = true;
                            tempSum += x;
                        }
                        else if (ch != stringEnd)
                        {
                            noWrongSymbol = false;
                            Console.WriteLine(" Wrong character");
                            tempSum = 0;
                            break;
                        }
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine("{0} Value read = {1}.", e.Message, x);
                        ch = Char.MinValue;
                    }

                } while (keyInfo.Key != ConsoleKey.Enter);

                Console.WriteLine(Environment.NewLine);

                if (tempSum == 0 && noWrongSymbol)
                    break;

                if (maxSum < tempSum)
                {
                    maxSum = tempSum;
                }

                tempSum = 0;
                noWrongSymbol = false;
                firstSymbol = true;
            }

            Console.WriteLine("Maximum digit sum is:{0}", maxSum);
            Console.ReadLine();
        }
    }
}
