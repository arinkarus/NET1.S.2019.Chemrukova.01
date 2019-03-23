using System;

namespace Sorts
{
    /// <summary>
    /// Class that contains methods for generating integer arrays 
    /// with random values.
    /// </summary>
    public static class ArrayGenerator
    {
        /// <summary>
        /// Method for generating arrays that contains elements of random values.
        /// </summary>
        /// <param name="amountOfElements">Count of elements in generated array.</param>
        /// <param name="lowerThreshold">Minimum value for generation</param>
        /// <param name="higherThreshold">Maximum value for generation</param>
        /// <returns>Generated array</returns>
        /// <exception cref="ArgumentException">Thrown when amountOfElements is less then 1.</exception>
        public static int[] GetRandomSequence(int amountOfElements, int lowerThreshold, int higherThreshold)
        {
            CheckNumberForPositiveValue(amountOfElements);
            Random random = new Random();
            var randomNumbers = new int[amountOfElements];
            for (int i = 0;  i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = random.Next(lowerThreshold, higherThreshold);
            }

            return randomNumbers;
        }

        private static void CheckNumberForPositiveValue(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException($"{nameof(number)} has to be greater than 0.");
            }
        }
    }
}
