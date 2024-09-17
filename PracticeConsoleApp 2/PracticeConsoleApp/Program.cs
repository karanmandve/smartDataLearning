using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeConsoleApp
{
    internal class Program
    {
        public delegate void ShowDelegate();

        static void Main(string[] args)
        {
            var students = GetStudents();

            students.ForEach(Console.WriteLine);
            FilterationAndProjectionExample();

            //var test = students.OrderByDescending(x => x.StudentId);
            //foreach (var item in test)
            //    Console.WriteLine(item.StudentName);
        }

        private static void RawDemoExample()
        {
            var list = GetItems(1, 10);

            foreach (var item in list)
            {
                if (item == 5)
                    break;

                Console.WriteLine("Called " + item);
            }

            var list2 = GetItems(1, 10)
                .ToList();

            foreach (var item in list2)
            {
                if (item == 5)
                    break;

                Console.WriteLine("Called " + item);
            }
        }

        private static IEnumerable<int> GetItems(int start, int end)
        {
            for (int x = start; x <= end; x++)
            {
                Console.WriteLine("In Side Function - " + x);
                yield return x;
            }
        }

        private static void JoiningExample()
        {
            var list = new[]
            {
                new { id = 1, marks = 100 },
                new { id = 2, marks = 200 },
                new { id = 3, marks = 200 },
                new { id = 4, marks = 150 },
                new { id = 5, marks = 20 },
                new { id = 6, marks = 20 },
                new { id = 7, marks = 20 },
                new { id = 8, marks = 20 },
                new { id = 9, marks = 20 },
                new { id = 10, marks = 20 },
            };

            var students = GetStudents();
            var listing = students.Join
            (
                list,
                x => x.StudentId,
                y => y.id,
                (a, b) => new { a.StudentId, a.StudentName, b.marks }
            ).ToList();

            foreach (var item in listing)
                Console.WriteLine(item);

            var listing2 = (from x in students
                            join y in list on x.StudentId equals y.id
                            select new { x.StudentId, x.StudentName, y.marks })
                           .ToList();

            foreach (var item in listing2)
                Console.WriteLine(item);
        }


        private static void FilterationAndProjectionExample()
        {
            var students = GetStudents();

            foreach (var item in students)
                Console.WriteLine(item.StudentName);

            var studentWithEvenIds = students
                .Where(x => x.StudentId % 2 == 0)
                .ToList();

            foreach (var item in studentWithEvenIds)
                Console.WriteLine("Even " + item.StudentName);

            var studentIds = students
               .Where(x => x.StudentId % 2 == 0)
               .Select(x => x.StudentId)
               .ToList();

            foreach (var item in studentIds)
                Console.WriteLine("Id " + item);

            var studentIdWithNames = students
              .Where(x => x.StudentId % 2 == 0)
              .Select(x => new
              {
                  StudentId = x.StudentId,
                  x.StudentName,
                  Dob = x.DateOfBirth
              })
              .ToList();

            foreach (var item in studentIdWithNames)
                Console.WriteLine("obj " + item);
        }

        private static void CollectionExample()
        {
            var hashSet = new HashSet<int>();

            hashSet.Add(1);
            hashSet.Add(1);
            hashSet.Add(2);

            var dictionary = new Dictionary<int, int>();

            try
            {
                dictionary.Add(1, 1);
                dictionary.Add(2, 4);
                dictionary.Add(3, 9);
                //dictionary.Add(3, 9);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Always called");
            }


            foreach (var item in hashSet)
            {
                Console.WriteLine(item);
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }

        private static void ListExample()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var list2 = GetEvenNumbers(list);
            var list3 = GetOddNumbers(list);

            Console.WriteLine("Even");

            foreach (int item in list2)
                Console.WriteLine(item);

            Console.WriteLine("Odd");

            foreach (int item in list3)
                Console.WriteLine(item);

            Console.WriteLine("Multiple of 3 using function");

            foreach (int item in GetNumbersUsingDelegate(list, CheckMultipleOf3))
                Console.WriteLine(item);

            Console.WriteLine("Even using predicate");

            Predicate<int> predicate = x => (x % 2 == 0);

            foreach (int item in GetNumbersUsingDelegate(list, predicate))
                Console.WriteLine(item);


            Console.WriteLine("Odd using predicate");

            foreach (int item in GetNumbersUsingDelegate(list, x => (x % 2 != 0)))
                Console.WriteLine(item);
        }

        private static bool CheckMultipleOf3(int data)
        {
            return data % 3 == 0;
        }

        public static List<int> GetNumbersUsingDelegate(List<int> list, Predicate<int> predicate)
        {
            var list2 = new List<int>();

            foreach (var item in list)
            {
                if (predicate(item))
                    list2.Add(item);
            }

            return list2;
        }

        public static List<int> GetEvenNumbers(List<int> list)
        {
            var list2 = new List<int>();

            foreach (var item in list)
            {
                if (item % 2 == 0)
                    list2.Add(item);
            }

            return list2;
        }

        public static List<int> GetOddNumbers(List<int> list)
        {
            var list2 = new List<int>();

            foreach (var item in list)
            {
                if (item % 2 != 0)
                    list2.Add(item);
            }

            return list2;
        }

        public static void ExtensionExample()
        {
            var student = GetStudent();

            Console.WriteLine("Calculated Age " + StudentExtensions.CalculateAge(student));
            Console.WriteLine("Calculated Age Via Extension " + student.CalculateAge());
            Console.WriteLine("Calculated Age Via Extension " + student.CalculateAge(DateTime.Now));
        }

        // Delegates example
        public static void SystemDelegateExampleWithLamda()
        {
            Action<int, int> action = (abc, xyz) => Console.WriteLine("Action called." + (abc + xyz));
            Predicate<int> predicate = (data) => data > 10;
            Func<int, int> func = (data) => data * data;
            Func<bool> func1 = () => DateTime.UtcNow.Hour > 10;

            action(10, 30);
            Console.WriteLine("predicate value " + predicate(10));
            Console.WriteLine("func value " + func(30));
            Console.WriteLine("func1 value " + func1());
        }

        public static void SystemDelegateExample()
        {
            Action action = delegate ()
            {
                Console.WriteLine("Action called.");
            };

            Predicate<int> predicate = delegate (int data)
            {
                Console.WriteLine("Predicate called.");
                return true;
            };

            Func<int, int> func = delegate (int data)
            {
                Console.WriteLine("Func called.");
                return data * data;
            };

            action();
            Console.WriteLine("value" + predicate(10));
            Console.WriteLine("func value" + func(30));
        }


        // Type Inference
        public static void InferenceExample()
        {
            ExampleDataGeneric(10);
            ExampleDataGeneric(20L);
            ExampleDataGeneric(30.00);
            ExampleDataGeneric<double>(100);
        }

        public static void RawExample()
        {
            ExampleData(10);
            ExampleData(20L);
            ExampleData(30.00);
        }

        public static void ExampleDataGeneric<T>(T data)
        {
            Console.WriteLine("Hi this is " + data);
        }

        public static void ExampleData(int data)
        {
            Console.WriteLine("Hi this is " + data);
        }

        public static void ExampleData(long data)
        {
            Console.WriteLine("Hi this is " + data);
        }

        public static void ExampleData(double data)
        {
            Console.WriteLine("Hi this is " + data);
        }

        public static void DelegateExample()
        {
            Student student = new Student(DateTime.Now);
            student.StudentId = 1;
            student.StudentName = "Test Name";
            student.DateOfBirth = new DateTime(1986, 1, 1);

            // First object
            ShowDelegate myShow = student.Show;

            var student2 = new Student(DateTime.Now)
            {
                StudentId = 10,
                StudentName = "Test",
                DateOfBirth = new DateTime(2021, 1, 1),
            };

            // Second object
            myShow += student2.Show;

            myShow();
        }

        private static void DataTypes()
        {
            var myInt = 0;
            var myInt1 = 0U;
            var myInt2 = 0L;
            var myInt3 = 0M;
            var myInt4 = 0.0;
        }

        private static void TestWork()
        {
            // Simple example
            Student student = new Student(DateTime.Now);
            student.StudentId = 1;
            student.StudentName = "Test Name";
            student.DateOfBirth = new DateTime(1986, 1, 1);
            //student.Age = 30;

            student.Show();

            // test
            new Student(DateTime.Today).Show();

            // Declaration and Definition
            var student2 = new Student(DateTime.Now)
            {
                StudentId = 10,
                StudentName = "Test",
                DateOfBirth = new DateTime(2021, 1, 1),
            };

            student2.Show();

            // Anonymous class
            var test = new
            {
                Id = 12,
                Name = "Demo Object"
            };

            //test.Id = 13;

            Console.WriteLine(test);


            Console.WriteLine("Hello, World!");
            Console.WriteLine("Id - " + student.StudentId);
            Console.WriteLine("StudentName - " + student.StudentName);
            Console.WriteLine("Date - " + student.DateOfBirth);
            Console.WriteLine("Age - " + student.Age);
        }

        private static List<Student> GetStudents()
        {
            var list = new List<Student>();

            for (int i = 1; i <= 20; i++)
            {
                list.Add(GetStudentById(i));
            }

            return list;
        }

        private static Student GetStudentById(int id)
        {
            return new Student(DateTime.Now)
            {
                StudentId = id,
                StudentName = $"Test - {id}",
                DateOfBirth = new DateTime(1990, 1, 1),
            };
        }

        private static Student GetStudent()
        {
            return new Student(DateTime.Now)
            {
                StudentId = 10,
                StudentName = "Test",
                DateOfBirth = new DateTime(1990, 1, 1),
            };
        }
    }
}
