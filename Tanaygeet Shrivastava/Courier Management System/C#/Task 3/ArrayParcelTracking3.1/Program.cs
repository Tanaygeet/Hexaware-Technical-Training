/* Tanaygeet Shrivastava */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Task 3: Arrays and Data Structures  
//7. Create an array to store the tracking history of a parcel, where each entry represents a location 
//update.  

namespace ArrayParcelTracking3._1
{
    internal class Program
    {
        static void Main()
        {
            //5 location updates
            string[] trackingHistory = new string[4];  

            //Location updates 
            trackingHistory[0] = "City A - Dispatched";
            trackingHistory[1] = "City B - Arrived at Hub";
            trackingHistory[2] = "City C - Out for Delivery";
            trackingHistory[3] = "Delivered";

            //Tracking history
            Console.WriteLine("Tracking History of the Parcel:");
            for (int i = 0; i < trackingHistory.Length; i++)
            {
                Console.WriteLine($"Update {i + 1}: {trackingHistory[i]}");
            }

            Console.ReadKey();
        }
    }
}
