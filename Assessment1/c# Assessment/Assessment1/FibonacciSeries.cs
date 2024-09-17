using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1
{
    public class FibonacciSeries
    {

        /// <summary>
        /// For Calculating Fibonacci Sequence.
        /// </summary>
        /// <param name="userInput">Give Interger value, how many Fibonacci number you want.</param>
        /// <returns>return the List of Fibonacci number</returns>
        public static List<int> Fibonacci(int userInput)
        {
            var resultList = new List<int>();

            if (userInput <= 0)
            {
                return resultList;
            }

            resultList.Add(0);
            if (userInput == 1)
            {
                return resultList;
            }

            resultList.Add(1);

            int counter = userInput - 2;
            int previousValue = 0;
            int currentValue = 1;
            int result = 0;

            for (int i = 0; i < counter; i++)
            {
                result = previousValue + currentValue;
                previousValue = currentValue;
                currentValue = result;
                resultList.Add(result);
            }

            return resultList;
        }

    }
}
