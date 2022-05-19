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
        }
    }
}