using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionAndInterface
{
    public abstract class Vehicle
    {   
        //no implimentation of start engine will be implimented by the inharited class
        public abstract void StartEngine();
        public abstract void StopEngine();

        // Implimentation without abstract keyword
        public void Horn() {

            Console.WriteLine("Beep! Beep!");

        }


    }

    // inheriting method from Vehicle class
    public class Car : Vehicle
    {
        public override void StartEngine()
        {
            Console.WriteLine("Car engine started.");
        }

        public override void StopEngine()
        {
            Console.WriteLine("Car engine stopped.");
        }
    }


    // inheriting method from Vehicle class
    public class Bike : Vehicle
    {
        public override void StartEngine()
        {
            Console.WriteLine("Car engine started.");
        }

        public override void StopEngine()
        {
            Console.WriteLine("Car engine stopped.");
        }
    }

}
