using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorts.Tests.MS
{
    [TestClass]
    public class ArrayExtensionTests
    {
        #region Quick Sort tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_ArrayIsNull_ThrowArgumentNullException()
        {
            int[] array = null;
            array.QuickSort();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickSort_ArrayIsEmpty_ThrowArgumentException()
        {
            new int[] { }.MergeSort();
        }

        [TestMethod]
        [DataRow(new int[] { -255, 10, int.MaxValue, int.MinValue },
            new int[] { int.MinValue, -255, 10, int.MaxValue })]
        [DataRow(new int[] { 5, -10, -50, 15 }, new int[] { -50, -10, 5, 15 }, DisplayName = "Array with few elements")]
        [DataRow(new int[] { 5 }, new int[] { 5 }, DisplayName = "Array with one element")]
        public void QuickSort_ConcreteArray_ArrayIsSorted(int[] given, int[] expected)
        {
            given.QuickSort();
            CollectionAssert.AreEqual(expected, given);
        }

        [TestMethod]
        [DataRow(1000)]
        [DataRow(1000000)]
        public void QuickSort_RandomArray_ArrayIsSorted(int amountOfElements)
        {
            var array = ArrayGenerator.GetRandomSequence(amountOfElements, -10000, 10000);
            array.QuickSort();
            Assert.IsTrue(array.IsOrdered());
        }

        [TestMethod]
        [DataRow(1000)]
        public void QuickSort_IncreasingSequence_ArrayIsSorted(int amountOfGeneratedValues)
        {
            int[] source = Enumerable.Range(0, amountOfGeneratedValues).ToArray();
            var arrayToShake = new int[amountOfGeneratedValues];
            Array.Copy(source, arrayToShake, amountOfGeneratedValues);
            arrayToShake.Shake();
            arrayToShake.QuickSort();
            CollectionAssert.AreEqual(source, arrayToShake);
        }

        #endregion

        #region Merge Sort tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_ArrayIsNull_ThrowArgumentNullException()
        {
            int[] array = null;
            array.MergeSort();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeSort_ArrayIsEmpty_ThrowArgumentException()
        {
            new int[] { }.MergeSort();
        }

        [TestMethod]
        [DataRow(new int[] { 5, -10, -50, 15 }, new int[] { -50, -10, 5, 15 }, DisplayName = "Array with few elements")]
        [DataRow(new int[] { 1 }, new int[] { 1 })]
        public void MergeSort_ConcreteArray_ArrayIsSorted(int[] given, int[] expected)
        {
            given.MergeSort();
            CollectionAssert.AreEqual(expected, given);
        }

        [TestMethod]
        [DataRow(1000)]
        [DataRow(1000000)]
        public void MergeSort_RandomArray_ArrayIsSorted(int amountOfElements)
        {
            var array = ArrayGenerator.GetRandomSequence(amountOfElements, int.MinValue, int.MaxValue);
            array.MergeSort();
            Assert.IsTrue(array.IsOrdered());
        }

        [TestMethod]
        [DataRow(1000)]
        public void MergeSort_IncreasingSequence_ArrayIsSorted(int amountOfGeneratedValues)
        {
            int[] source = Enumerable.Range(0, amountOfGeneratedValues).ToArray();
            var arrayToShake = new int[amountOfGeneratedValues];
            Array.Copy(source, arrayToShake, amountOfGeneratedValues);
            arrayToShake.Shake();
            arrayToShake.MergeSort();
            CollectionAssert.AreEqual(source, arrayToShake);
        }

        #endregion

        #region IsOrdered method tests
        [DataTestMethod]
        [DataRow(new int[] { 1, -5, 50, 5, 8, 6, 8 })]
        public void IsOrdered_UnorderedArray_ReturnFalse(int[] unordered)
        {
            Assert.IsFalse(unordered.IsOrdered());
        }

        [DataTestMethod]
        [DataRow(new int[] { -55, 0, 1, 1, 5, 8, 11, 12 })]
        public void IsOrdered_OrderedArray_ReturnTrue(int[] ordered)
        {
            Assert.IsTrue(ordered.IsOrdered());
        }
        #endregion

        #region FilterArrayByKey tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterArrayByKey_ArrayIsNull_ThrowArgumentNullException()
        {
            int[] array = null;
            array.FilterArrayByKey(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterArrayByKey_ArrayIsEmpty_ThrowArgumentException()
        {
            new int[] { }.FilterArrayByKey(1);
        }

        [TestMethod]
        [DataRow(-10)]
        [DataRow(19)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterArrayByKey_NotDigit_ThrowArgumentOutOfRangeException(int notADigitNumber)
        {
            new int[] { 1, 2, 3 }.FilterArrayByKey(notADigitNumber);
        }

        [TestMethod]
        [DataRow(new int[] { -5, -55, 10, 8, -12, 545, 33356 }, new int[] { -5, -55, 545, 33356 }, 5)]
        [DataRow(new int[] { 1 }, new int[] { }, 2)]
        public void FilterArrayByKey_ConcreteArray_ReturnFilteredArray(int[] given, int[] expected, int digit)
        {
            int[] actual = given.FilterArrayByKey(digit);
            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion
    }
}