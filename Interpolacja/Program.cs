using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Interpolacja
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dataPath = AppDomain.CurrentDomain.BaseDirectory + "data.txt";
            List<double> x;
            List<double> fx;

            try
            {
                using var reader = new StreamReader(dataPath);
                x = reader.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => double.Parse(s)).ToList();
                fx = reader.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => double.Parse(s)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }

            bool isContinuing = true;
            while (isContinuing)
            {
                double xs;
                Console.WriteLine("Podaj dla jakiego 'x' obliczyć: ");
                while (!double.TryParse(Console.ReadLine(), out xs))
                {
                    Console.WriteLine("Zła wartość... podaj jeszcze raz:");
                }

                var sum = 0.0;
                for (int i = 0; i < x.Count; i++)
                {
                    double li = 1;
                    for (int j = 0; j < x.Count; j++)
                    {
                        if (i != j)
                        {
                            li *= (xs - x[j]) / (x[i] - x[j]);
                        }
                    }
                    sum += fx[i] * li;
                }

                Console.WriteLine($"Szacowany wynik to: {sum.ToString(string.Format(".##"))}");

                Console.WriteLine("Jeszcze raz? (t/n)");
                var cki = Console.ReadKey(true);
                while (cki.KeyChar != 't' && cki.KeyChar != 'n')
                {
                    Console.WriteLine("Zdecyduj się....");
                    cki = Console.ReadKey(true);
                }
                if (cki.KeyChar == 'n')
                {
                    isContinuing = false;
                }
            }
        }
    }
}