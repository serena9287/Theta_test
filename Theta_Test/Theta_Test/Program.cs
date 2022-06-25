using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Theta_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "../../../Resources/weather.txt";

            List<string> lines = new List<string>();
            List<Weather> weathers = new List<Weather>();

            lines = File.ReadAllLines(filePath).ToList();

            lines.RemoveRange(0, 8);
            int listLength = lines.Count;
            lines.RemoveRange(listLength - 2, 2); //remove the last 2 lines

            //get the first day temp 
            string[] firstDaySubs = GetFirstThree(lines[0]);

            int smallestTempDiff = GetTempDiff(firstDaySubs);
            int smallestTempDiffDate = 1;

            foreach(String item in lines)
            {
                string[] subs = GetFirstThree(item);
                Weather w = new Weather(Int32.Parse(subs[0]), GetTempDiff(subs));
                weathers.Add(w);

                if (w.tempDiff < smallestTempDiff) 
                {
                    smallestTempDiff = w.tempDiff;
                    smallestTempDiffDate = Int32.Parse(subs[0]);
                }
            }

            Console.WriteLine("Date with smallest temperature difference");
            Console.WriteLine("Date: {0} Temp Diff: {1}", smallestTempDiffDate, smallestTempDiff);
        }

        static string[] GetFirstThree(string line)
        {
            char[] separators = new char[] { ' ', '*' };
            string firstThree = line.Substring(0, 16);
            return firstThree.Split(separators, StringSplitOptions.RemoveEmptyEntries);          
        }

        static int GetTempDiff(string[] tempData)
        {
            return Int32.Parse(tempData[1]) - Int32.Parse(tempData[2]);
        }
    }
}
 
