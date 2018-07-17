using System;
using Webapp.DataAccess.Models;
using Webapp.Library.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace App.UnitTest
{
    public class UnitTest
    {
        private readonly WebappRepository repo;

        public UnitTest()
        {
            string jsonURL = "appsettings.json";
            // get the configuration file
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(jsonURL, optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            // Test if we are getting the connection string
            Console.WriteLine("Connection String:\n");
            Console.WriteLine(configuration.GetConnectionString("PizzaStoreAppDB"));

            // Passing connection string to DBContext
            var OptionsBuilder = new DbContextOptionsBuilder<PizzaStoreAppContext>();
            OptionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaStoreAppDB"));

            var options = OptionsBuilder.Options;
            var context = new PizzaStoreAppContext(options);
            repo = new WebappRepository(context);
        }


        /* Customer
         * TODO
         * 1. Create a new customer
         * 2. Get All customer
         * 3. Get  Customer by Name
         * 4. Get  Customer by ID
         * 5. Edit Customer by ID
         * 6. Delete Customer by ID
        */
        [Fact]
        public void GetAllCustomerShouldReturnAListOfRegisteredCustomer()
        {
            // Note:
            // At this moment the DB count with 5 initial Customer for demo

            // Arrange
            List<Customer> Customers;

            // Action
            Customers = (List<Customer>)repo.GetAllCustomer();

            // Assert
            Assert.NotNull(Customers);
        }


        [Fact]
        public void GetCustomerByIDShouldReturnTheCorrectCustomer()
        {
            // Arrange
            Customer customer;
            string expected = "Jean Carlo";

            // Action
            customer = repo.GetCustomerByID(97);
            var actual = customer.FirstName;

            // Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void GetCustomerByNameShouldReturnTheCorrectCustomer()
        {
            // Arrange
            Customer customer;
            string expected = "Jean Carlo";

            // Action
            customer = repo.GetCustomerByName(expected);
            var actual = customer.FirstName;

            // Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void AddCustomerShouldAddCustomerToDB()
        {
            // Arrange
            var cFirstName = "Luis";
            var cLastName = "Sanchez";
            var cEmail = "l@gmail.com";
            var cPass = "1234";
            var cLocationID = 1;

            var customer = new Customer
            {
                FirstName = cFirstName,
                LastName = cLastName,
                LocationId = cLocationID,
                Email = cEmail,
                Password = cPass
            };

            // Action
            repo.AddCustomer(customer);

            // Push Change to DB
            repo.SaveChange();

            var actualCustomer = repo.GetCustomerByName(cFirstName);

            // Assert

            Assert.Equal(customer, actualCustomer);
        }

        [Fact]
        public void AddCustomerShouldAddCustomerToDB2()
        {
            // Arrange
            var cFirstName = "Raquel";
            var cLastName = "Sanchez";
            var cEmail = "raq@gmail.com";
            var cPass = "1234";
            var cLocationID = 1;

            // Action
            repo.AddCustomer(cFirstName, cLastName, cLocationID, cEmail, cPass);

            // Push Change to DB
            repo.SaveChange();

            var actualCustomer = repo.GetCustomerByName(cFirstName);

            // Assert

            Assert.Equal(cFirstName, actualCustomer.FirstName);

            // Delete the created user from DB
            repo.DeleteCustomer(actualCustomer.Id);
            repo.SaveChange();
        }


        /// <summary>
        /// Deletes the customer by identifier.
        /// </summary>
        [Fact]
        public void DeleteCustomerById()
        {
            // Arrange
            var customers = (List<Customer>)repo.GetAllCustomer();

            var expectedLength = customers.Count - 1;
            var customer = customers.LastOrDefault();

            // Action
            repo.DeleteCustomer(customer.Id);
            repo.SaveChange();

            customers = (List<Customer>)repo.GetAllCustomer();

            var actualLength = customers.Count;

            // Assert
            Assert.Equal(expectedLength, actualLength);
        }



        /* Item
         * TODO
         * 1. Create a new Item
         * 2. Get All Item
         * 3. Get Item by Name
         * 4. Get Item by ID
         * 5. Edit Item by ID
         * 6. Delete Item by ID
        */
        [Fact]
        public void GetAllItemShouldReturnAListOfRegisteredItem()
        {
            // Note:
            // At this moment the DB count with 5 initial Customer for demo

            // Arrange
            List<Item> Items;

            // Action
            Items = (List<Item>)repo.GetAllItem();

            // Assert
            Assert.NotNull(Items);
        }


        [Fact]
        public void GetItemByIDShouldReturnTheCorrectItem()
        {
            // Arrange
            Item item;
            string expected = "Small Pepperoni Pizza";

            // Action
            item = repo.GetItemByID(1);
            var actual = item.Name;

            // Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void GetItemByNameShouldReturnTheCorrectItem()
        {
            // Arrange
            Item item;
            string expected = "Small Pepperoni Pizza";

            // Action
            item = repo.GetItemByName(expected);
            var actual = item.Name;
            // Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void AddItemShouldAddItemToDB()
        {
            // Arrange
            var name = "Flan";
            decimal price = 12.00M;
            var itemType = 3;

            var item = new Item
            {
                Name = name,
                Price = price,
                ItemTypeId = itemType
            };

            // Action
            repo.AddItem(item);

            // Push Change to DB
            repo.SaveChange();

            var actualItem = repo.GetItemByName(name);

            // Assert

            Assert.Equal(item, actualItem);
        }


        [Fact]
        public void AddItemShouldAddItemToDB2()
        {
            // Arrange
            var name = "Brownie";
            decimal price = 12.00M;
            var itemType = 3;

            // Action
            repo.AddItem(name, price, itemType);

            // Push Change to DB
            repo.SaveChange();

            var actualItem = repo.GetItemByName(name);

            // Assert

            Assert.Equal(name, actualItem.Name);

            // Delete the created user from DB
            repo.DeleteItem(actualItem.Id);
            repo.SaveChange();
        }


        // TODO 
        // Test in case of an already assigned foreing key

        /// <summary>
        /// Deletes the customer by identifier.
        /// </summary>
        [Fact]
        public void DeleteItemById()
        {
            // Arrange
            var items = (List<Item>)repo.GetAllItem();

            var expectedLength = items.Count - 1;
            var item = items.LastOrDefault();

            // Action
            repo.DeleteItem(item.Id);
            repo.SaveChange();

            items = (List<Item>)repo.GetAllItem();

            var actualLength = items.Count;

            // Assert
            Assert.Equal(expectedLength, actualLength);
        }

        /* 
         * Location
         * TODO
         * 1. Create a new Location
         * 2. Get All Location
         * 3. Get Location by Name
         * 4. Get Location by ID
         * 5. Edit Location by ID
         * 6. Delete Location by ID
        */
        [Fact]
        public void GetAllLocationShouldReturnAListOfRegisteredLocation()
        {
            // Note:
            // At this moment the DB count with 5 initial Customer for demo

            // Arrange
            List<Location> locations;

            // Action
            locations = (List<Location>)repo.GetAllLocation();

            // Assert
            Assert.NotNull(locations);
        }


        [Fact]
        public void GetLocationByIDShouldReturnTheCorrectLocation()
        {
            // Arrange
            Location location;
            string expected = "Reston";

            // Action
            location = repo.GetLocationByID(1);
            var actual = location.Name;

            // Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void GetLocationByNameShouldReturnTheCorrectLocation()
        {
            // Arrange
            Location location;
            string expected = "Reston";

            // Action
            location = repo.GetLocationByName(expected);
            var actual = location.Name;
            // Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void AddLocationShouldAddLocationToDB()
        {
            // Arrange
            var name = "San Juan";
            var phone = "7876880408";

            var location = new Location
            {
                Name = name,
                Phone = phone
            };

            // Action
            repo.AddLocation(location);

            // Push Change to DB
            repo.SaveChange();

            var actualLocation = repo.GetLocationByName(name);

            // Assert

            Assert.Equal(location, actualLocation);
        }


        [Fact]
        public void AddLocationShouldAddLocationToDB2()
        {
            // Arrange
            var name = "Rio Piedras";
            var phone = "7876977090";

            // Action
            repo.AddLocation(name, phone);

            // Push Change to DB
            repo.SaveChange();

            var actualLocation = repo.GetLocationByName(name);

            // Assert

            Assert.Equal(name, actualLocation.Name);

            // Delete the created user from DB
            repo.DeleteLocation(actualLocation.Id);
            repo.SaveChange();
        }


        // TODO 
        // Test in case of an already assigned foreing key
        [Fact]
        public void DeleteLocationById()
        {
            // Arrange
            var locations = (List<Location>)repo.GetAllLocation();

            var expectedLength = locations.Count - 1;
            var location = locations.LastOrDefault();

            // Action
            repo.DeleteLocation(location.Id);
            repo.SaveChange();

            locations = (List<Location>)repo.GetAllLocation();

            var actualLength = locations.Count;

            // Assert
            Assert.Equal(expectedLength, actualLength);
        }


        /* 
         * ItemType
         * TODO
         * 1. Create a new ItemType
         * 2. Get All ItemType
         * 3. Get ItemType by Name
         * 4. Get ItemType by ID
         * 5. Edit ItemType by ID
         * 6. Delete ItemType by ID
         */
        [Fact]
        public void GetAllItemTypeShouldReturnAListOfRegisteredItemType()
        {
            // Arrange
            List<ItemType> ItemTypes;

            // Action
            ItemTypes = (List<ItemType>)repo.GetAllItemType();

            // Assert
            Assert.NotNull(ItemTypes);
        }


        [Fact]
        public void GetItemTypeByIDShouldReturnTheCorrectItemType()
        {
            // Arrange
            ItemType itemType;
            string expected = "Dinner";

            // Action
            itemType = repo.GetItemTypeByID(1);
            var actual = itemType.Name;

            // Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void GetItemTypeByNameShouldReturnTheCorrectItemType()
        {
            // Arrange
            ItemType itemType;
            string expected = "Dinner";

            // Action
            itemType = repo.GetItemTypeByName(expected);
            var actual = itemType.Name;
            // Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void AddItemTypeShouldAddItemTypeToDB()
        {
            // Arrange
            var name = "Snack";

            var itemType = new ItemType
            {
                Name = name,
            };

            // Action
            repo.AddItemType(itemType);

            // Push Change to DB
            repo.SaveChange();

            var actualItemType = repo.GetItemTypeByName(name);

            // Assert

            Assert.Equal(itemType, actualItemType);
        }


        [Fact]
        public void AddItemTypeShouldAddItemTypeToDB2()
        {
            // Arrange
            var name = "Lunch";

            // Action
            repo.AddItemType(name);

            // Push Change to DB
            repo.SaveChange();

            var actualItemType = repo.GetItemTypeByName(name);

            // Assert

            Assert.Equal(name, actualItemType.Name);

            // Delete the created user from DB
            repo.DeleteItemType(actualItemType.Id);
            repo.SaveChange();
        }


        // TODO 
        // Test in case of an already assigned foreing key

        [Fact]
        public void DeleteItemTypeById()
        {
            // Arrange
            var itemTypes = (List<ItemType>)repo.GetAllItemType();

            var expectedLength = itemTypes.Count - 1;
            var itemType = itemTypes.LastOrDefault();

            // Action
            repo.DeleteItemType(itemType.Id);
            repo.SaveChange();

            itemTypes = (List<ItemType>)repo.GetAllItemType();

            var actualLength = itemTypes.Count;

            // Assert
            Assert.Equal(expectedLength, actualLength);
        }


        /* 
         * Inventory
         * TODO
         * 1. Create a new Inventory
         * 2. Get All Inventory
         * 3. Get Inventory by Name
         * 4. Get Inventory by ID
         * 5. Edit Inventory by ID
         * 6. Delete Inventory by ID
         */
        [Fact]
        public void GetAllInventoryShouldReturnAListOfRegisteredInventoryItemType()
        {
            // Arrange
            List<Inventory> inventories;

            // Action
            inventories = (List<Inventory>)repo.GetAllInvenrory();

            // Assert
            Assert.NotNull(inventories);
        }


        [Fact]
        public void GetInventoryByIDShouldReturnTheCorrectItemType()
        {
            // Arrange
            int id = 2;

            // Action
            var inventory = repo.GetInventoryByID(id);
            var actual = inventory.Id;
            var expected = id;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddInventoryShouldAddItemTypeToDB()
        {
            // Arrange
            var id = 1;
            var itemID = 1;
            var qty = 10;

            var inventory = new Inventory
            {
                LocationId = id,
                ItemId = itemID,
                Quantity = qty
            };

            // Action
            repo.AddInventory(inventory);

            // Push Change to DB
            repo.SaveChange();
            var actualInventory = repo.GetAllInvenrory().Last();


            // Assert
            Assert.Equal(inventory.LocationId, actualInventory.LocationId);
        }


        [Fact]
        public void AddInventoryShouldAddInventoryToDB2()
        {
            // Arrange
            var location = 1;
            var itemID = 1;
            var qty = 10;

            // Action
            repo.AddInventory(location, itemID, qty);

            // Push Change to DB
            repo.SaveChange();
            var actualInventory = repo.GetAllInvenrory().Last();


            // Assert
            Assert.Equal(location, actualInventory.LocationId);
            // Delete the created user from DB
            repo.DeleteInventory(actualInventory.Id);
            repo.SaveChange();
        }


        // TODO 
        // Test in case of an already assigned foreing key

        [Fact]
        public void DeleteInventoryById()
        {
            // Arrange
            var inventories = (List<Inventory>)repo.GetAllInvenrory();

            var expectedLength = inventories.Count - 1;
            var inventory = inventories.LastOrDefault();

            // Action
            repo.DeleteInventory(inventory.Id);
            repo.SaveChange();

            inventories = (List<Inventory>)repo.GetAllInvenrory();

            var actualLength = inventories.Count;

            // Assert
            Assert.Equal(expectedLength, actualLength);
        }
    }
}