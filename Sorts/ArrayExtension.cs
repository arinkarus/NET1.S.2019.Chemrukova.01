using System;

namespace Sorts
{
    /// <summary>
    /// Class that provides two sorting methods for integer arrays.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Method that orders array ascending using Quick Sort algorithm.
        /// </summary>
        /// <param name="array">Array for sorting.</param>
        /// <exception cref="ArgumentNullException">Thrown when array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty.</exception>
        public static void QuickSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array));
            }

            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Method that orders array ascending using Merge Sort algorithm.
        /// </summary>
        /// <param name="array">Array for sorting.</param>
        public static void MergeSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array));
            }

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

        private static void MergeSort(int[] input, int low, int high)
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                MergeSort(input, low, middle);
                MergeSort(input, middle + 1, high);
                Merge(input, low, middle, high);
            }
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

        private static void QuickSort(int[] unsorted, int low, int high)
        {
            if (low < high)
            {
                int partitioningIndex = Partition(unsorted, low, high);
                QuickSort(unsorted, low, partitioningIndex - 1);
                QuickSort(unsorted, partitioningIndex + 1, high);
            }
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
         
        private static void Swap(ref int firstElement, ref int secondElement)
        {
            int temp = firstElement;
            firstElement = secondElement;
            secondElement = temp;
        }
    }
}
