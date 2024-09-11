using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollGame
{
    public class NumberGenerator
    {
        public int RandomNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 7);
            return randomNumber;
        }

        public int UserNumber()
        {
            try
            {
                int userNumber = Convert.ToInt32(Console.ReadLine());
                return userNumber;
            }
            catch
            {
                Console.WriteLine("Enter the valid number only: ");
                return 0;
            }


        }
    }
}
