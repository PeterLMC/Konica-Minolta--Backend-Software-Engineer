using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace AbsoluteDiagonalTests
{
    public class AbsoluteDiagonalsOfAnArrayTestData
    {
        public static List<List<int>> FinePositiveArray()
        {
            int squareLength = 3;
            List<List<int>> lists = new List<List<int>>((squareLength));
            lists.Add(new List<int>(1)
            {
                squareLength
            });
            lists.Add(new List<int>() { 1, 2, 3 });
            lists.Add(new List<int>() { 10, 8, 3 });
            lists.Add(new List<int>() { 6, 1, 5 });
            return lists;
        }
        public static int FinePositiveArrayResult 
        {
            get 
            {


                return 3;
            }
        }

        public static List<List<int>> FineNegativeArray()
        {
            int squareLength = 3;
            List<List<int>> lists = new List<List<int>>((squareLength));
            lists.Add(new List<int>(1)
            {
                squareLength
            });
            lists.Add(new List<int>() { 1, 2, 3 });
            lists.Add(new List<int>() { 10, -8, 3 });
            lists.Add(new List<int>() { 6, 1, 5 });
            return lists;
        }

        public static object FineNegativeArrayResult
        {
            get
            {
                return 3;
            }
        }

        public static List<List<int>> FineNBynArray(int squareLength)
        {
            List<List<int>> lists = new List<List<int>>((squareLength));
            lists.Add(new List<int>(1)
            {
                squareLength
            });
            for (int i = 1; i < (squareLength + 1); i++)
            {
                lists.Add(new List<int>());
                for (int j = 0; j < squareLength; j++) 
                {
                    lists[i].Add(1);
                }
            }
            return lists;
           
        }
        public static object FineArrayResult
        {
            get
            {
                return 0;
            }
        }

        public static List<List<int>> BadArrayLengthData()
        {
            int squareLength = 1;
            List<List<int>> lists = new List<List<int>>((squareLength + 1));
            lists.Add(new List<int>(1)
            {
                squareLength
            });

            return lists;
        }

        public static List<List<int>> NotASquareArray()
        {
            int squareLength = 3;
            List<List<int>> lists = new List<List<int>>((squareLength + 1));
            lists.Add(new List<int>(1)
            {
                squareLength
            });
            lists.Add(new List<int>() { 1, 2 });
            lists.Add(new List<int>() { 10, 8, 3 });
            lists.Add(new List<int>() { 6, 1, 5 });
            return lists;
        }

        public static List<List<int>> BadSquareLengthIndicatorParameter()
        {
            int squareLength = 1;
            List<List<int>> lists = new List<List<int>>((squareLength + 1));
            lists.Add(new List<int>(1)
            {
                squareLength
            });

            lists.Add(new List<int>() { 1, 2, 3});
            lists.Add(new List<int>() { 10, 8, 3 });
            lists.Add(new List<int>() { 6, 1, 5 });

            return lists;
        }
        public static IEnumerable<object[]> Data()
        {
            yield return new object[]
            {
                FineNegativeArray(),
                FineNegativeArrayResult,

            };
            yield return new object[]
            {
                FinePositiveArray(),
                FinePositiveArrayResult
            };
            yield return new object[]
            {
                FineNBynArray(10),
                FineArrayResult
            };
        }

    }
}
