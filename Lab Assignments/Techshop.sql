/* By Tanaygeet Shrivastava */


/* Task -1 */

-- 1
CREATE DATABASE TechShop;
USE TechShop;


-- 2(i)
CREATE TABLE Customers (
    CustomerID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    Phone VARCHAR(15),
    Address VARCHAR(255));


-- 2(ii)
CREATE TABLE Products (
    ProductID INT AUTO_INCREMENT PRIMARY KEY,
    ProductName VARCHAR(100),
    Description TEXT,
    Price DECIMAL(10, 2));


-- 2(iii)
CREATE TABLE Orders (
    OrderID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID));


-- 2(iv)
CREATE TABLE OrderDetails (
    OrderDetailID INT AUTO_INCREMENT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID));


-- 2(v)
CREATE TABLE Inventory (
    InventoryID INT AUTO_INCREMENT PRIMARY KEY,
    ProductID INT,
    QuantityInStock INT,
    LastStockUpdate DATE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID));


-- 5(i)
INSERT INTO Customers (FirstName, LastName, Email, Phone, Address) VALUES
('Tanaygeet', 'Shrivastava', 'Tanaygeet@example.com', '1234567890', 'Indore'),
('Aditya', 'Khamare', 'Aditya@example.com', '2345678901', 'Pune'),
('Pallavi', 'Sinha', 'Pallavi@example.com', '3456789012', 'Bangalore'),
('Ronak', 'Patel', 'Ronak@example.com', '4567890123', 'Chennai'),
('Latashree', 'Shrivastava', 'Latashree@example.com', '5678901234', 'Ahemdabad'),
('Ravindra', 'Bage', 'Ravindra@example.com', '6789012345', 'Kolkata'),
('Kritika', 'Nigam', 'Kritika@example.com', '7890123456', 'Irvine'),
('Dev', 'Suri', 'Dev@example.com', '8901234567', 'Delhi'),
('Soniya', 'Tiwari', 'Soniya@example.com', '9012345678', 'Mumbai'),
('Shruti', 'Parmar', 'Shruti@example.com', '0123456789', 'Pondicherry');


-- 5(ii)
INSERT INTO Products (ProductName, Description, Price) VALUES
('Smartphone', 'Latest smartphone with high resolution camera', 25699.99),
('Laptop', '15-inch laptop with 16GB RAM and 512GB SSD', 78999.99),
('Tablet', '10-inch tablet with 64GB storage', 24299.99),
('Smartwatch', 'Smartwatch with heart rate monitor', 1199.99),
('Bluetooth Speaker', 'Portable Bluetooth speaker with 10 hours battery life', 4449.99),
('Wireless Earbuds', 'Noise-cancelling wireless earbuds', 6129.99),
('Gaming Console', 'Next-gen gaming console with 1TB storage', 61499.99),
('4K TV', '50-inch 4K Ultra HD Smart TV', 43799.99),
('Digital Camera', '24MP digital camera with 4K video recording', 30599.99),
('Drone', 'Quadcopter drone with 1080p HD camera', 7399.99);


-- 5(iii)
INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES
(1, '2024-09-01', 34749.99),
(2, '2024-09-02', 81299.99),
(3, '2024-09-03', 56449.99),
(4, '2024-09-04', 27249.99),
(5, '2024-09-05', 97699.99),
(6, '2024-09-06', 67599.99),
(7, '2024-09-07', 21399.99),
(8, '2024-09-08', 89399.99),
(9, '2024-09-09', 23999.99),
(10, '2024-09-10', 12299.99);


-- 5(iv)
INSERT INTO OrderDetails (OrderID, ProductID, Quantity) VALUES
(1, 1, 2),
(2, 2, 3),
(3, 3, 4),
(4, 4, 3),
(5, 5, 2),
(6, 6, 4),
(7, 7, 2),
(8, 8, 3),
(9, 9, 2),
(10, 10, 2);


-- 5(v)
INSERT INTO Inventory (ProductID, QuantityInStock, LastStockUpdate) VALUES
(1, 100, '2024-08-01'),
(2, 50, '2024-08-02'),
(3, 200, '2024-08-03'),
(4, 150, '2024-08-04'),
(5, 300, '2024-08-05'),
(6, 75, '2024-08-06'),
(7, 60, '2024-08-07'),
(8, 40, '2024-08-08'),
(9, 120, '2024-08-09'),
(10, 80, '2024-08-10');



------------------------------------------------------------------------------------
/* Task - 2 */

-- 1
SELECT FirstName, LastName, Email 
FROM Customers;


-- 2
SELECT Orders.OrderID, Orders.OrderDate, Customers.FirstName, Customers.LastName 
FROM Orders 
JOIN Customers ON Orders.CustomerID = Customers.CustomerID;


-- 3
INSERT INTO Customers (FirstName, LastName, Email, Phone, Address) 
VALUES ('Dhairya', 'Jain', 'Dhairya@example.com', '9876543210', 'Bhopal');

-- 4 
UPDATE Products 
SET Price = Price * 1.10;


-- 5
SET @OrderID = 1;  -- order ID

DELETE FROM OrderDetails WHERE OrderID = @OrderID;
DELETE FROM Orders WHERE OrderID = @OrderID;


-- 6
INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) 
VALUES (1, '2024-09-15', 86500.00);


-- 7
SET @CustomerID = 8;  -- customer ID
SET @NewEmail = 'DevSuri@example.com';
SET @NewAddress = 'Noida';

UPDATE Customers 
SET Email = @NewEmail, Address = @NewAddress 
WHERE CustomerID = @CustomerID;


-- 8
UPDATE Orders O
JOIN (
    SELECT OrderID, SUM(OD.Quantity * P.Price) AS TotalAmount
    FROM OrderDetails OD
    JOIN Products P ON OD.ProductID = P.ProductID
    GROUP BY OrderID
) AS Subquery ON O.OrderID = Subquery.OrderID
SET O.TotalAmount = Subquery.TotalAmount;



-- 9
SET @CustomerID = 2;  -- customer ID

DELETE FROM OrderDetails 
WHERE OrderID IN (SELECT OrderID FROM Orders WHERE CustomerID = @CustomerID);

DELETE FROM Orders 
WHERE CustomerID = @CustomerID;


-- 10
INSERT INTO Products (ProductName, Description, Price) 
VALUES ('Smart Glasses', 'Wearable smart glasses with AR features', 17299.99);


-- 11
/* adding new column as status in orders table */
ALTER TABLE Orders 
ADD COLUMN Status VARCHAR(20) DEFAULT 'Pending';

SET @OrderID = 7;  -- order ID
SET @NewStatus = 'Shipped';

UPDATE Orders 
SET Status = @NewStatus 
WHERE OrderID = @OrderID;


-- 12
/* adding new column as status in orders table */
ALTER TABLE Customers ADD COLUMN NumberOfOrders INT DEFAULT 0;

UPDATE Customers C
SET C.NumberOfOrders = (
    SELECT COUNT(*) 
    FROM Orders O 
    WHERE O.CustomerID = C.CustomerID);


































