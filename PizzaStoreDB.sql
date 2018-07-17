-- Schema namespace for our tables
CREATE SCHEMA PizzaStore;
GO

CREATE DATABASE PizzaStoreApp;

-- Table to record Customer information
CREATE TABLE PizzaStore.Customer
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    LocationId INT NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    PASSWORD NVARCHAR(16) NOT NULL
);

-- Table to record store location
CREATE TABLE PizzaStore.Location
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50),
    Phone NVARCHAR(10)
);

-- Table to record orders 
CREATE TABLE PizzaStore.Orders
(
    Id INT PRIMARY KEY IDENTITY,
    Sale DECIMAL(10,2),
    Date DATE,
    Time TIME, 
    LocationId INT NOT NULL,
    CustomerId INT NOT NULL
);

-- Table to record item for sale (Pizza, cake, soda, etc...)
CREATE TABLE PizzaStore.Item 
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50),
    Price DECIMAL(10,2),
    ItemTypeId INT NOT NULL
);


CREATE TABLE PizzaStore.ItemType
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50),
)

-- Table to manage the available item for each location
CREATE TABLE PizzaStore.Inventory
(
    Id  INT PRIMARY KEY IDENTITY,
    Quantity INT,
    LocationId INT NOT NULL,
    ItemId INT NOT NULL
);

-- Table that show details of the order made by customer
CREATE TABLE PizzaStore.OrderDetails
(
    Id  INT PRIMARY KEY IDENTITY,
    Quantity INT,
    OrderId INT NOT NULL,
    ItemId INT NOT NULL
);


-- Add Foreign Key to Customer Table
ALTER TABLE PizzaStore.Customer
ADD CONSTRAINT FK_Customer_Location FOREIGN KEY (LocationId) 
REFERENCES PizzaStore.Location(Id);


-- Add Foreign Key to Orders Table
ALTER TABLE PizzaStore.Orders
ADD CONSTRAINT FK_Orders_Location FOREIGN KEY (LocationId) 
REFERENCES PizzaStore.Location(Id);

ALTER TABLE PizzaStore.Orders
ADD CONSTRAINT FK_Orders_Customer FOREIGN KEY (CustomerId) 
REFERENCES PizzaStore.Customer(Id);


-- Add Foreign Key to Inventory Table
ALTER TABLE PizzaStore.Inventory
ADD CONSTRAINT FK_Inventory_Location FOREIGN KEY (LocationId) 
REFERENCES PizzaStore.Location(Id);

ALTER TABLE PizzaStore.Inventory
ADD CONSTRAINT FK_Inventory_Item FOREIGN KEY (ItemId) 
REFERENCES PizzaStore.Item(Id);


-- Add Foreign Key to OrderDetails Table
ALTER TABLE PizzaStore.OrderDetails
ADD CONSTRAINT FK_OrderDetails_Order FOREIGN KEY (OrderId) 
REFERENCES PizzaStore.Orders(Id);

ALTER TABLE PizzaStore.OrderDetails
ADD CONSTRAINT FK_OrderDetails_Item FOREIGN KEY (ItemId) 
REFERENCES PizzaStore.Item(Id);




-- Insert locations to PizzaStore.Location table:
INSERT INTO PizzaStore.Location 
VALUES 
(
'Reston',
'7034373703'
);

INSERT INTO PizzaStore.Location 
VALUES 
(
'Vienna',
'7033193777'
);

INSERT INTO PizzaStore.Location 
VALUES 
(
'Herndon',
'7034716768'
);


-- Insert Item types data
INSERT INTO PizzaStore.ItemType
VALUES
(
    'Dinner'
);
INSERT INTO PizzaStore.ItemType
VALUES
(
    'Drink'
);
INSERT INTO PizzaStore.ItemType
VALUES
(
    'Dessert'
);


-- Insert Product to Item table:
------------------------
-- Tradicional Pizza
--
-- Small Pepperoni Pizza
-- Medium Pepperoni Pizza
-- Large Pepperoni Pizza
------------------------
INSERT INTO PizzaStore.Item
VALUES
(
    'Small Pepperoni Pizza',
    12.00,
    1
);
INSERT INTO PizzaStore.Item
VALUES
(
    'Medium Pepperoni Pizza',
    14.00,
    1
);
INSERT INTO PizzaStore.Item
VALUES
(
    'Large Pepperoni Pizza',
    16.00,
    1
);
------------------------
-- Small Cheese Pizza
-- Medium Cheese Pizza
-- Large Cheese Pizza
------------------------
INSERT INTO PizzaStore.Item
VALUES
(
    'Small Cheese Pizza',
    10.00,
    1
);
INSERT INTO PizzaStore.Item
VALUES
(
    'Medium Cheese Pizza',
    12.00,
    1
);
INSERT INTO PizzaStore.Item
VALUES
(
    'Large Cheese Pizza',
    14.00,
    1
);

------------------------
-- Meat Pizza 
--
-- Small MeatLover Pizza
-- Medium MeatLover Pizza
-- Large MeatLover Pizza
------------------------
INSERT INTO PizzaStore.Item
VALUES
(
    'Small MeatLover Pizza',
    14.00,
    1
);
INSERT INTO PizzaStore.Item
VALUES
(
    'Medium MeatLover Pizza',
    16.00,
    1                                                                                                                                      
);
INSERT INTO PizzaStore.Item
VALUES
(
    'Large MeatLover Pizza',
    18.00,
    1
);

------------------------
-- Vegetable Pizza
--
-- Small Veggie Pizza
-- Medium Veggie Pizza
-- Large Veggie Pizza
------------------------
INSERT INTO PizzaStore.Item
VALUES
(
    'Small Veggie Pizza',
    14.00,
    1
);
INSERT INTO PizzaStore.Item
VALUES
(
    'Medium Veggie Pizza',
    16.00,
    1
);
INSERT INTO PizzaStore.Item
VALUES
(
    'Large Veggie Pizza',
    18.00,
    1
);

------------------------
-- Supreme Pizza (meat & veggie)
--
-- Small Supreme Pizza
-- Medium Supreme Pizza
-- Large Supreme Pizza
------------------------
INSERT INTO PizzaStore.Item
VALUES
(
    'Small Supreme Pizza',
    16.00,
    1
);
INSERT INTO PizzaStore.Item
VALUES
(
    'Medium Supreme Pizza',
    18.00,
    1
);
INSERT INTO PizzaStore.Item
VALUES
(
    'Large Supreme Pizza',
    20.00,
    1
);

------------------------
-- 2L Bottle Soda
--
-- 2L CocaCola 
-- 2L Sprite 
-- 2L Pepsi
------------------------
INSERT INTO PizzaStore.Item
VALUES
(
    '2L Coca Cola',
    2.50,
    2
);
INSERT INTO PizzaStore.Item
VALUES
(
    '2L Sprite',
    2.50,
    2
);
INSERT INTO PizzaStore.Item
VALUES
(
    '2L Pepsi',
    2.50,
    2
);

------------------------
-- Dessert
--
-- 9" Chocolate Cake
-- 9" Cheese Cake 
-- 10 Cinamon Balls
------------------------
INSERT INTO PizzaStore.Item
VALUES
(
    '9" Chocolate Cake',
    10.00,
    3
);
INSERT INTO PizzaStore.Item
VALUES
(
    '9" Cheese Cake',
    10.00,
    3
);
INSERT INTO PizzaStore.Item
VALUES
(
    '10 Cinamon Balls',
    10.00,
    3
);

SELECT * FROM PizzaStore.Item;

--------------------------------
--
-- Fill Inventory base on LocationId #1
--
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    1
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    2
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    3
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    4
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    5
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    6
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    7
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    8
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    9
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    10
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    11
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    12
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    13
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    14
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    15
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    16
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    17
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    18
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    19
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    20
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    1,
    21
);

--------------------------------
--
-- Fill Inventory base on LocationId #2
--
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    1
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    2
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    3
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    4
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    5
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    6
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    7
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    8
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    9
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    10
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    11
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    12
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    13
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    14
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    15
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    16
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    17
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    18
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    19
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    20
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    2,
    21
);

--------------------------------
--
-- Fill Inventory base on LocationId #3
--
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    1
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    2
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    3
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    4
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    5
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    6
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    7
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    8
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    9
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    10
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    11
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    12
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    13
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    14
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    15
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    16
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    17
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    18
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    19
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    20
);
INSERT INTO PizzaStore.Inventory
VALUES
(
    10,
    3,
    21
);
--------------------------------
-- Insert data into Customer table
-- 
INSERT INTO PizzaStore.Customer
VALUES
(
    'Jean Carlo',
    'Semprit Rodriguez',
    3,
    'jc.semprit@hotmail.com',
    '1234'
);



-- DROP TABLE PizzaStore.OrderDetails;
-- Drop TABLE PizzaStore.Orders;
-- DROP TABLE PizzaStore.Customer;
-- DROP TABLE PizzaStore.Inventory;
-- DROP TABLE PizzaStore.ItemType;
-- DROP TABLE PizzaStore.Item;
-- DROP TABLE PizzaStore.Location;

