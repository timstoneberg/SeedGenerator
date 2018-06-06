using System;

namespace SeedGenerator {
    public static class SeedGenerator {
        private static string charactersAvailable = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static Random r = new System.Random();

        public static string GenerateRandomSeed(int length) {
            string seed = String.Empty;
            char[] characterSeed1 = CreateCharacterSeed(length / 2);
            char[] characterSeed2 = CreateCharacterSeed(length / 2);

            seed = new string(characterSeed1).ToUpper();
            seed += new string(characterSeed2).ToUpper();

            return seed;
        }

        public static int ConvertToNumeric(string stringSeed) {
            string part1 = string.Empty;
            string part2 = string.Empty;
            int valueOffset = 1;

            string stringSeed1 = stringSeed.Substring(0, stringSeed.Length / 2);
            string stringSeed2 = stringSeed.Substring(stringSeed.Length / 2, stringSeed.Length / 2);

            char[] charSeed1 = CreateCharacterSeed(stringSeed1);
            char[] charSeed2 = CreateCharacterSeed(stringSeed2);

            for (int i = 0; i < charSeed1.Length; i++) {
                part1 += (valueOffset + charactersAvailable.IndexOf(charSeed1[i])).ToString();
            }
            for (int i = 0; i < charSeed2.Length; i++) {
                part2 += (valueOffset + charactersAvailable.IndexOf(charSeed2[i])).ToString();
            }

            int result1 = Int32.Parse(part1);
            int result2 = Int32.Parse(part2);

            return (result1 * 2) + (result2 * 2);
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
            result *= 2;
            return result;
        }
    }
}
