using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorts.Tests.NUnit
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        private static IEnumerable<TestCaseData> DataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new int[] { 1, int.MinValue, 8, 11, int.MaxValue }, arg2: new int[] { int.MinValue, 1, 8, 11, int.MaxValue });
                yield return new TestCaseData(arg1: new int[] { 100, 6, -8, 11 }, arg2: new int[] { -8, 6, 11, 100 });
                yield return new TestCaseData(arg1: new int[] { 1 }, arg2: new int[] { 1 });
            }
        }

        #region Quick Sort tests

        [Test]
        public void QuickSort_ArrayIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.QuickSort(null));

        [Test]
        public void QuickSort_ArrayIsEmpty_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => new int[] { }.QuickSort());

        [TestCaseSource(nameof(DataCases))]
        public void QuickSort_ConcreteArray_ArrayIsSorted(int[] given, int[] expected)
        {
            given.QuickSort();
            Assert.That(given, Is.EqualTo(expected));
        }

        [TestCase(1000)]
        [TestCase(1000000)]
        public void QuickSort_RandomArray_ArrayIsSorted(int amountOfGeneratedValues)
        {
            var array = ArrayGenerator.GetRandomSequence(amountOfGeneratedValues);
            array.QuickSort();
            Assert.That(array, Is.Ordered);
        }

        [TestCase(1000)]
        [TestCase(10000)]
        public void QuickSort_IncreasingSequence_ArrayIsSorted(int amountOfGeneratedValues)
        {
            var increasingArray = ArrayGenerator.GetIncreasingArray(amountOfGeneratedValues);
            var arrayToShake = new int[amountOfGeneratedValues];
            Array.Copy(increasingArray, arrayToShake, amountOfGeneratedValues);
            arrayToShake.Shake();
            arrayToShake.QuickSort();
            CollectionAssert.AreEqual(increasingArray, arrayToShake);
        }

        #endregion

        #region Merge Sort tests

        [Test]
        public void MergeSort_ArrayIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.MergeSort(null));

        [Test]
        public void MergeSort_ArrayIsEmpty_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => new int[] { }.MergeSort());

        [TestCaseSource(nameof(DataCases))]
        public void MergeSort_ConcreteArray_ArrayIsSorted(int[] given, int[] expected)
        {
            given.MergeSort();
            Assert.That(given, Is.EqualTo(expected));
        }

        [TestCase(1000)]
        [TestCase(1000000)]
        public void MergeSort_RandomArray_ArrayIsSorted(int amountOfGeneratedValues)
        {
            var array = ArrayGenerator.GetRandomSequence(amountOfGeneratedValues);
            array.MergeSort();
            Assert.That(array, Is.Ordered);
        }

        [TestCase(1000)]
        [TestCase(10000)]
        public void MergeSort_IncreasingSequence_ArrayIsSorted(int amountOfGeneratedValues)
        {
            var increasingArray = ArrayGenerator.GetIncreasingArray(amountOfGeneratedValues);
            var arrayToShake = new int[amountOfGeneratedValues];
            Array.Copy(increasingArray, arrayToShake, amountOfGeneratedValues);
            arrayToShake.Shake();
            arrayToShake.MergeSort();
            CollectionAssert.AreEqual(increasingArray, arrayToShake);
        }

        #endregion

        #region FindMax tests

        [TestCase(10)]
        [TestCase(1000)]
        [TestCase(100000)]
        public void GetMaxElement_RandomArray_ReturnMaxValue(int amountOfGeneratedValues)
        {
            var randomizedArray = ArrayGenerator.GetRandomSequence(amountOfGeneratedValues);
            int expected = randomizedArray.Max();
            int actual = randomizedArray.GetMaxElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { -1, 5, 88, 10, -10 }, 88)]
        [TestCase(new int[] { 6, int.MaxValue, int.MaxValue, int.MinValue, 1, 2, }, int.MaxValue)]
        [TestCase(new int[] { 33 }, 33)]
        [TestCase(new int[] { -55, -55, -45, -10000 }, -45)]
        public void GetMaxElement_ConcreteArray_ReturnMaxValue(int[] given, int expected)
        {
            int actual = given.GetMaxElement();
            Assert.AreEqual(expected, actual);
        }

        public void GetMaxElement_ArrayIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.GetMaxElement(null));

        public void GetMaxElement_ArrayIsEmpty_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => new int[] { }.GetMaxElement());

        #endregion

        #region FilterArrayByKey tests
        
        public void FilterArrayByKey_ArrayIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.FilterArrayByKey(null, 12));

        public void FilterArrayByKey_ArrayIsEmpty_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => new int[] { }.FilterArrayByKey(12));

        [TestCase(-88)]
        [TestCase(211)]
        public void FilterArrayByKey_NotDigit_ThrowArgumentOutOfRangeException(int notADigitNumber)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new int[] { }.FilterArrayByKey(notADigitNumber));
        }

        [TestCase(new int[] { 1 }, new int[] { }, 2)]
        [TestCase(new int[] { 24, 42, -4444, -4, 4, -4, 22, -788 },
            new int[] { 24, 42, -4444, -4, 4, -4 }, 4)]
        public void FilterArrayByKey_ConcreteArray_ReturnFilteredArray(int[] given, int[] expected, int digit)
        {
            int[] actual = given.FilterArrayByKey(digit);
            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion
    }
}
