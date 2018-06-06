using System;

namespace SeedGenerator {
    public static class SeedGenerator {
        private static string charactersAvailable = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static Random r = new System.Random();

        public static Seed GenerateRandomSeed(int length) {
            Seed seed = new Seed();
            char[] characterSeed1 = CreateCharacterSeed(length);
            char[] characterSeed2 = CreateCharacterSeed(length);
            int numeric1 = ConvertToNumeric(characterSeed1);
            int numeric2 = ConvertToNumeric(characterSeed2);

            seed.alphaNumericSeed = new string(characterSeed1).ToUpper();
            seed.alphaNumericSeed += new string(characterSeed2).ToUpper();
            seed.numericSeed = (numeric1 * 2) + (numeric2 * 2);
            return seed;
        }

        //public static Seed GenerateRandomSeed(string seed) {
            
        //}

        private static char[] CreateCharacterSeed(int seedLength) {
            var result = new char[seedLength];

            for (int i = 0; i < result.Length; i++) {
                result[i] = charactersAvailable[r.Next(charactersAvailable.Length)];
            }

            return result;
        }

        private static int ConvertToNumeric(char[] charSeed) {
            string s = string.Empty;
            int valueOffset = 1;

            for (int i = 0; i < charSeed.Length; i++) {
                s += (valueOffset + charactersAvailable.IndexOf(charSeed[i])).ToString();
            }

            int result = Int32.Parse(s);
            return result;
        }
    }
}
