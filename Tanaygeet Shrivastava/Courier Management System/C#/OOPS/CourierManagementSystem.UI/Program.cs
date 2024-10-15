/* Tanaygeet Shrivastava */

using CourierManagementSystem.BusinessLayer.Repository;
using CourierManagementSystem.BusinessLayer.Service;
using CourierManagementSystem.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourierManagemenySystem_DatabaseConnection;




namespace CourierManagementSystem.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepository er = new EmployeeRepository(101, "Akshat", "abc@email.com", "2323223232", "admin", 12000);
            EmployeeService es = new EmployeeService(er);


            es.DisplayEmployeeInfo();
            es.ToString();

            CourierRepository cr = new CourierRepository();

            ICourierUserService courierUserService = new CourierUserService();
            ICourierAdminService courierAdminService = new CourierAdminService();

            // Admin adds a new courier staff member
            Employee newEmployee = new Employee { employeeName = "Bruce", email = "bruce@lee.com", contactNumber = "1234567890", role = "Courier", salary = 5000 };
            int employeeId = courierAdminService.AddCourierStaff(newEmployee);
            Console.WriteLine($"Added new courier staff with ID: {employeeId}");

            //int courierID, string senderName, string senderAddress, string receiverName, string receiverAddress, double weight, string status, string trackingNumber, DateTime deliveryDate, int userId
            // User places a new order
            Courier courier = new Courier
            {
                courierID = 101,

                senderName = "Akshat",
                senderAddress = "123 Main St",
                receiverName = "Bob",
                receiverAddress = "456 Park Ave",
                weight = 10.5,
                status = "delivered",
                TrackingNumber = "abc101",
                deliveryDate = DateTime.Now.AddDays(2),
                employeeID = employeeId
            };
            //courier.CourierID = employeeId;
            string trackingNumber = courierUserService.PlaceOrder(courier);
            Console.WriteLine($"Order placed. Tracking number: {trackingNumber}");

            // Check order status
            string status = courierUserService.GetOrderStatus(trackingNumber);
            Console.WriteLine($"Order status: {status}");

            // Cancel the order
            bool cancelResult = courierUserService.CancelOrder(trackingNumber);
            Console.WriteLine($"Order canceled: {cancelResult}");

            // Task 9 Database connection 
            CourierServiceDB courierServiceDb = new CourierServiceDB();

            // 1. Retrieve all employees
            courierServiceDb.GetEmployeeDetails();

            // 2. Insert a new employee
            //Employee newE = new Employee
            //{
            //    employeeName = "Happy Singh",
            //    email = "Aditya@example.com",
            //    contactNumber = "1234567890",
            //    role = "Manager",
            //    salary = 75000.00D
            //};
            //courierServiceDb.InsertEmployee(newE);

            // 3. Update an employee's details
            //Employee updateEmployee = new Employee
            //{
            //    employeeID = 1, // Assuming EmployeeID 1 exists
            //    email = "new.email@example.com",
            //    contactNumber = "0987654321",
            //    role = "Senior Manager",
            //    salary = 80000.00D
            //};
            //courierServiceDb.UpdateEmployee(updateEmployee);

            // 4. Delete an employee
            //courierServiceDb.DeleteEmployee(2);  // EmployeeID  is  2 

            // 5. Get the employee with the highest salary
            //courierServiceDb.GetEmployeeWithMaxSalary();
            Console.ReadKey();
        }
    }
}
