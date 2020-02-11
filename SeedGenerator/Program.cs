using System;

namespace SeedGenerator {
    class Program {
        static void Main(string[] args) {
            SeedGenerator.Seed seed = SeedGenerator.Generate(8);

            Console.WriteLine("The seed is: " + seed.StringValue);
            Console.WriteLine("The int seed is: " + seed.NumericValue.ToString());
        }
    }
}
