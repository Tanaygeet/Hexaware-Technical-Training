/* Tanaygeet Shrivastava */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2.Implement a switch-case statement to categorize parcels based on their weight into "Light," 
//"Medium," or "Heavy."  

namespace SwitchCase1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            double parcelWeight = 15.5;  

            switch (parcelWeight)
            {
                case double weight when (weight < 5):
                    Console.WriteLine("The parcel is Light.");
                    break;

                case double weight when (weight >= 5 && weight < 20):
                    Console.WriteLine("The parcel is Medium.");
                    break;

                case double weight when (weight >= 20):
                    Console.WriteLine("The parcel is Heavy.");
                    break;

                default:
                    Console.WriteLine("Invalid weight.");
                    break;
            }
            Console.ReadKey();  
        }
    }
}
