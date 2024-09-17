using System;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace Coding.Exercise

{
    public class temp
    {

        public static void Main(string[] args)
        {
            //var date = new DateTime(2024, 9, 8);
            //Order ob1 = new Order("some", date);
            //var newDate = new DateTime(2023, 9, 9);
            //ob1.Date = newDate;
            //Console.WriteLine(ob1.Date);
            //Console.WriteLine(ob1.Item);


            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();

            keyValuePairs.Add(1, "karan");


            foreach (var key in keyValuePairs) {
                Console.WriteLine($"Key is : {key.Key} value is : {key.Value}");
            }


        }
    }


    //public class Order
    //{
    //    //your code goes here
    //    public readonly string Item;
    //    private DateTime _date;

    //    public Order(string item, DateTime date)
    //    {
    //        Item = item;
    //        _date = date;
    //    }

    //    public DateTime Date { get; set; }

        //public DateTime Date
        //{
        //    get
        //    {
        //        return _date;
        //    }
        //    set
        //    {
        //        if (DateTime.Now.Year == value.Year)
        //        {
        //            _date = value;
        //        }
        //    }
        //}


    }

