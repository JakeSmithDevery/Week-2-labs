using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //read file
            string filePath = @"C:\Users\S00234729\Downloads\results.txt";
            string[] fileContents = File.ReadAllLines(filePath);

            //call calc method
            int totalPoints = CalculatePoints(fileContents);

            //output on screen
            Console.WriteLine($"The total points are {totalPoints}");

            //pause
            Console.ReadLine();
        }

        private static int CalculatePoints(string[] data)
        {
            int[] gradeBoundaries = new int[8] {90, 80, 70, 60, 50, 40, 30, 0 };
            int[] higherPoints = new int[8] { 100, 88, 77, 66, 56, 46, 37, 0 };

            //calc points
            int totalPoints = 0, points = 0, result = 0;

            for (int i = 0; i < data.Length; i++)
            {
                result = Convert.ToInt32(data[i]);

                for (int j = 0; j < gradeBoundaries.Length; j++)
                {
                    if (result >= gradeBoundaries[j])
                    {
                        points = higherPoints[j];
                        break;
                    }

                }

                totalPoints += points;

            }

            return totalPoints;

        }

        
    }
}
