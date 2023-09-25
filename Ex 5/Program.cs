using System;
using System.Collections.Generic;
using System.IO;
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

        private static void WriteDetailsToFile(string name, string studentNum, string[] subjects, string[] results, string[] levels, int[] points, int totalPoints)
        {
            StreamWriter sw = new StreamWriter("results.txt");

            sw.WriteLine($"Name : {name}");
            sw.WriteLine($"Student Number : {studentNum}");

            for (int i = 0; i < results.Length; i++)
            {
                sw.WriteLine($"{subjects[i],10} {levels[i],10} {results[i],10} {points[i],10}");
            }

            sw.WriteLine($"Total Points : {totalPoints}");

            sw.Flush();
            sw.Close();

            Console.WriteLine("Successfully written to file");
        }

        private static void DisplayResults(string name, string studentNum, string[] subjects, string[] results, string[] levels, int[] points, int totalPoints)
        {
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"Student Number : {studentNum}");

            for (int i = 0; i < results.Length; i++)
            {
                Console.WriteLine($"{subjects[i],10} {levels[i],10} {results[i],10} {points[i],10}");
            }
            Console.WriteLine($"Total Points : {totalPoints}");
        }
        private static int CalculatePoints(string[] data, string[] levels, int[] studentPoints) 
        {
            int[] gradeBoundaries = new int[] { 90, 80, 70, 60, 50, 40, 30, 0 };
            int[] higherPoints = new int[] { 100, 88, 77, 66, 56, 46, 37, 0 };
            int[] ordinaryPoints = new int[] { 56, 46, 37, 28, 20, 12, 0, 0 };

            //calc points
            int totalPoints = 0, points = 0;

            for (int i = 0; i < data.Length; i++)
            {
                int result = Convert.ToInt32(data[i]);

                for (int j = 0; j < gradeBoundaries.Length; j++)
                {
                    if (result >= gradeBoundaries[j])
                    {
                        points = levels[i].ToLower().Equals("h") ? higherPoints[j] : ordinaryPoints[j];
                        break;
                    }

                }

                studentPoints[i] = points;

            }

            //only use top 6
            Array.Sort(studentPoints);
            Array.Reverse(studentPoints);

            for (int i = 0; i < 6; i++) 
            {
                totalPoints += studentPoints[i];
            }
            return totalPoints;
        }
    }
    
}
