using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sorts.Tests.NUnit
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        private static IEnumerable<TestCaseData> DataCases
        {
            get
            {
                yield return new TestCaseData(arg1: new int[] { 100, 6, -8, 11 }, arg2: new int[] { -8, 6, 11, 100 });
                yield return new TestCaseData(arg1: new int[] { 1 }, arg2: new int[] { 1 });
            }
        }

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
            var array = RandomHelper.GetRandomArray(amountOfGeneratedValues);
            array.QuickSort();
            Assert.That(array, Is.Ordered);
        }
        
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
            var array = RandomHelper.GetRandomArray(amountOfGeneratedValues);
            array.MergeSort();
            Assert.That(array, Is.Ordered);
        }
    }
}
