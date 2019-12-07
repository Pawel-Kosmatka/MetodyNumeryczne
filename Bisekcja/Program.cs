using System;

namespace Bisekcja
{
    class Program
    {
        static double getValue(string xName)
        {
            double x;
            Console.WriteLine($"Podaj {xName}: ");
            while (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Zła wartość... podaj jeszcze raz:");
            }
            return x;
        }
        static double F(double x)
        {
            return x * x * x * (x + Math.Sin(x * x - 1) - 1) - 1;
            //return x * x - 2;
            //return Math.Exp(-x) - Math.Sin(Math.PI * x / 2);
        }

        static void Main(string[] args)
        {
            double x1 = getValue(nameof(x1));
            double x2 = getValue(nameof(x2));
            const double EPS = 0.0000000001;
            const double EPS0 = 0.0000000001;
            double fx1 = F(x1);
            double fx2 = F(x2);

            if (Math.Sign(fx1) == Math.Sign(fx2))
            {
                Console.WriteLine("Wartości funkcji mają ten sam znak, koniec programu...");
                return;
            }

            if (fx1 == 0)
            {
                Console.WriteLine($"Pierwiastek jest w pukcie {x1} ");
                return;
            }
            else if (fx2 == 0)
            {
                Console.WriteLine($"Pierwiastek jest w pukcie {x2} ");
                return;
            }

            while (true)
            {
                var x = (x1 + x2) / 2;
                var fx = F(x);
                if (fx == 0 || Math.Abs(fx) < EPS0)
                {
                    Console.WriteLine($"Pierwiastek jest w pukcie {x}, f(x) = {fx}");
                    break;
                }
                if (Math.Sign(fx1) != Math.Sign(fx))
                {
                    x2 = x;
                    fx2 = fx;
                }
                else
                {
                    x1 = x;
                    fx1 = fx;
                }
                if (Math.Abs(x2 - x1) <= EPS)
                {
                    Console.WriteLine($"x1 - x2 < EPS");
                    Console.WriteLine($"x: {x} : fx: {fx}");
                    break;
                }
                Console.WriteLine($"x1: {x1} : fx1: {fx1}, x2: {x2} : fx2: {fx2}");
            }
        }
    }
}
