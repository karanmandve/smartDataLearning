using System;
using System.ComponentModel.DataAnnotations;
using temp;


internal class Program
{
    public static void Main(string[] args)
    {

        //var ob1 = new Reactangle(3, 5);
        //var ob2 = new Reactangle(3, 5);
        //Console.WriteLine(Reactangle.CountOfObjects);
        //Console.WriteLine(ob1.GetValue());
        //Console.WriteLine(ob2.GetValue());

        //Console.WriteLine("hello world!!!");
        

        // LINQ

        //var list = new List<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        //var list = new List<string>() { "a", "ccc", "bbb", "dddd"};
        //var list2 = list.Where(word => word.Length > 2).ToList();

        //foreach (var item in list2)
        //{
        //    Console.WriteLine(item);
        //}

        //var list = new List<int>() { 1,2,3,4, 5, 6, 9, 12};
        //Func<List<int>, List<int>> funcDelegate = l => l.Where(x => x % 3 == 0).ToList();
        //var result = funcDelegate(list);
        //foreach (var num in result)
        //{
        //    Console.WriteLine(num);
        //}

        //var smallList = list.Take(5);
        //foreach (var item in smallList)
        //{
        //    Console.WriteLine(item);
        //}

        //var lists = new List<int>() {1,2,2,2,3,4, 5, 6, 9, 12};
        //var words = new List<string>() { "aaa", "b", "c", "dd" };
        //var newList = list.Any(number  => number > 10); // returning boolean value
        //Console.WriteLine(newList
        //Console.WriteLine(list.Any());

        //var newList = list.All(number => number == 0); // returning boolean value
        //Console.WriteLine(newList);

        //var list2 = list.Count(number => number == 2);
        //Console.WriteLine(list2);

        //var newlist = list.First();
        //Console.WriteLine(newlist);

        //var newList = lists.OrderBy(x => x).Last();
        //Console.WriteLine(lists.Any());

        //if (!words.Any())
        //{
        //    throw new Exception("Words not exist");
        //}

        //var word = words.OrderBy(word => word.Length).First();

        //Console.WriteLine(word);

        //var list = lists.Where((list, index) => index > 1);

        //var allDates = dates.Where(date => date.DayOfWeek == DayOfWeek.Friday && date.Year == year).Distinct();
        //return allDates;

        //var list = lists.Select(list => list * list);
        //foreach (var item in list)
        //{
        //    Console.WriteLine(item);
        //}


        //var lists = new List<List<int>>() {
        //    new List<int> {1,2,2,2,3,4, 5, 6, 9, 12},
        //    new List<int> {4,5,6,7,8,3,2}
        //};


        //var result = lists.Select(numbers => new {
            
        //    count = numbers.Count(),
        //    avarage = numbers.Average()

        //}).OrderByDescending(numbers => numbers.avarage).Select(numbers => $"Count {numbers.count}, avarage {numbers.avarage}");

        //foreach (var item in result)
        //{
        //    Console.WriteLine(item);
        //}


        //var lists = new List<int>() {1,2,2,2,3,4, 5, 6, 9, 12};




    }
}


//    class Reactangle
//    {
//        public int Width;
//        public int Height;

//        public static int CountOfObjects;

//        public Reactangle(int width, int height)
//        {
//            Width = width;
//            Height = height;
//            CountOfObjects++;
//        }
//    //}




//public class Order
//{
//    //your code goes here

//    public Order(string item, DateTime date)
//    {

//        _item = item;
//        if (date.Year == DateTime.Now.Year)
//        {
//            _date = date;
//        }
//        else
//        {
//            _date = new DateTime(0001, 1, 1);
//        }
//        // _date = date;
//    }

//    private string _item;
//    public string Item
//    {
//        get
//        {
//            return _item;
//        }

//    }

//    private DateTime _date;
//    public DateTime Date
//    {
//        get
//        {
//            return _date;
//        }
//        set
//        {
//            if (value.Year == DateTime.Now.Year)
//            {
//                _date = value;
//            }
//        }


//    }
//}

    

