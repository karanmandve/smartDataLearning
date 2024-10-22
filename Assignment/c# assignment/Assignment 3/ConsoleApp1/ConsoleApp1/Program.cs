namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new List<int>() { 1, 5, 88, 6, 4, 2 };
            //int max = int.MinValue;
            int min = int.MaxValue;

            //foreach (int num in array)
            //{
            //    if (num > max)
            //    {
            //        max = num;
            //    }

            //    if (num < min)
            //    {
            //        min = num;
            //    }
            //}

            //Console.WriteLine($"Min is {min}, Max is {max}");


            // Second Largest

            int firstLargest = int.MinValue;
            int secondLargest = int.MaxValue;
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }


                if (array[i] > firstLargest)
                {
                    secondLargest = firstLargest;
                    firstLargest = array[i];
                }
                else if (array[i] > secondLargest) {
                    secondLargest = array[i];
                }

            }

            Console.WriteLine($"First largest is : {firstLargest}.\nSecond largest is : {secondLargest}\nMin is : {min}");
        }
    }
}
