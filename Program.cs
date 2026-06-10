using System;
using System.Diagnostics;

namespace Practice08_09_StructuredExceptions
{
    class NotPositiveNumberException : Exception
    {
        public NotPositiveNumberException(string message) : base(message)
        {
        }
    }

    class NotFractionalNumberException : Exception
    {
        public NotFractionalNumberException(string message) : base(message)
        {
        }
    }

    internal class Program
    {
        static double ParsePositiveFractionalNumber(string input)
        {
            Stopwatch timer = Stopwatch.StartNew();

            try
            {
                double number = double.Parse(input);

                if (number <= 0)
                {
                    throw new NotPositiveNumberException("Помилка: число повинно бути додатним.");
                }

                if (number == Math.Floor(number))
                {
                    throw new NotFractionalNumberException("Помилка: число повинно бути дробовим.");
                }

                return number;
            }
            finally
            {
                timer.Stop();
                Console.WriteLine("Перетворення тексту в число зайняло " + timer.ElapsedTicks + " такти таймера");
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Практичне завдання №8-9");
            Console.WriteLine("Тема: структурне керування винятками");
            Console.WriteLine();

            Console.Write("Введіть додатне дробове число: ");
            string input = Console.ReadLine() ?? "";

            try
            {
                double result = ParsePositiveFractionalNumber(input);
                Console.WriteLine("Введено коректне число: " + result);
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка: введене значення не є числом.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Помилка: введене число виходить за межі допустимого діапазону.");
            }
            catch (NotPositiveNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotFractionalNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
