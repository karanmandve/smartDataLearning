using ClassesAndObjects;

internal class Program
{
    private static void Main(string[] args)
    {
        var student1 = new Student(1, "Tejas", "Mate");
        student1.DisplayFullName();


        var teacher1 = new Teacher(1, "Rajesh", "Holkar");
        teacher1.DisplayFullName();
            
    }


}