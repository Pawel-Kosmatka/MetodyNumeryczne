using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aproksymacja
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataPath = AppDomain.CurrentDomain.BaseDirectory + "data.txt";
            Dictionary<double, double> data = new Dictionary<double, double>();

            try
            {
                using var reader = new StreamReader(dataPath);
                var xLine = reader.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => double.Parse(s)).ToList();
                var yLine = reader.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => double.Parse(s)).ToList();
                foreach (var (xi, yi) in xLine.Zip(yLine))
                {
                    data.Add(xi, yi);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }

            double xSum = 0;
            double ySum = 0;
            double xySum = 0;
            double xPowSum = 0;
            foreach (var (xi, yi) in data)
            {
                xSum += xi;
                ySum += yi;
                xySum += xi * yi;
                xPowSum += xi * xi;
            }
            double denom = data.Count() * xPowSum - xSum * xSum;

            var a0 = (ySum * xPowSum - xSum * xySum) / denom;

            var a1 = (data.Count() * xySum - xSum * ySum) / denom;

            Console.WriteLine($"Funkcja ma postać: {a1.ToString(string.Format(".##"))}x + {a0.ToString(string.Format(".##"))}");

            Console.ReadKey();
        }
    }
}
