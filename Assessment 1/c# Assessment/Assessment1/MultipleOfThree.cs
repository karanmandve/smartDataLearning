using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    public class MultipleOfThree
    {

        /// <summary>
        /// Calculating multiple of three
        /// </summary>
        /// <param name="numbers">Take a list of interger</param>
        /// <returns>Return the list of string</returns>
        public static List<string> MultipleOfThrees(List<int> numbers)
        {
            var resultList = new List<string>();
            numbers.Sort();
            foreach (var num in numbers)
            {
                if (num % 3 == 0)
                {
                    resultList.Add($"The number {num}");
                }
            }
            return resultList;
        }

    }
}
