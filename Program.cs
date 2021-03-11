using System;
using static EX_9A_Bisection_Algorithm.GuessNumber;

namespace EX_9A_Bisection_Algorithm
{
    class Program
    {
        public static int numCount = 0;
        public static void PrintArray(int[] input)
        {
            Console.WriteLine("Current Range:");
            for (int i = 0; i < input.Length - 1; i++)
            {
                Console.Write($"{input[i]}, ");
            }
            Console.WriteLine($"{input[input.Length - 1]}.");
        }
        public static int Bisection(int num, int[] numList)
        {
            PrintArray(numList);
            int mid = ( numList.Length ) / 2;


            int[] newArr = new int[mid];

            if (numList.Length == 1 && numList[0] != num) 
            {
                Console.WriteLine($"Value {num} not in list.");
                return 0;
            }

            if (numList.Length % 2 == 1) {
                if (num == numList[mid])
                {
                    Console.WriteLine($"Value {num} found. Iterations: {numCount}.");
                    numCount = 0;
                    return num;
                }
                if (num > numList[mid])
                {
                    Console.WriteLine($"Number {num} is larger than middle value {numList[mid]}.");
                    for (int i = mid + 1; i < numList.Length; i++)
                    {
                        newArr[i - mid - 1] = numList[i];
                    }
                }
                if (num < numList[mid])
                {
                    Console.WriteLine($"Number {num} is larger than middle value {numList[mid]}.");
                    for (int i = 0; i < mid; i++)
                    {
                        newArr[i] = numList[i];
                    }
                }
            }

            if (numList.Length % 2 == 0)
            {
                if (num == numList[mid - 1])
                {
                    Console.WriteLine($"Value {num} found.");
                    return num;
                }
                if (num > numList[mid - 1])
                {
                    Console.WriteLine($"Number {num} is larger than middle value {numList[mid - 1]}.");
                    for (int i = mid; i < numList.Length; i++)
                    {
                        newArr[i - mid] = numList[i];
                    }
                }
                if (num < numList[mid - 1])
                {
                    Console.WriteLine($"Number {num} is larger than middle value {numList[mid - 1]}.");
                    for (int i = 0; i < mid; i++)
                    {
                        newArr[i] = numList[i];
                    }
                }
            }
            numCount++;
            return Bisection(num, newArr);
        }
        static void Main(string[] args)
        {
            try
            {
                int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                
                Console.WriteLine("Enter a value to search in the list:");
                int userNum = Int32.Parse(Console.ReadLine());
                
                
                Bisection(userNum, list);
                HumanPlays();
                ComputerPlays();
            }
            catch(Exception EX)
            {
                Console.WriteLine(EX.Message);
            }
        }
    }
}
