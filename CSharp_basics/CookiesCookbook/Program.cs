public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Create a new cookie recipe! Available ingradients are:");
        string[] ingradientsList = { "Wheat flour", "Cooconut flour", "Butter", "Chocolate", "Suger", "Cardamom", "Cinnamon", "Coco powder" };

        for (int i = 1; i < ingradientsList.Count(); i++)
        {
            Console.WriteLine($"{i}. {ingradientsList[i]}");
        }
        

        var listOfIngradients = new List<int>();


        bool isGameRunning = true;

        while (isGameRunning)
        {

            Console.WriteLine("Add an ingradients by it's Id or type anything else if finished:");
            try
            {
                int userInput = Convert.ToInt32(Console.ReadLine());
                listOfIngradients.Add(userInput);
            }
            catch
            {
                isGameRunning = false;
            }
        }

        Console.WriteLine(listOfIngradients);





    }
}
