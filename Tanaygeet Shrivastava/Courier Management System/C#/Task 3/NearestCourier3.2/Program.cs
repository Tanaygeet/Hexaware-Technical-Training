/* Tanaygeet Shrivastava */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//8.Implement a method to find the nearest available courier for a new order using an array of couriers. 

namespace NearestCourier3._2
{
    internal class Program
    {
        class Courier
        {
            public string Name { get; set; }
            public double DistanceToOrder { get; set; }  // Distance from the courier to the new order location

            public Courier(string name, double distance)
            {
                Name = name;
                DistanceToOrder = distance;
            }
        }

        static void Main(string[] args)
        {
            Courier[] couriers = new Courier[4];
            couriers[0] = new Courier("Courier A", 8.5);
            couriers[1] = new Courier("Courier B", 12.0);
            couriers[2] = new Courier("Courier C", 5.0);
            couriers[3] = new Courier("Courier D", 10.0);

            Courier nearestCourier = FindNearestCourier(couriers);

            //nearest courier
            if (nearestCourier != null)
            {
                Console.WriteLine($"The nearest available courier is {nearestCourier.Name}.");
            }
            else
            {
                Console.WriteLine("No courier available.");
            }
            Console.ReadKey();
        }
        static Courier FindNearestCourier(Courier[] couriers)
        {
            if (couriers.Length == 0) return null;

            Courier nearest = couriers[0];  
            for (int i = 1; i < couriers.Length; i++)
            {
                if (couriers[i].DistanceToOrder < nearest.DistanceToOrder)
                {
                    nearest = couriers[i]; 
                }
            }
            return nearest;
            
        }

    }
}
