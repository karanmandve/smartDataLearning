using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    public class SqureOfNumber
    {

        /// <summary>
        /// Doing Squres of Number
        /// </summary>
        /// <param name="numbers">Give the list of number</param>
        /// <returns>Return list of sqaure of Numbers</returns>
        public static List<int> SqaureOfNumbers(List<int> numbers)
        {
            var resultList = new List<int>();
            int result = 0;
            foreach (var num in numbers)
            {
                result = num * num;
                resultList.Add(result);
            }

            return resultList;

        }

    }
}
