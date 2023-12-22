using System;
using System.Threading.Tasks;

namespace Homework_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1
            Console.Write("Enter a number from 1 to 100 :: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number >= 1 && number <= 100)
                {
                    if (number % 3 == 0 && number % 5 == 0)
                    {
                        Console.WriteLine("FizzBuzz");
                    }
                    else if (number % 3 == 0)
                    {
                        Console.WriteLine("Fizz");
                    }
                    else if (number % 5 == 0)
                    {
                        Console.WriteLine("Buzz");
                    }
                    else
                    {
                        Console.WriteLine(number);
                    }
                }
                else
                {
                    Console.WriteLine("Error: The entered number is not in the range from 1 to 100.");
                }
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid integer.");
            }

            //Task2
            Console.Write("Enter a number :: ");
            if (double.TryParse(Console.ReadLine(), out double num))
            {
                Console.Write("Enter the percentage: ");
                if (double.TryParse(Console.ReadLine(), out double percentage))
                {
                    double result1 = (percentage / 100) * num;
                    Console.WriteLine($"{percentage}% of {num} is equal to {result1}");
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid percentage.");
                }
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }

            //Task3

            Console.WriteLine("Enter four digits :: ");
            int[] nums = new int[4];
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Enter digit {i + 1} :: ");

                if (int.TryParse(Console.ReadLine(), out int digit) && digit >= 0 && digit <= 9)
                {
                    nums[i] = digit;
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid single-digit number.");
                    return;
                }
            }
            int result = nums[0] * 1000 + nums[1] * 100 + nums[2] * 10 + nums[3];

            Console.WriteLine($"The formed number is: {result}");



            //Task4

            Console.Write("Enter a six-digit number: ");

            if (int.TryParse(Console.ReadLine(), out int userInput) && userInput >= 100000 && userInput <= 999999)
            {
                Console.Write("Enter the positions of digits to swap (e.g., 1 6): ");

                string[] positions = Console.ReadLine().Split(' ');

                if (positions.Length == 2 && int.TryParse(positions[0], out int position1) && int.TryParse(positions[1], out int position2) &&
                    position1 >= 1 && position1 <= 6 && position2 >= 1 && position2 <= 6)
                {
                    int swappedNumber = SwapDigits(userInput, position1, position2);

                    Console.WriteLine($"The transformed number is: {swappedNumber}");
                }
                else
                {
                    Console.WriteLine("Error: Please enter two valid positions between 1 and 6.");
                }
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid six-digit number.");
            }

            static int SwapDigits(int number, int position1, int position2)
            {

                int digit1 = (number / (int)Math.Pow(10, 6 - position1)) % 10;
                int digit2 = (number / (int)Math.Pow(10, 6 - position2)) % 10;


                number += (digit1 - digit2) * (int)Math.Pow(10, 6 - position2);
                number += (digit2 - digit1) * (int)Math.Pow(10, 6 - position1);

                return number;
            }


            //Task5

            Console.Write("Enter a date (DD.MM.YYYY): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime Input))
            {
                string season = GetSeason(Input.Month);
                string dayOfWeek =Input.DayOfWeek.ToString();

                Console.WriteLine($"{season} {dayOfWeek}");
            }
            else
            {
                Console.WriteLine("Error: Invalid date format.");
            }
        

        static string GetSeason(int month)
        {
            if (month >= 3 && month <= 5)
            {
                return "Spring";
            }
            else if (month >= 6 && month <= 8)
            {
                return "Summer";
            }
            else if (month >= 9 && month <= 11)
            {
                return "Autumn";
            }
            else
            {
                return "Winter";
            }

        }
            //Task 6

            Console.Write("Enter temperature: ");
            if (double.TryParse(Console.ReadLine(), out double temperature))
            {
                Console.WriteLine("Choose conversion direction:");
                Console.WriteLine("1. Fahrenheit to Celsius");
                Console.WriteLine("2. Celsius to Fahrenheit");

                if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2))
                {
                    double convertedTemperature = (choice == 1) ? FahrenheitToCelsius(temperature) : CelsiusToFahrenheit(temperature);

                    string originalUnit = (choice == 1) ? "Fahrenheit" : "Celsius";
                    string targetUnit = (choice == 1) ? "Celsius" : "Fahrenheit";

                    Console.WriteLine($"{temperature} {originalUnit} is {convertedTemperature} {targetUnit}");
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid choice (1 or 2).");
                }
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid temperature.");
            }
        

        static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        static double CelsiusToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }


        //Task7

        Console.Write("Enter the first number: ");
            if (int.TryParse(Console.ReadLine(), out int number1))
            {
                Console.Write("Enter the second number: ");
                if (int.TryParse(Console.ReadLine(), out int number2))
                {
                    NormalizeBounds(ref number1, ref number2);

                    Console.WriteLine($"Normalized bounds: {number1} to {number2}");
                    Console.WriteLine("Even numbers in the range:");

                    for (int i = number1; i <= number2; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid second number.");
                }
            }
            else
            {
                Console.WriteLine("Error: Please enter a valid first number.");
            }
        }

        static void NormalizeBounds(ref int number1, ref int number2)
        {
            if (number1 > number2)
            {
                int temp = number1;
                number1 = number2;
                number2 = temp;
            }
        }
    }
}

