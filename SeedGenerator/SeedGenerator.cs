using System;
using System.Diagnostics;

namespace SeedGenerator {

    /*  =====================================================================
         *  Generates a random seed, to be used to create random variables.
         *
         *  Usage Example:
         *      >> SeedGenerator.Seed seed = SeedGenerator.Generate(8);
         *  ================================================================= */
    public static class SeedGenerator {

        public struct Seed {
            public string StringValue { get; set; }
            public int NumericValue { get; set; }
        }

        public static char[] charactersAvailable = {
            'A','B','C','D','E',
            'F','G','H','I','J',
            'K','L','M','N','O',
            'P','Q','R','S','T',
            'U','V','W','X','Y',
            'Z','0','1','2','3',
            '4','5','6','7','8',
            '9'
        };

        public static Random random = new System.Random();

        /*  =================================================================
         *  Generates a random alphanumeric seed based on a provided length.
         *  
         *  Properties:
         *      >> length:  How many characters to make the seed
         *  ================================================================= */
        public static Seed Generate(int length) {
            Debug.Assert(length > 0 && length < 9, "Seeds must be between 1 and 8 characters!");

            char[] c = new char[length];
            for (int i = 0; i < length; i++) {
                c[i] = charactersAvailable[random.Next(0, charactersAvailable.Length - 1)];
            }

            Seed seed = new Seed();
            seed.StringValue = new string(c);
            seed.NumericValue = ToInt(seed.StringValue);
            return seed;
        }

        /*  =================================================================
         *  Converts the alphanumeric seed to an integer.
         *  
         *  Properties:
         *      >> seed:  The alphanumeric seed
         *  ================================================================= */
        private static int ToInt(string seed) {
            string s = String.Empty;

            foreach (char c in seed) {
                s += (Array.IndexOf(charactersAvailable, c) % 10).ToString();
            }
            return Int32.Parse(s);
        }
    }
}
