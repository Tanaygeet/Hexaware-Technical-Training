/* Tanaygeet Shrivastava */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//4.Implement Courier Assignment Logic 1. Develop a mechanism to assign couriers to shipments based 
//on predefined criteria (e.g., proximity, load capacity) using loops. 

namespace CourierAssignment1._4
{
    internal class Program
    {
        class Courier
        {
            public string Name { get; set; }
            public double DistanceToShipment { get; set; }  // Distance from courier to shipment km
            public double AvailableCapacity { get; set; }   // Available load capacity kg

            public Courier(string name, double distance, double capacity)
            {
                Name = name;
                DistanceToShipment = distance;
                AvailableCapacity = capacity;
            }
        }
        static void Main()
        {
            // list of couriers
            List<Courier> couriers = new List<Courier>
        {
            new Courier("Courier A", 10.0, 50.0),  // 10 km away, 50 kg capacity
            new Courier("Courier B", 5.0, 30.0),   
            new Courier("Courier C", 7.0, 40.0),   
            new Courier("Courier D", 2.0, 20.0)   
        };
          
            double shipmentWeight = 25.0;  

            Courier assignedCourier = null;  
           
            double closestDistance = double.MaxValue;

            foreach (Courier courier in couriers)
            {
                
                if (courier.AvailableCapacity >= shipmentWeight)
                {
                
                    if (courier.DistanceToShipment < closestDistance)
                    {
                        closestDistance = courier.DistanceToShipment;
                        assignedCourier = courier;
                    }
                }
            }
     
            if (assignedCourier != null)
            {
                Console.WriteLine($"Shipment is assigned to {assignedCourier.Name}.");
            }
            else
            {
                Console.WriteLine("No courier available to carry the shipment.");
            }
            Console.ReadKey();
        }
    }
}
