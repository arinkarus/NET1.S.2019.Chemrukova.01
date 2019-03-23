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
        /// <returns>Generated array</returns>
        /// <exception cref="ArgumentException">Thrown when amountOfElements is less then 1.</exception>
        public static int[] GetRandomSequence(int amountOfElements)
        {
            CheckNumberForPositiveValue(amountOfElements);
            Random random = new Random();
            var randomNumbers = new int[amountOfElements];
            for (int i = 0;  i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = random.Next(-10000, 10000);
            }

            return randomNumbers;
        }

        /// <summary>
        /// Method for generating array in which elements 
        /// are ordered ascending with step = 1
        /// </summary>
        /// <param name="amountOfElements"> Count of elements in generated array. </param>
        /// <returns>Generated array</returns>
        /// <exception cref="ArgumentException">Thrown when amountOfElements is less then 1.</exception>
        public static int[] GetIncreasingArray(int amountOfElements)
        {
            CheckNumberForPositiveValue(amountOfElements);
            var increasingArray = new int[amountOfElements];
            for (int i = 0; i < amountOfElements; i++)
            {
                increasingArray[i] = i;
            }

            return increasingArray;
        }

        private static void CheckNumberForPositiveValue(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException($"{nameof(number)} has to be greater than 0");
            }
        }
    }
}
