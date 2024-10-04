namespace PracticeConsoleApp
{
    internal class Student
    {
        private int studentId;

        public int StudentId { get { return studentId; } set { studentId = value; } }
        public string StudentName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int Age
        {
            get
            {
                return (DateTime.Today.Year - DateOfBirth.Year);
            }

            //private set;
        }

        public Student(DateTime dob)
        {
            studentId = 0;
            DateOfBirth = dob;
            //Age = (DateTime.Today.Year - DateOfBirth.Year);
        }

        public void Show()
        {
            Console.WriteLine("Hi this is " + studentId);
        }
    }
}
