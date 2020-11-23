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
            throw new NotImplementedException();
        }


    }
}
