using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{

    public class Assignment1
    {

        public static int Fact(int value)
        {
            if (value == 1) return 1;
            return Fact(value - 1) * value;
        }


        public static String PrimeNum(int value)
        {

            if (value <= 1)
            {
                return $"{value} is not a prime number";
            }

            for (int i = 2; i <= value / 2; i++)
            {
                if (value % i == 0)
                {
                    return $"{value} is not a prime number";

                }
            }

            return $"{value} is a prime number";
        }



        public static void printName(String name, String surName)
        {
            Console.WriteLine($"Your name is : {name} {surName}");
        }

        public static void printName(String name, String middleName, String surName)
        {
            Console.WriteLine($"Your full name is : {name} {middleName} {surName}");
        }

        public static void printName(String name, String surName, int age)
        {
            Console.WriteLine($"Your full name is : {name} {surName} and your age is : {age}");
        }

    }


}

