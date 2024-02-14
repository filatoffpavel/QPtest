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
            Console.WriteLine("Enter an integer:");
            char ch = Char.MinValue;
            int x = 0;
            bool fitstSimbol = true;
            long maxSum = 0, tempSum = 0;
            ConsoleKeyInfo keyInfo;
            while (true)
            {
                do
                {
                    keyInfo = Console.ReadKey();
                    try
                    {
                        if (fitstSimbol)
                        {
                            fitstSimbol = false;
                            if (keyInfo.Key == ConsoleKey.Subtract || keyInfo.Key == ConsoleKey.Add)
                                continue;
                        }

                        ch = keyInfo.KeyChar;
                        x = ch - 48;
                        if (x > -1 && x < 10)
                        {
                            tempSum += x;
                        }
                        else if (ch != '\r')
                        {
                            Console.WriteLine("Wrong character");
                            //tempSum = 0;  //раскоментировать, если надо дать возможность продолжить ввод нового числа
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

                fitstSimbol = true;

                if (tempSum == 0)
                    break;

                if (maxSum < tempSum)
                {
                    maxSum = tempSum;
                }

                tempSum = 0;
            }

            Console.WriteLine("The biggest sume of digits is:{0}", maxSum);
            Console.ReadLine();
        }
    }
}
