using System;

namespace Sorts
{
    /// <summary>
    /// Class that contains methods for generating integer arrays 
    /// with random values.
    /// </summary>
    public static class RandomHelper
    {
        /// <summary>
        /// Method for generating arrays that contain elements of random values.
        /// </summary>
        /// <param name="amountOfElements">Count of elements in generated array.</param>
        /// <returns>Generated array</returns>
        /// <exception cref="ArgumentException">Thrown when amountOfElements is less then 1.</exception>
        public static int[] GetArray(int amountOfElements)
        {
            if (amountOfElements < 0)
            {
                throw new ArgumentException(nameof(amountOfElements));
            }

            Random random = new Random();
            var randomNumbers = new int[amountOfElements];
            for (int i = 0;  i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = random.Next(-10000, 10000);
            }

            return randomNumbers;
        }
    }
}
