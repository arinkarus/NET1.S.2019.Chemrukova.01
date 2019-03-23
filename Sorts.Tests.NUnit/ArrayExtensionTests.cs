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
            var array = ArrayGenerator.GetRandomSequence(amountOfGeneratedValues, -500, 500);
            array.QuickSort();
            Assert.That(array, Is.Ordered);
        }

        [TestCase(1000)]
        [TestCase(10000)]
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
            Assert.That(expected, Is.EqualTo(given));
        }

        [TestCase(1000)]
        [TestCase(1000000)]
        public void MergeSort_RandomArray_ArrayIsSorted(int amountOfGeneratedValues)
        {
            var array = ArrayGenerator.GetRandomSequence(amountOfGeneratedValues, -1000, 1000);
            array.MergeSort();
            Assert.That(array, Is.Ordered);
        }

        [TestCase(1000)]
        [TestCase(10000)]
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

        #region FindMax tests

        [TestCase(10)]
        [TestCase(1000)]
        [TestCase(100000)]
        public void GetMaxElement_RandomArray_ReturnMaxValue(int amountOfGeneratedValues)
        {
            var randomizedArray = ArrayGenerator.GetRandomSequence(amountOfGeneratedValues, -10000, 10000);
            int expected = randomizedArray.Max();
            int actual = randomizedArray.GetMaxElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { -1, 5, 88, 10, -10 }, 88)]
        [TestCase(new int[] { 6, int.MaxValue, int.MaxValue, int.MinValue, 1, 2, }, int.MaxValue)]
        [TestCase(new int[] { 33 }, 33)]
        [TestCase(new int[] { -55, -55, -45, -10000 }, -45)]
        public void GetMaxElement_ConcreteArray_ReturnMaxElement(int[] given, int expected)
        {
            int actual = given.GetMaxElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase()]
        public void GetMaxElement_BigArray_ReturnMaxElement()
        {
            int[] source = Enumerable.Range(0, 10000000).ToArray();
            source.Shake();
            int maxValue = source.GetMaxElement();
        }

        public void GetMaxElement_ArrayIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.GetMaxElement(null));

        public void GetMaxElement_ArrayIsEmpty_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => new int[] { }.GetMaxElement());

        #endregion

        #region FilterArrayByKey tests
        
        public void FilterArrayByKey_ArrayIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.FilterArrayByKey(null, 12));

        public void FilterArrayByKey_ArrayIsEmpty_ThrowArgumentException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => new int[] { }.FilterArrayByKey(12));

        [TestCase(-88)]
        [TestCase(211)]
        public void FilterArrayByKey_NotDigit_ThrowArgumentOutOfRangeException(int notADigitNumber) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => new int[] { }.FilterArrayByKey(notADigitNumber));
        
        [TestCase(new int[] { 1 }, new int[] { }, 2)]
        [TestCase(new int[] { 24, 42, -4444, -4, 4, -4, 22, -788 },
            new int[] { 24, 42, -4444, -4, 4, -4 }, 4)]
        public void FilterArrayByKey_ConcreteArray_ReturnFilteredArray(int[] given, int[] expected, int digit)
        {
            int[] actual = given.FilterArrayByKey(digit);
            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region FindIndex tests

        public void FindIndex_ArrayIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.FindIndex(null, 000.1));

        public void FindIndex_ArrayIsEmpty_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => new double[] { }.FindIndex(0.001));

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(12)]
        [TestCase(-110)]
        public void FindIndex_AccuracyIsOutOfRange_ThrowArgumentOutOfRangeException(double accuracyValue) =>
            Assert.Throws<ArgumentOutOfRangeException>(() => new double[] { 0.002 }.FindIndex(accuracyValue));
      
        [TestCase(new double[] { 0.8 }, 0.1, ExpectedResult = null)]
        [TestCase(new double[] { 0.3, 0.3, 2, 0.2, 0.2, 0.2 }, 0.01, ExpectedResult = 2)]
        [TestCase(new double[] { 0.25555, 0.00001, -0.0008, 15, 5.03, 0.5551, 9.85 }, 0.001, ExpectedResult = null)]
        [TestCase(new double[] { -3, 1, -0.252,
            1000, 259, -262, -0.00001, 0.5, 0.5, -0.12, -0.12, -0.0149 }, 0.01, ExpectedResult = 3)]
        public int? FindIndex_ConcreteArray_ReturnResult(double[] source, double accuracy)
        {
            return source.FindIndex(accuracy);
        }

        [TestCase(new double[] { 0.3, 10, 0.15, 0.15 }, ExpectedResult = 1)]
        [TestCase(new double[] { 0.2, 0.1, 10, 0.15, 0.15 }, ExpectedResult = null)]
        public int? FindIndex_SmallAccuracy_ReturnNull(double[] source)
        {
            return source.FindIndex(Math.Abs(1E-20));
        }

        #endregion FindIndex tests 
    }
}
