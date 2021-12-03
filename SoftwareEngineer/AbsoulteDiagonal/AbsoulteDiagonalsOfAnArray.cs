using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace AbsoulteDiagonal
{
    /// <summary>
    /// Example of good input:
    /// 3
    /// 1,3,4
    /// 2,4,8
    /// -10,3,4
    /// First list will tell as the array dimension, it will only have one element
    /// The objective is to get the absolute difference of substracting both diagonals:
    /// diagonal 1: 1, 4, 4
    /// diagonal 2: 4, 4, -10
    /// difference = (diagonal 1 - diagonal2)
    /// difference = (1 + 4 + 4) - (4 + 4 + -10)
    /// then return the absolute value.
    /// 
    /// Tips:
    /// Be defensive. 
    /// Check for invalid input.
    /// All the tests must pass.
    /// </summary>
    public class AbsoulteDiagonalsOfAnArray
    {
        public static int DiagonalDifference(List<List<int>> arr) 
        {

            if (arr == null)
                throw new ArgumentNullException(String.Format("DiagonalDifference: Null List"));


            if (arr.Count == 0)
                throw new ArgumentException(String.Format("DiagonalDifference: Empty List"));

            int size = arr[0].FirstOrDefault();


            var matrix = arr;
            matrix.RemoveAt(0);

            if (matrix.Count == 0)
                throw new ArgumentException(String.Format("DiagonalDifference: Bad Array length data"));

            foreach (List<int> vector in matrix)
            {
                if (vector.Count != size)
                    throw new ArgumentException(String.Format("DiagonalDifference: Not a square Array"));
            }

            int diagonalSum = DiagonalSum(matrix);
            int antiDiagonalSum = AntiDiagonalSum(matrix);

            int result = diagonalSum - antiDiagonalSum;

            return result < 0 ? (result * -1) : result;

        }




        public static int DiagonalSum (List<List<int>> arr)
        {

            int sum = 0;
            int position = 0;
            foreach (List<int> vector in arr)
            {
                sum += vector[(position)];
                position ++; 
            }

            return sum;
        }

        public static int AntiDiagonalSum(List<List<int>> arr)
        {
            int sum = 0;
            int position = arr.Count() - 1;
            foreach (List<int> vector in arr)
            {
                sum += vector[position];
                position--;
            }

            return sum;
        }

    }
}
