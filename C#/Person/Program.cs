internal class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");


        // ibject initialiser first contructor set then object initialiser set work only when public
        // usign init; instead of set we give using object initialiser but after than we can't set it;

        //var ob1 = new Person
        //{
        //    Name = "karan",
        //    YearOfBirth = 2002
        //};
        //Console.WriteLine(ob1.YearOfBirth);

        //var ob2 = new Person();
        //Person.Name = "karan";
        //Console.WriteLine(Person.Name); 

        // using static keyword
        //Person.Name = "karan";
        //Console.WriteLine(Person.Name);


    }

    class Person
    {
        public static string Name { get; set; }
        public int YearOfBirth { get; set; }

    }
}