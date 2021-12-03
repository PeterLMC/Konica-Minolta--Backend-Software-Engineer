using AbsoulteDiagonal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbsoluteDiagonalTests
{
    [TestClass]
    public class AbsoulteDiagonalsOfAnArrayTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void AbsoulteDiagonalOfAnArrayTests(List<List<int>> array, int result)
        {
            int calculatedResult = AbsoulteDiagonalsOfAnArray.DiagonalDifference(array);
            Assert.AreEqual(result, calculatedResult);
        }

        [TestMethod()]
        public void NotASquareArrrayThrowsArgumentException() 
        {
            Assert.ThrowsException<ArgumentException>(() => 
            {
                List<List<int>> array = AbsoluteDiagonalsOfAnArrayTestData.NotASquareArray();
                int result = AbsoulteDiagonalsOfAnArray.DiagonalDifference(array);
            });
        }

        [TestMethod()]
        public void NullListThrowsNullArgumentException()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                List<List<int>> array = null;
                int result = AbsoulteDiagonalsOfAnArray.DiagonalDifference(array);
            });
        }

        [TestMethod()]
        public void EmptyListThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                List<List<int>> array = new List<List<int>>();
                int result = AbsoulteDiagonalsOfAnArray.DiagonalDifference(array);
            });
        }


        [TestMethod()]
        public void BadSquareLengthParameterThrowsArgumentException()
        {
            List<List<int>> array = AbsoluteDiagonalsOfAnArrayTestData
                .BadSquareLengthIndicatorParameter();

            Assert.ThrowsException<ArgumentException>(() =>
            {
                int result = AbsoulteDiagonalsOfAnArray.DiagonalDifference(array);
            });
        }

        [TestMethod()]
        public void BadArrayLengthData()
        {
            List<List<int>> array = AbsoluteDiagonalsOfAnArrayTestData.BadArrayLengthData();
            Assert.ThrowsException<ArgumentException>(() =>
            {
                int result = AbsoulteDiagonalsOfAnArray.DiagonalDifference(array);
            });
        }

        public static IEnumerable<object[]> GetData() 
        {
            return AbsoluteDiagonalsOfAnArrayTestData.Data();
        }
    }
}
