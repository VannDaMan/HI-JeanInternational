using System;

namespace HI_JeanInternational
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start Menu
            Console.WriteLine("Welcome.\n" +
                "Would you like to enter the data yourself or use the computer's randomly generated values?\n" +
                "1. Enter the Data Myself.\n" +
                "2. Use randomly generated values.");

            Console.WriteLine($"{RatingCalculator(1)} germs/second"); 
            
        }
        static double RatingCalculator(int userOrComputer) 
        {
            //User inputs the Data
            Console.WriteLine("How many germs are you starting off with?");
            int numGerms = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What Chemical are you testing?");
            string chemicalName = Console.ReadLine();

            Console.WriteLine($"{chemicalName} is being added to {numGerms} germs. How long (in seconds) was this done for?");
            int killTime = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many Germs were left after the time was up?");
            int remainingGerms = Convert.ToInt32(Console.ReadLine());

            //The rating is calculated
            float chemRating = (numGerms - remainingGerms) / killTime;

            //The rating is returned
            return chemRating;
        }
    }
}
