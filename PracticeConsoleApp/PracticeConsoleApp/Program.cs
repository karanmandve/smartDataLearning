namespace PracticeConsoleApp
{
    internal class Program
    {
        public delegate void ShowDelegate();

        static void Main(string[] args)
        {
            IEnumerable<int> list =  new int[] { 1, 2, 3};

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            //SystemDelegateExampleWithLamda();
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
    }
}
