using System;
using System.Linq;
using System.Collections.Generic;

namespace Regnvejrsstatistik {
    class Program {
        public static void Main() {
            Console.Write("How many data values to initialize? (usize): ");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter {0} Rain downpour datavalues (double+space+double): ", size);
            double[] data = new double[size];
            Console.WriteLine(data.Length);

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
                Console.Write("Write out (Average: 0), (Min: 1), (Max: 2), (Median: 3), (Values: 4), (Exit: 5): ");
                int menuOption = int.Parse(Console.ReadLine());

                if (menuOption == 5)
                    System.Environment.Exit(1);

                if (menuOption == 4) {
                    stat1.Print();
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
                Console.WriteLine("Value num: {0} \t{1} ", i+1, this._values[i]); // deleting the string formatting messes up the program somehow??
            Console.WriteLine("");
        }
    }
}