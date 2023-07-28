using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //DONE: Create an integer Array of size 50
            int[] arrayOfFifty = new int[50];


            //DONE: Create a method to populate the number array with 50 random numbers that are between 0 and 50
            Populater(arrayOfFifty);


            //DONE: Print the first number of the array
            Console.WriteLine();
            Console.WriteLine(arrayOfFifty[0]);


            //DONE: Print the last number of the array
            Console.WriteLine(arrayOfFifty[arrayOfFifty.Length - 1]);


            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(arrayOfFifty);
            Console.WriteLine("-------------------");

            //DONE: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */


            Console.WriteLine("All Numbers Reversed:");
            Array.Reverse(arrayOfFifty);
            NumberPrinter(arrayOfFifty);


            Console.WriteLine("---------REVERSE CUSTOM------------");
            ReverseArray(arrayOfFifty);
            NumberPrinter(arrayOfFifty);



            Console.WriteLine("-------------------");

            //DONE: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(arrayOfFifty);
            NumberPrinter(arrayOfFifty);


            Console.WriteLine("-------------------");

            //DONE: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(arrayOfFifty);
            NumberPrinter(arrayOfFifty);


            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //DONE: Create an integer List
            var listOfFifty = new List<int>();


            //DONE: Print the capacity of the list to the console
            Console.WriteLine(listOfFifty.Capacity);


            //DONE: Populate the List with 50 random numbers between 0 and 50 you will need a method for this
            Populater(listOfFifty);

            //TODO: Print the new capacity
            Console.WriteLine(listOfFifty.Capacity);


            Console.WriteLine("---------------------");

            //DONE: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");
            bool rightNum = int.TryParse(Console.ReadLine(), out int searchNum);

            while (rightNum == false)
            {
                Console.Write("Please enter a valid whole number: ");
                rightNum = int.TryParse(Console.ReadLine(), out searchNum);
            }
            Console.WriteLine($"Your Number: {searchNum}");
            NumberChecker(listOfFifty, searchNum);


            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(listOfFifty);
            Console.WriteLine("-------------------");


            //DONE: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(listOfFifty);

            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            listOfFifty.Sort();
            NumberPrinter(listOfFifty);

            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable
            var arrayedOfFifty = listOfFifty.ToArray();


            //TODO: Clear the list
            listOfFifty.Clear();

            #endregion
        }

        private static void ThreeKiller(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
            }
        }

        private static void OddKiller(List<int> numberList)
        {
            var oddList = new List<int>();
            for (int i = numberList.Count - 1; i >= 0; i--)
            {
                if (numberList[i] % 2 != 0)
                {
                    numberList.RemoveAt(i);
                }
            }
            NumberPrinter(numberList);
            /*Reformatted this one. I realized that going backwards will not cause
             * the errors that going forward does since you are not going to skip 
             * over any numbers, and the index will not change in the direction that
             * the for loop is moving, only where you have already been.
             */
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            if (numberList.Contains(searchNumber))
            {
                Console.WriteLine("You found one!");
            }
            else
            {
                Console.WriteLine("Sorry, no match here.");
            }
        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();
            for (int i = 0; i < 50; i++)
            {
                numberList.Add(rng.Next(0, 50));
            }
        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rng.Next(0, 50);
            }
        }

        private static void ReverseArray(int[] array)
        {
            int[] reversed = new int[array.Length];
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    reversed[j] = array[i];
                }
            }
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
