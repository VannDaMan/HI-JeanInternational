using System;
using System.Collections.Generic;
using System.Linq;

namespace HI_JeanInternational
{
    class Program
    {
        static IDictionary<string, float> namesAndRatings = new Dictionary<string, float>();

        static void Main(string[] args)
        {
            //Start Menu
            Console.WriteLine("Welcome.\n" +
                "Would you like to enter the data yourself or use the computer's randomly generated values?\n" +
                "1. Enter the Data Myself.\n" +
                "2. Use randomly generated values.");
            int userOrComputer = Convert.ToInt32(Console.ReadLine());

            //Run the method once so that they get at least one chemical done
            RatingCalculator(userOrComputer);

            //Loop that will mean they can test as many chemicals as they want
            bool flag = true;
            while (flag) 
            {
                Console.WriteLine("Do you want to test another chemical?\n" +
                    "1: Yes\n" +
                    "2: No\n");
                int stopOrGo = Convert.ToInt32(Console.ReadLine());

                if (stopOrGo == 1)
                {
                    RatingCalculator(userOrComputer);
                }
                else
                {
                    flag = false;
                }

            }

            Console.WriteLine("The final rating for each chemical ranked form highest to lowest:");


        }
        static void RatingCalculator(int userOrComputer) 
        {
            int numGerms = 0;
            List<float> CHEMICALRATINGS = new List<float>() { };

            //User inputs the Data
            Console.WriteLine("What Chemical are you testing?");
            string chemicalName = Console.ReadLine();

            //A comment so that the user knows what is happening
            Console.WriteLine("The following process will repeat 5 times for a more accurate result.\n");

            for (int i = 1; i < 2; i++)
            {
                if (userOrComputer == 1)
                {
                   Console.WriteLine($"{i}: How many germs are you starting off with?");
                   numGerms = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                   Random rnd = new Random();
                   numGerms = rnd.Next(1, 1001);
                   Console.WriteLine($"{i}: You are starting off with {numGerms} germs.");
                }
                Console.WriteLine($"{i}: {chemicalName} is being added to {numGerms} germs. How long (in seconds) was this done for?");
                int killTime = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"{i}: How many Germs were left after the time was up?");
                int remainingGerms = Convert.ToInt32(Console.ReadLine());

                //The rating is calculated
                float chemRating = (numGerms - remainingGerms) / killTime;

                //The rating is added to the list containing all the ratings
                CHEMICALRATINGS.Add(chemRating);
            }
            //Average rating is calculated
            float finalChemAverage = Queryable.Average(CHEMICALRATINGS.AsQueryable());
            Console.WriteLine($"The final rating for {chemicalName} is {finalChemAverage}\n");

            //Chemical and it's rating is added to list containing all chemicals and list containing all ratings
            namesAndRatings.Add($"{chemicalName}",finalChemAverage);
        }
    }
}
