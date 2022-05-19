using System;
using System.Linq;

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
                System.Environment.Exit(1);
            }

            for (int i = 0; i < size; i++) {
                data[i] = double.Parse(a[i]);
            }

            Statistics stat1 = new Statistics(data);
            
            while (true) {
                Console.Write("Write out (Average: 0), (Min: 1), (Max: 2), (Values: 3), (Exit: 4): ");
                int menuOption = int.Parse(Console.ReadLine());

                if (menuOption == 4)
                    System.Environment.Exit(1);

                if (menuOption == 3) {
                    stat1.Print();
                    continue;
                }

                try {
                    double result = menuOption switch {
                        0 => stat1.Average(),
                        1 => stat1.Min(),
                        2 => stat1.Max(),
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
        public void Print() {
            for (int i = 0; i < this._values.Length; i++)
            {
                Console.WriteLine("Value num: {0} \t{1} ", i+1, this._values[i]); // deleting the string formatting messes up the program somehow??
            }
            Console.WriteLine("");
        }
    }
}