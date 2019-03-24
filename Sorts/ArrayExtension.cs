using System;
using System.Collections.Generic;

namespace Sorts
{
    /// <summary>
    /// Class that provides two sorting methods for integer arrays.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Method returns index of element for which the sum of the elements to the left of it
        /// is equal to the sum on the right. 
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <param name="accuracy">Accuracy value.</param>
        /// <returns>Index of element for which elements to the right equal to elements to the left.</returns>
        public static int? FindIndex(this double[] array, double accuracy)
        {
            CheckArray(array);
            CheckAccuracy(accuracy);
            double sumOfElementsFromLeft = 0;
            double sumOfElementsFromRight = GetSumOfArrayElements(array, 1, array.Length - 1);
            for (int i = 1; i < array.Length - 1; i++)
            {
                sumOfElementsFromLeft += array[i - 1];
                sumOfElementsFromRight -= array[i];
                if (Math.Abs(sumOfElementsFromLeft - sumOfElementsFromRight) <= accuracy)
                {
                    return i;
                }
            }

            return null;
        }

        /// <summary>
        /// Method returns max value from unsorted array.
        /// </summary>
        /// <param name="array">Unsorted array.</param>
        /// <returns>Max element in array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when amount of element in array is 0.</exception>
        public static int GetMaxElement(this int[] array)
        {
            CheckArray(array);
            return GetMaxElement(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Returns an array that contains only elements from source array that 
        /// are composed of the digit.
        /// </summary>
        /// <param name="array">Source array for filtering.</param>
        /// <param name="digit">Digit for filtering.</param>
        /// <returns>Filtered array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when source array is empty. </exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when digit
        /// argument doesn't represent a digit. </exception>
        public static int[] FilterArrayByKey(this int[] array, int digit)
        {
            CheckDigit(digit);
            CheckArray(array);
            var filtered = new List<int>();
            foreach (var element in array)
            {
                if (Contains(element, digit))
                {
                    filtered.Add(element);
                }
            }

            return filtered.ToArray();
        }

        /// <summary>
        /// Method that orders array ascending
        /// </summary>
        /// <param name="array">Array for sorting.</param>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static void QuickSort(this int[] array)
        {
            CheckArray(array);
            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Method that orders array ascending 
        /// </summary>
        /// <param name="array">Array for sorting.</param>
        public static void MergeSort(this int[] array)
        {
            CheckArray(array);
            MergeSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Method for determining whether given array is ordered ascending.
        /// </summary>
        /// <param name="array">Integer array.</param>
        /// <returns>True - if value is ordered ascending, otherwise - false.</returns>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static bool IsOrdered(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array));
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Changes element's order in array.
        /// </summary>
        /// <param name="array">Array that will be mixed</param>
        public static void Shake(this int[] array)
        {
            CheckArray(array);
            for (int i = 0; i < array.Length; i++)
            {
                Random random = new Random();
                int index = random.Next(array.Length);
                Swap(ref array[i], ref array[index]);
            }
        }

        #region Private methods for merge sort

        private static void MergeSort(int[] input, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            int middle = (low + high) >> 1;
            MergeSort(input, low, middle);
            MergeSort(input, middle + 1, high);
            Merge(input, low, middle, high);
        }

        private static void Merge(int[] array, int low, int middle, int high)
        {
            int left = low;
            int right = middle + 1;
            int[] temp = new int[high - low + 1];
            int index = 0;
            while (left <= middle && right <= high)
            {
                if (array[left] < array[right])
                {
                    temp[index++] = array[left++];
                }
                else
                {
                    temp[index++] = array[right++];
                }
            }

            while (left <= middle)
            {
                temp[index++] = array[left++];
            }

            while (right <= high)
            {
                temp[index++] = array[right++];
            }

            for (int i = 0; i < temp.Length; i++)
            {
                array[low + i] = temp[i];
            }
        }

        #endregion

        #region Private methods for quick sort

        private static void QuickSort(int[] unsorted, int low, int high)
        {
            if (low >= high)
            {
                return;
            }
        
            int partitioningIndex = Partition(unsorted, low, high);
            QuickSort(unsorted, low, partitioningIndex - 1);
            QuickSort(unsorted, partitioningIndex + 1, high);
        }

        private static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int indexOfCurrentMinElement = low - 1;
            for (int i = low; i <= high - 1; i++)
            {
                if (array[i] <= pivot)
                {
                    indexOfCurrentMinElement++;
                    Swap(ref array[indexOfCurrentMinElement], ref array[i]);
                }
            }

            indexOfCurrentMinElement++;
            Swap(ref array[indexOfCurrentMinElement], ref array[high]);
            return indexOfCurrentMinElement;
        }

        #endregion

        #region Additional methods 

        private static double GetSumOfArrayElements(double[] array, int startIndex, int endIndex)
        {
            double sum = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        private static void Swap(ref int firstElement, ref int secondElement)
        {
            int temp = firstElement;
            firstElement = secondElement;
            secondElement = temp;
        }

        private static void CheckAccuracy(double accuracyValue)
        {
            if (accuracyValue <= 0 || accuracyValue >= 1)
            {
                throw new ArgumentOutOfRangeException($"Accuracy has to be less than 1 and greater than 0: {nameof(accuracyValue)}.");
            }
        }

        private static void CheckDigit(int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException($"Digit must be from 0 to 9: {nameof(digit)}");
            }
        }

        private static void CheckArray<T>(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"Input array cannot be null: {nameof(array)}.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"Input array cannot be empty: {nameof(array)}.");
            }
        }
        #endregion

        #region Private methods for getting max element algorithm

        private static int GetMaxElement(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex == rightIndex)
            {
                return array[leftIndex];
            }

            int leftSubarrayMax = GetMaxElement(array, leftIndex, (leftIndex / 2) + (rightIndex / 2));
            int rightSubarrayMax = GetMaxElement(array, (leftIndex / 2) + (rightIndex / 2) + 1, rightIndex);
            return Math.Max(leftSubarrayMax, rightSubarrayMax);
        }

        #endregion

        #region Private methods for FilterArrayByKey

        private static bool Contains(int number, int digit)
        {
            for (; number != 0; number /= 10)
            {
                if (Math.Abs(number % 10) == digit)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
