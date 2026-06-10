using System;
using System.Diagnostics;
using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Практичне завдання №8,9.");
Console.WriteLine("Тема: Структурне керування винятками. Обробка винятків різних типів.");
Console.WriteLine();

RunTask1();
Console.WriteLine();
RunTask2();

static void RunTask1()
{
    try
    {
        Console.Write("Завдання 1. Введіть додатне дробове число: ");
        string input = Console.ReadLine() ?? "";
        double number = double.Parse(input.Replace(',', '.'), CultureInfo.InvariantCulture);

        if (number <= 0)
        {
            throw new NotPositiveNumberException("Число повинно бути додатним.");
        }

        if (number % 1 == 0)
        {
            throw new NotFractionalNumberException("Число повинно бути дробовим.");
        }

        Console.WriteLine("Введено правильне додатне дробове число: " + number);
    }
    catch (FormatException)
    {
        Console.WriteLine("Помилка: введене значення не є числом.");
    }
    catch (NotPositiveNumberException ex)
    {
        Console.WriteLine("Помилка: " + ex.Message);
    }
    catch (NotFractionalNumberException ex)
    {
        Console.WriteLine("Помилка: " + ex.Message);
    }
    finally
    {
        Console.WriteLine("Перевірку завершено.");
    }
}

static void RunTask2()
{
    Stopwatch stopwatch = new();
    stopwatch.Start();

    try
    {
        Console.Write("Завдання 2. Введіть додатне дробове число: ");
        string input = Console.ReadLine() ?? "";
        double number = double.Parse(input.Replace(',', '.'), CultureInfo.InvariantCulture);

        if (number <= 0)
        {
            throw new NotPositiveNumberException("Число повинно бути більше нуля.");
        }

        if (number % 1 == 0)
        {
            throw new NotFractionalNumberException("Число повинно мати ненульову дробову частину.");
        }

        Console.WriteLine("Число пройшло перевірку: " + number);
    }
    catch (FormatException)
    {
        Console.WriteLine("Помилка: введено нечислове значення.");
    }
    catch (NotPositiveNumberException ex)
    {
        Console.WriteLine("Помилка додатності: " + ex.Message);
    }
    catch (NotFractionalNumberException ex)
    {
        Console.WriteLine("Помилка дробової частини: " + ex.Message);
    }
    finally
    {
        stopwatch.Stop();
        Console.WriteLine("Операцію завершено.");
        Console.WriteLine("Час виконання: " + stopwatch.ElapsedMilliseconds + " мс");
    }
}

public class NotPositiveNumberException : Exception
{
    public NotPositiveNumberException(string message) : base(message)
    {
    }
}

public class NotFractionalNumberException : Exception
{
    public NotFractionalNumberException(string message) : base(message)
    {
    }
}
