using System.Security.Cryptography.X509Certificates;
using Delegates;
using static Delegates.Rectangle;
public class Program
{
    
    private static void Main(string[] args)
    {

        // singlecast Delegate

        //var obj = new Rectangle();
        //MyDelegate newDelegate = obj.Area;
        //newDelegate(3, 5);
        //newDelegate = obj.Parameter;
        //newDelegate(3, 7);



        // multicast Delegate

        //var obj = new Rectangle();
        //MyDelegate newDelegate = obj.Area;
        //newDelegate += obj.Parameter;

        //newDelegate(3, 5);



    }
    public void hello(string name) {  Console.WriteLine(name); }
}