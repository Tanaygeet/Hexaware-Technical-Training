/* Tanaygeet Shrivastava */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Task 1: Control Flow Statements  
//1. Write a program that checks whether a given order is delivered or not based on its status (e.g.,
//"Processing," "Delivered," "Cancelled"). Use if-else statements for this. 
namespace OrderDeliveryStatus1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sample order status input
            string orderStatus = "Delivered";  

            if (orderStatus == "Delivered")
            {
                Console.WriteLine("The order has been delivered.");
            }
            else if (orderStatus == "Processing")
            {
                Console.WriteLine("The order is still processing.");
            }
            else if (orderStatus == "Cancelled")
            {
                Console.WriteLine("The order has been cancelled.");
            }
            else
            {
                Console.WriteLine("Unknown order status.");
            }
            Console.ReadKey();
        }
    }
}
