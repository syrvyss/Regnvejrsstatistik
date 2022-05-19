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

            Console.Write("Write out (Average: 0), (Min: 1), (Max: 2), (Exit: 3)");
            
            while (true) {
                double result = int.Parse(Console.ReadLine()) switch {
                    0 => Statistics.Average(a),
                    1 => Statistics.Min(a),
                    2 => Statistics.Max(a),
                    3 => 0x0 // TODO
                };
                Console.WriteLine(result);
            }
        }
    }

    class Statistics {
        public static double Average(double[] a) => a.Average();
        public static double Min(double[] a) => a.Min();
        public static double Max(double[] a) => a.Max();
    }
}