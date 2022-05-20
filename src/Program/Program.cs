using System;
using System.Linq;
using System.Collections.Generic;

namespace Regnvejrsstatistik {
    class Program {
        public static void Main() {
            Console.Write("How many data values to initialize? (usize): ");
            int size;
            string input = Console.ReadLine();

            bool valuesParsed = int.TryParse(input, out size);

            if (!valuesParsed) {
                Console.WriteLine("Sorry, exiting program.");
                Console.ReadLine();
                System.Environment.Exit(1);
            }

            Console.WriteLine("Enter {0} Rain downpour datavalues (double+space+double): ", size);
            double[] data = new double[size];

            string[] a = Console.ReadLine().Split(" ");
            if (a.Length != size) {
                Console.WriteLine("Your data got cut off: size is {0} but you typed in {1} values! Exiting program.", size, a.Length);
                Console.Clear();
                System.Environment.Exit(1);
            }

            for (int i = 0; i < size; i++) {
                data[i] = double.Parse(a[i]);
            }

            Statistics stat1 = new Statistics(data);

            while (true) {
                Console.Clear();
                Console.Write("Write out (Average: 0), (Min: 1), (Max: 2), (Median: 3), (Values: 4), (Exit: 5): ");
                int menuOption;
                string str = Console.ReadLine();

                bool parsed = int.TryParse(str, out menuOption);

                if (!parsed) {
                    Console.WriteLine("Try again.");
                    continue;
                }

                if (menuOption == 5)
                    System.Environment.Exit(1);

                if (menuOption == 4) {
                    stat1.Print();
                    Console.ReadLine();
                    continue;
                }

                try {
                    double result = menuOption switch {
                        0 => stat1.Average(),
                        1 => stat1.Min(),
                        2 => stat1.Max(),
                        3 => stat1.Median(),
                        _ => throw new Exception()
                    };

                    Console.WriteLine(result);
                }
                catch (Exception e) {
                    Console.WriteLine("Sorry, try again.");
                }
                Console.ReadLine();
            }
        }
    }

    class Statistics {
        double[] _values;

        public Statistics(double[] a) {
            this._values = a;
        }

        public double Average() => this._values.Average();
        public double Min() => this._values.Min();
        public double Max() => this._values.Max();
        public double Median() {
            double[] a = this._values;
            Array.Sort(a);

            if (a.Length % 2 == 0)
                return (a[a.Length / 2 - 1] + a[a.Length / 2]) / 2;
            else
                return a[a.Length / 2];
        } 
        public void Print() {
            for (int i = 0; i < this._values.Count(); i++)
                Console.WriteLine("Value num: {0} \t{1} ", i+1, this._values[i]);
            Console.WriteLine("");
        }
    }
}