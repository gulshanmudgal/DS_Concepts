using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    internal static class RecursionDemo
    {

        public static bool IsPlaindromeString(string strToChcekForPalindrome)
        {
            return IsPlaindromeString(0, strToChcekForPalindrome);
        }

        /// <summary>
        /// Function checks if a given string is palindrome or not.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="stringToCheck"></param>
        /// <returns></returns>
        public static bool IsPlaindromeString(int index, string stringToCheck)
        {
            int stringLength = stringToCheck.Length;

            if (stringLength / 2 >= index)
            {
                return true;
            }

            if (stringToCheck[index] == stringToCheck[stringLength - index - 1])
            {
                return IsPlaindromeString(index++, stringToCheck);
            }

            return false;
        }
    }
}
