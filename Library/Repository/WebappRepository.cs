using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using Webapp.DataAccess.Models;

namespace Webapp.Library.Repository
{
    public class WebappRepository
    {
        private readonly PizzaStoreAppContext _db;

        public WebappRepository(PizzaStoreAppContext db)
        {
            _db = db ?? throw new ArgumentException(nameof(db));
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

        /// <summary>
        /// Adds the customer.
        /// </summary>
        /// <param name="firstName">First name.</param>
        /// <param name="lastname">Lastname.</param>
        /// <param name="location">Location.</param>
        public void AddCustomer(string firstName, string lastname, int location, string email, string password)
        {
            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastname,
                LocationId = location,
                Email = email,
                Password = password
            };

            _db.Add(customer);
        }

        public void AddCustomer(Customer customer)
        {
            _db.Add(customer);
        }

        /// <summary>
        /// Gets all customer.
        /// </summary>
        /// <returns>The all customer.</returns>
        public IEnumerable<Customer> GetAllCustomer()
        {
            List<Customer> customers = _db.Customer.AsNoTracking().ToList();

            return customers;
        }


        /// <summary>
        /// Gets the name of the customer by his name.
        /// </summary>
        /// <returns>The customer by name.</returns>
        /// <param name="firstName">Firs name.</param>
        public Customer GetCustomerByName(string firstName)
        {
            var customer = _db.Customer.Single(c => c.FirstName == firstName);

            return customer;
        }

        public List<Customer> SearchCustomerByName(string term)
        {
            var Customer = _db.Customer.Where(c => c.FirstName == term).ToList();
            return Customer;
        }

        public Customer GetCustomerByEmail(string email)
        {
            var customer = _db.Customer.Single(c => c.Email == email);

            return customer;
        }

        /// <summary>
        /// Gets the customer by identifier.
        /// </summary>
        /// <returns>The customer by identifier.</returns>
        /// <param name="id">Identifier.</param>
        public Customer GetCustomerByID(int id)
        {
            var customer = _db.Customer.Find(id);

            return customer;
        }


        /// <summary>
        /// Edits the customer.
        /// </summary>
        /// <param name="customer">Customer.</param>
        public void EditCustomer(Customer customer)
        {
            // With update if din't find it, will create a new entry
            _db.Customer.Update(customer);
        }


        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void DeleteCustomer(int id)
        {
            var customer = _db.Customer.Find(id);

            if (customer == null)
            {
                throw new ArgumentException("No such Customer ID", nameof(id));
            }

            _db.Remove(customer);
        }


        /* 
         * Item
         * TODO
         * 1. Create a new Item
         * 2. Get All Item
         * 3. Get Item by Name
         * 4. Get Item by ID
         * 5. Edit Item by ID
         * 6. Delete Item by ID
        */

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="price">Price.</param>
        public void AddItem(string name, decimal price, int type)
        {
            var item = new Item
            {
                Name = name,
                Price = price,
                ItemTypeId = type
            };

            _db.Add(item);
        }


        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">Item.</param>
        public void AddItem(Item item)
        {
            _db.Add(item);
        }


        /// <summary>
        /// Gets all item.
        /// </summary>
        /// <returns>The all item.</returns>
        public IEnumerable<Item> GetAllItem()
        {
            List<Item> items = _db.Item.AsNoTracking().ToList();

            return items;
        }


        /// <summary>
        /// Gets the name of the item by.
        /// </summary>
        /// <returns>The item by name.</returns>
        /// <param name="name">Name.</param>
        public Item GetItemByName(string name)
        {
            var item = _db.Item.Single(i => i.Name == name);

            return item;
        }


        /// <summary>
        /// Gets the item by identifier.
        /// </summary>
        /// <returns>The item by identifier.</returns>
        /// <param name="id">Identifier.</param>
        public Item GetItemByID(int id)
        {
            var item = _db.Item.Find(id);

            return item;
        }


        /// <summary>
        /// Edits the item.
        /// </summary>
        /// <param name="item">Item.</param>
        public void EditItem(Item item)
        {
            // With update if din't find it, will create a new entry
            _db.Item.Update(item);
        }


        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void DeleteItem(int id)
        {
            var item = _db.Item.Find(id);

            if (item == null)
            {
                throw new ArgumentException("No such Item ID", nameof(id));
            }

            _db.Remove(item);
        }


        /* 
         * Location
         * TODO
         * 1. Create a new Location
         * 2. Get All Location
         * 3. Get Location by Name
         * 4. Get Location by ID
         * 5. Edit Location  by ID
         * 6. Delete Location by ID
        */

        /// <summary>
        /// Adds the location.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="phone">Phone.</param>
        public void AddLocation(string name, string phone)
        {
            var location = new Location
            {
                Name = name,
                Phone = phone
            };

            _db.Add(location);
        }


        /// <summary>
        /// Adds the location.
        /// </summary>
        /// <param name="location">Location.</param>
        public void AddLocation(Location location)
        {
            _db.Add(location);
        }


        /// <summary>
        /// Gets all location.
        /// </summary>
        /// <returns>The all location.</returns>
        public IEnumerable<Location> GetAllLocation()
        {
            List<Location> locations = _db.Location.AsNoTracking().ToList();

            return locations;
        }


        /// <summary>
        /// Gets the name of the location by.
        /// </summary>
        /// <returns>The location by name.</returns>
        /// <param name="name">Name.</param>
        public Location GetLocationByName(string name)
        {
            var location = _db.Location.Single(l => l.Name == name);

            return location;
        }


        /// <summary>
        /// Gets the location by identifier.
        /// </summary>
        /// <returns>The location by identifier.</returns>
        /// <param name="id">Identifier.</param>
        public Location GetLocationByID(int id)
        {
            var location = _db.Location.Find(id);

            return location;
        }


        /// <summary>
        /// Edits the location.
        /// </summary>
        /// <param name="location">Location.</param>
        public void EditLocation(Location location)
        {
            // With update if din't find it, will create a new entry
            _db.Location.Update(location);
        }


        /// <summary>
        /// Deletes the location.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void DeleteLocation(int id)
        {
            var location = _db.Location.Find(id);

            if (location == null)
            {
                throw new ArgumentException("No such Item ID", nameof(id));
            }

            _db.Remove(location);
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

        /// <summary>
        /// Adds the type of the item.
        /// </summary>
        /// <param name="name">Name.</param>
        public void AddItemType(string name)
        {
            var itemType = new ItemType
            {
                Name = name,
            };

            _db.Add(itemType);
        }


        /// <summary>
        /// Adds the type of the item.
        /// </summary>
        /// <param name="itemType">Item type.</param>
        public void AddItemType(ItemType itemType)
        {
            _db.Add(itemType);
        }


        /// <summary>
        /// Gets the type of the all item.
        /// </summary>
        /// <returns>The all item type.</returns>
        public IEnumerable<ItemType> GetAllItemType()
        {
            List<ItemType> itemTypes = _db.ItemType.AsNoTracking().ToList();

            return itemTypes;
        }


        /// <summary>
        /// Gets the name of the item type by.
        /// </summary>
        /// <returns>The item type by name.</returns>
        /// <param name="name">Name.</param>
        public ItemType GetItemTypeByName(string name)
        {
            var itemType = _db.ItemType.Single(i => i.Name == name);

            return itemType;
        }


        /// <summary>
        /// Gets the item type by identifier.
        /// </summary>
        /// <returns>The item type by identifier.</returns>
        /// <param name="id">Identifier.</param>
        public ItemType GetItemTypeByID(int id)
        {
            var itemType = _db.ItemType.Find(id);

            return itemType;
        }


        /// <summary>
        /// Edits the type of the item.
        /// </summary>
        /// <param name="itemType">Item type.</param>
        public void EditItemType(ItemType itemType)
        {
            // With update if din't find it, will create a new entry
            _db.ItemType.Update(itemType);
        }


        /// <summary>
        /// Deletes the type of the item.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void DeleteItemType(int id)
        {
            var itemType = _db.ItemType.Find(id);

            if (itemType == null)
            {
                throw new ArgumentException("No such ItemType ID", nameof(id));
            }

            _db.Remove(itemType);
        }

        /* 
         * Inventory
         * TODO
         * 1. Create a new ItemType
         * 2. Get All ItemType
         * 3. Get ItemType by Name
         * 4. Get ItemType by ID
         * 5. Edit ItemType by ID
         * 6. Delete ItemType by ID
        */

        /// <summary>
        /// Adds the inventory.
        /// </summary>
        /// <param name="location">Location.</param>
        /// <param name="item">Item.</param>
        /// <param name="qty">Qty.</param>
        public void AddInventory(int location, int item, int qty)
        {
            var inventory = new Inventory
            {
                LocationId = location,
                ItemId = item,
                Quantity = qty
            };

            _db.Add(inventory);
        }


        /// <summary>
        /// Adds the inventory.
        /// </summary>
        /// <param name="inventory">Inventory.</param>
        public void AddInventory(Inventory inventory)
        {
            _db.Add(inventory);
        }


        /// <summary>
        /// Gets all invenrory.
        /// </summary>
        /// <returns>The all invenrory.</returns>
        public IEnumerable<Inventory> GetAllInvenrory()
        {
            List<Inventory> inventories = _db.Inventory.AsNoTracking().ToList();

            return inventories;
        }


        /// <summary>
        /// Gets the item inventory by identifier.
        /// </summary>
        /// <returns>The item inventory by identifier.</returns>
        /// <param name="id">Identifier.</param>
        public Inventory GetInventoryByID(int id)
        {
            var inventory = _db.Inventory.Find(id);

            return inventory;
        }


        /// <summary>
        /// Edits the inventory.
        /// </summary>
        /// <param name="inventory">Inventory.</param>
        public void EditInventory(Inventory inventory)
        {
            // With update if din't find it, will create a new entry
            _db.Inventory.Update(inventory);
        }


        /// <summary>
        /// Deletes the inventory.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void DeleteInventory(int id)
        {
            var inventory = _db.Inventory.Find(id);

            if (inventory == null)
            {
                throw new ArgumentException("No such Inventory ID", nameof(id));
            }

            _db.Remove(inventory);
        }


        public IEnumerable<Inventory> GetInventoryByLocationID(int locationID)
        {
            var inventory = _db.Inventory.Where(locID => locID.LocationId == locationID);

            return inventory.ToList();
        }


        /* 
         * Order
         * TODO
         * 1. Create a new Order
         * 2. Get All Order
         * 3. Get Order by Name
         * 4. Get Order by ID
         * 5. Edit Order by ID
         * 6. Delete Order by ID
        */

        /// <summary>
        /// Adds the orders.
        /// </summary>
        /// <param name="location">Location.</param>
        /// <param name="customer">Customer.</param>
        /// <param name="sales">Sales.</param>
        /// <param name="date">Date.</param>
        /// <param name="time">Time.</param>
        public void AddOrders(
            int location,
            int customer,
            decimal sales,
            DateTime date,
            TimeSpan time
            )
        {
            var orders = new Orders
            {
                LocationId = location,
                CustomerId = customer,
                Sale = sales,
                Date = date,
                Time = time
            };

            _db.Add(orders);
        }


        /// <summary>
        /// Adds the orders.
        /// </summary>
        /// <param name="order">Order.</param>
        public void AddOrders(Orders order)
        {
            _db.Add(order);
        }


        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns>The all orders.</returns>
        public IEnumerable<Orders> GetAllOrders()
        {
            List<Orders> orders = _db.Orders.AsNoTracking().ToList();

            return orders;
        }


        /// <summary>
        /// Gets the item orders by identifier.
        /// </summary>
        /// <returns>The item orders by identifier.</returns>
        /// <param name="id">Identifier.</param>
        public Orders GetItemOrdersByID(int id)
        {
            var order = _db.Orders.Single(o => o.Id == id);

            return order;
        }

        public List<Orders> GetAllOrdersByCustomer(int ID)
        {
            var orders = _db.Orders.Where(o => o.CustomerId == ID).ToList();
            return orders;
        }

        public List<Orders> GetAllOrdersByLocation(int ID)
        {
            var orders = _db.Orders.Where(o => o.LocationId == ID).ToList();
            return orders;
        }


        public List<Customer> GetAllCustomerByLocation(int ID)
        {
            var customers = _db.Customer.Where(o => o.LocationId == ID).ToList();
            return customers;
        }

        public List<OrderDetails> GetOrdersDetailsByOrderID(int ID)
        {
            var orderDetails = _db.OrderDetails.Where(o => o.OrderId == ID).ToList();
            return orderDetails;
        }


        /// <summary>
        /// Edits the orders.
        /// </summary>
        /// <param name="orders">Orders.</param>
        public void EditOrders(Orders orders)
        {
            // With update if din't find it, will create a new entry
            _db.Orders.Update(orders);
        }


        /// <summary>
        /// Deletes the orders.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void DeleteOrders(int id)
        {
            var orders = _db.Orders.Find(id);

            if (orders == null)
            {
                throw new ArgumentException("No such Orders ID", nameof(id));
            }

            _db.Remove(orders);
        }

        /* 
         * OrderDetails
         * TODO
         * 1. Create a new OrderDetails
         * 2. Get All OrderDetails
         * 3. Get OrderDetails by Name
         * 4. Get OrderDetails by ID
         * 5. Edit OrderDetails by ID
         * 6. Delete OrderDetails by ID
        */

        /// <summary>
        /// Adds the orders details.
        /// </summary>
        /// <param name="order">Order.</param>
        /// <param name="item">Item.</param>
        /// <param name="qty">Qty.</param>
        public void AddOrderDetails(
            int order,
            int item,
            int qty
            )
        {
            var ordersDetails = new OrderDetails
            {
                OrderId = order,
                ItemId = item,
                Quantity = qty
            };

            _db.Add(ordersDetails);
        }


        /// <summary>
        /// Adds the order details.
        /// </summary>
        /// <param name="orderDetails">Order details.</param>
        public void AddOrderDetails(OrderDetails orderDetails)
        {
            _db.Add(orderDetails);
        }


        /// <summary>
        /// Gets all order details.
        /// </summary>
        /// <returns>The all order details.</returns>
        public IEnumerable<OrderDetails> GetAllOrderDetails()
        {
            List<OrderDetails> orderDetails = _db.OrderDetails.AsNoTracking().ToList();

            return orderDetails;
        }


        /// <summary>
        /// Gets the item order details by identifier.
        /// </summary>
        /// <returns>The item order details by identifier.</returns>
        /// <param name="id">Identifier.</param>
        public OrderDetails GetItemOrderDetailsByID(int id)
        {
            var orderDetails = _db.OrderDetails.Single(o => o.Id == id);

            return orderDetails;
        }


        /// <summary>
        /// Edits the order details.
        /// </summary>
        /// <param name="orderDetails">Order details.</param>
        public void EditOrderDetails(OrderDetails orderDetails)
        {
            // With update if din't find it, will create a new entry
            _db.OrderDetails.Update(orderDetails);
        }


        /// <summary>
        /// Deletes the order details.
        /// </summary>
        /// <param name="id">Identifier.</param>
        public void DeleteOrderDetails(int id)
        {
            var orderDetails = _db.OrderDetails.Find(id);

            if (orderDetails == null)
            {
                throw new ArgumentException("No such OrderDetails ID", nameof(id));
            }

            _db.Remove(orderDetails);
        }
        // Commit Changes to DB
        public void SaveChange()
        {
            _db.SaveChanges();
        }
    }
}



