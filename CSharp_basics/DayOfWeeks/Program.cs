using System;

namespace Coding.Exercise
{
    //your code goes here
    public static class NumberToDayOfWeekTranslator{
        
        public static string Translate(int value)
    {
        switch (value)
        {
            case 1:
                return "Monday";
            case 2:
                return "Tuesday";
            case 3:
                return "Wednesday";
            case 4:
                return "Thirsday";
            case 5:
                return "Friday";
            case 6:
                return "Saturday";
            case 7:
                return "Sunday";
        }
            return "Invalud Value";
    }
} 
    
    
}
