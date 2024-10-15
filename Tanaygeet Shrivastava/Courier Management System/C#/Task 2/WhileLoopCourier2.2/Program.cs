/* Tanaygeet Shrivastava */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//6.Implement a while loop to track the real-time location of a courier until it reaches its destination. 

namespace WhileLoopCourier2._2
{
    internal class Program
    {
        static void Main()
        {
           
            double distanceToDestination = 9.0;  // 9 km away from destination
            int speed = 3;                   // Courier speed in km/time

            Console.WriteLine("Tracking courier's location...");
 
            while (distanceToDestination > 0)
            {
                Console.WriteLine($"Courier is {distanceToDestination:F1} km away from the destination.");
 
                Thread.Sleep(2000);

                distanceToDestination -= speed;

                if (distanceToDestination < 0)
                {
                    distanceToDestination = 0;
                }
            }
            
            Console.WriteLine("Courier has arrived at the destination!");
            Console.ReadKey();  
        }
    }
}
