/* Tanaygeet Shrivastava */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Task 4 question 9

namespace ParcelTracking4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[,] parcels = new string[4, 2]
            {
            { "1", "In Transit" },
            { "2", "Out for Delivery" },
            { "3", "Delivered" },
            { "4", "In Transit" }
            };

            Console.Write("Enter parcel tracking number: ");
            string trackingNumber = Console.ReadLine();

            // if the tracking number is found
            bool parcelFound = false;
          
            for (int i = 0; i < parcels.GetLength(0); i++)
            {
                if (parcels[i, 0] == trackingNumber)
                {
                
                    string status = parcels[i, 1];
                    Console.WriteLine($"Tracking number: {trackingNumber}");
                    Console.WriteLine($"Current status: {status}");

                    
                    if (status == "In Transit")
                    {
                        Console.WriteLine("Parcel in transit.");
                    }
                    else if (status == "Out for Delivery")
                    {
                        Console.WriteLine("Parcel is out for delivery.");
                    }
                    else if (status == "Delivered")
                    {
                        Console.WriteLine("Parcel has been delivered.");
                    }

                    parcelFound = true;
                    break;
                }
            }

            if (!parcelFound)
            {
                Console.WriteLine("Tracking number not found.");
            }

         Console.ReadKey(); 
        }
    }
}
