using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_5
{
    internal class Program
    {
        static void Main()
        {
            //get student and subject info
            Console.WriteLine("Enter your name : ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your student number : ");
            string studentnumber = Console.ReadLine();

            string[] subjects = new string[7];
            string[] levels = new string[7];
            string[] results = new string[7];
            int[] points = new int[7];

            for (int i = 0; i < 7; i++) 
            {
                Console.Write($"Enter subject name {i + 1} : ");
                subjects[i] = Console.ReadLine();

                Console.Write($"Enter subject level for {subjects[i]} : ");
                levels[i] = Console.ReadLine();

                Console.Write($"Enter subject result for {subjects[i]} : ");
                results[i] = Console.ReadLine();
            }

            //get results
            int totalPoints = CalculatePoints(results, levels, points);

            //display results
            DisplayResults(name, studentnumber, subjects, results, levels, points, totalPoints);

            //write to file
            WriteDetailsToFile(name, studentnumber, subjects, results, levels, points, totalPoints);

            Console.ReadLine();
        }
    }
}
