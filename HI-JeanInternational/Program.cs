﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HI_JeanInternational
{
    class Program
    {
        static IDictionary<string, double> namesAndRatings = new Dictionary<string, double>();
        static List<string> CHEMICALLIST = new List<string>() { };
        static void Main(string[] args)
        {
            //Start Menu
            Console.WriteLine("-------------------------------------------------------------------------\n" +
                "Welcome.\n" +
                "Use this App to calculate the efficiency rating of chemicals.\n" +
                "-------------------------------------------------------------------------\n" +
                "Please choose an option:\n" +
                "1. Enter the number of germs myself.\n" +
                "2. Use a randomly generated number of germs.");
            int userOrComputer = InputChecker(1,2);

            //Run the method once so that they get at least one chemical done
            RatingCalculator(userOrComputer);

            //Loop that will mean they can test as many chemicals as they want
            bool flag = true;
            while (flag) 
            {
                Console.WriteLine("Do you want to test another chemical?\n" +
                    "1: Yes\n" +
                    "2: No");
                int stopOrGo = InputChecker(1,2);

                if (stopOrGo == 1)
                {
                    RatingCalculator(userOrComputer);
                }
                else
                {
                    flag = false;
                }

            }

            //Rank all the chemicals and diplay the info to the user
            Console.WriteLine("\nThe final rating for each chemical ranked form lowest to highest:");
            foreach (KeyValuePair<string, double> chemical in namesAndRatings.OrderBy(key => key.Value))
            {
                Console.WriteLine($"Chemical Name: {chemical.Key}, Rating: {chemical.Value}");
            }

            Console.WriteLine("\nThank you for using my program. Have a nice day!");
            

        }
        static void RatingCalculator(int userOrComputer) 
        {
            double numGerms = 0;
            List<double> CHEMICALRATINGS = new List<double>() { };

            //User inputs the Data
            Console.WriteLine("\nWhat Chemical are you testing?");
            string chemicalName = ChemicalChecker();

            //A comment so that the user knows what is happening
            Console.WriteLine("\nThe following process will repeat 5 times for a more accurate result.\n");

            for (int i = 1; i < 2; i++)
            {
                if (userOrComputer == 1)
                {
                   Console.WriteLine($"\n{i}: How many germs are you starting off with?");
                    numGerms = InputChecker(1,1000);
                }
                else
                {
                   Random rnd = new Random();
                   numGerms = rnd.Next(1, 1001);
                   Console.WriteLine($"{i}: You are starting off with {numGerms} germs.");
                }
                Console.WriteLine($"{i}: {chemicalName} is being added to {numGerms} germs. How long (in seconds) was this done for?");
                float killTime = InputChecker(1,600);

                Console.WriteLine($"{i}: How many Germs were left after the time was up?");
                int remainingGerms = InputChecker(1,1000);

                //The rating is calculated
                double chemRating = Math.Round((numGerms - remainingGerms) / killTime,3);

                //The rating is added to the list containing all the ratings
                CHEMICALRATINGS.Add(chemRating);
            }
            //Average rating is calculated
            double finalChemAverage = Queryable.Average(CHEMICALRATINGS.AsQueryable());
            Console.WriteLine($"The final rating for {chemicalName} is {finalChemAverage}\n");

            //Chemical and it's rating is added to list containing all chemicals and list containing all ratings
            namesAndRatings.Add(chemicalName,finalChemAverage);
            CHEMICALLIST.Add(chemicalName);
        }

        static int InputChecker(int valueMin, int valueMax)
        {
            while(true) 
            {
                try
                {
                    int userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput >= valueMin && userInput <= valueMax)
                    {
                        return userInput;
                    }
                    else 
                    {
                        Console.WriteLine($"ERROR! Must be an integer between {valueMin} and {valueMax}.\n");
                    }
                }
                catch
                {
                    Console.WriteLine($"ERROR! Must be an integer between {valueMin} and {valueMax}.\n");
                }
            }
        }

        static string ChemicalChecker() 
        {
            while (true)
            {
                string userInput = Console.ReadLine();

                if (CHEMICALLIST.Contains(userInput))
                {
                    Console.WriteLine("ERROR! You cannot enter the same Chemical twice.");
                }
                else 
                {
                    return userInput;
                }
            }
        }
    }
}
