using System;

namespace SeedGenerator {
    public static class SeedGenerator {
        private static string charactersAvailable = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static Random r = new System.Random();

        public static string GenerateRandomSeed(int length) {
            string seed = String.Empty;
            char[] characterSeed1 = CreateCharacterSeed(length);
            char[] characterSeed2 = CreateCharacterSeed(length);

            seed = new string(characterSeed1).ToUpper();
            seed += new string(characterSeed2).ToUpper();

            return seed;
        }

        private static char[] CreateCharacterSeed(int seedLength) {
            var result = new char[seedLength];

            for (int i = 0; i < result.Length; i++) {
                result[i] = charactersAvailable[r.Next(charactersAvailable.Length)];
            }

            return result;
        }

        private static char[] CreateCharacterSeed(string seed) {
            var result = new char[seed.Length];

            for (int i = 0; i < result.Length; i++) {
                result[i] = seed[i];
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
