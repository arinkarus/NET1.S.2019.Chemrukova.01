using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorts.Tests.MS
{
    [TestClass]
    public class ArrayExtensionTests
    {
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

        [DataTestMethod]
        [DataRow(new int[] { 5, -10, -50, 15 }, new int[] { -50, -10, 5, 15 }, DisplayName = "Array with few elements")]
        [DataRow(new int[] { 5 }, new int[] { 5 }, DisplayName = "Array with one element")]
        public void QuickSort_ConcreteArray_ArrayIsSorted(int[] given, int[] expected)
        {
            given.QuickSort();
            CollectionAssert.AreEqual(expected, given);
        }

        [DataTestMethod]
        [DataRow(1000)]
        [DataRow(1000000)]
        public void QuickSort_RandomArray_ArrayIsSorted(int amountOfElements)
        {
            var array = RandomHelper.GetRandomArray(amountOfElements);
            array.QuickSort();
            Assert.IsTrue(array.IsOrdered());
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, -5, 50, 5, 8, 6, 8 })]
        public void IsSorted_UnorderedArray_ReturnFalse(int[] unordered)
        {
            Assert.IsFalse(unordered.IsOrdered());
        }
        
        [DataTestMethod]
        [DataRow(new int[] { -55, 0, 1, 1, 5, 8, 11, 12 })]
        public void IsSorted_OrderedArray_ReturnTrue(int[] ordered)
        {
            Assert.IsTrue(ordered.IsOrdered());
        }

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

        [DataTestMethod]
        [DataRow(new int[] { 5, -10, -50, 15 }, new int[] { -50, -10, 5, 15 }, DisplayName = "Array with few elements")]
        [DataRow(new int[] { 1 }, new int[] { 1 })]
        public void MergeSort_ConcreteArray_ArrayIsSorted(int[] given, int[] expected)
        {
            given.MergeSort();
            CollectionAssert.AreEqual(expected, given);
        }

        [DataTestMethod]
        [DataRow(1000)]
        [DataRow(1000000)]
        public void MergeSort_RandomArray_ArrayIsSorted(int amountOfElements)
        {
            var array = RandomHelper.GetRandomArray(amountOfElements);
            array.MergeSort();
            Assert.IsTrue(array.IsOrdered());
        }
    }
}
