using System;

namespace Task02.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Student Grade Checker ");
            Console.Write("Enter student score: ");

            int score = int.Parse(Console.ReadLine()!);

            if (!(score >= 0 && score <= 100))
            {
                Console.WriteLine("Invalid score.");
            }
            else if (score >= 90 && score <= 100)
            {
                Console.WriteLine("Excellent");
            }
            else if (score >= 80 && score < 90)
            {
                Console.WriteLine("Very Good");
            }
            else if (score >= 70 && score < 80)
            {
                Console.WriteLine("Good");
            }
            else if (score >= 60 && score < 70)
            {
                Console.WriteLine("Fair");
            }
            else
            {
                Console.WriteLine("Fail");
            }

            ArrayOperations();
        }

        static void ArrayOperations()
        {
            int[] numbers = { 10,5,30,8,20,15,2,40,25,12 };

            Console.WriteLine();
            Console.WriteLine("Array Operations");

            Console.Write("Original: ");
            PrintArray(numbers);

            int max = FindMax(numbers);
            int min = FindMin(numbers);
            double average = CalculateAverage(numbers);

            Console.WriteLine($"Max:{max}");
            Console.WriteLine($"Min:{min}");
            Console.WriteLine($"Average:{average}");

            ReverseArray(numbers);

            Console.Write("Reversed: ");
            PrintArray(numbers);

            SortArray(numbers);

            Console.Write("Sorted: ");
            PrintArray(numbers);
        }

        static int FindMax(int[] numbers)
        {
            int max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        static int FindMin(int[] numbers)
        {
            int min = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            return min;
        }

        static double CalculateAverage(int[] numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return (double)sum / numbers.Length;
        }

        static void ReverseArray(int[] numbers)
        {
            int left = 0;
            int right = numbers.Length - 1;

            while (left < right)
            {
                int temp = numbers[left];

                numbers[left] = numbers[right];
                numbers[right] = temp;

                left++;
                right--;
            }
        }

        static void SortArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];

                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
        }

        static void PrintArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]);

                if (i < numbers.Length - 1)
                {
                    Console.Write(" , ");
                }
            }

            Console.WriteLine();
        }
    }
}