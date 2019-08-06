using System;
using System.Linq;
using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM_NetCore_EF.Database;
using ORM_NetCore_EF.Database.Tables;

using static System.Console;

namespace ORM_NetCore_EF
{
    [TestClass]
    public class Playground
    {
        private readonly Commerce commerceFaker;
        private readonly Lorem lorem;
        private readonly Random random;

        public Playground()
        {
            commerceFaker = new Commerce();
            lorem = new Lorem();
            random = new Random();
        }

        [TestMethod]
        public void ReadData()
        {
            using (var database = new DatabaseContext())
            {
                var orders = database.Orders;
                foreach (var order in orders)
                {
                    WriteLine(order);
                }
            }
        }

        [TestMethod]
        [Ignore] //Comment out to run
        public void InsertProductsData()
        {
            using (var database = new DatabaseContext())
            {
                for (var i = 0; i < 100; i++)
                {
                    var product = new Product
                    {
                        Price = Convert.ToDouble(commerceFaker.Price()),
                        Description = lorem.Sentences()
                    };
                    database.Products.Add(product);
                }
                
                database.SaveChanges();

                foreach (var product in database.Products)
                {
                    WriteLine($"Product Id: [{product.ProductId}]");
                    WriteLine($"Product Description: [{product.Description}]");
                    WriteLine($"Product Price: [{product.Price}]");
                    WriteLine("---------------------------------");
                    WriteLine();
                }

            }
        }

        [TestMethod]
        [Ignore] //Comment out to run
        public void CreateOrderItems()
        {
            using (var database = new DatabaseContext())
            {
                foreach (var product in database.Products)
                {
                    var item = new OrderItem
                    {
                        Quantity = random.Next(),
                        Product = product
                    };
                    database.OrderItems.Add(item);
                }

                database.SaveChanges();
            }
        }

        [TestMethod]
        //[Ignore]
        public void CreateOrder()
        {
            using (var database = new DatabaseContext())
            {
                var order = new Order { Created = DateTime.Now };

                //Add ALL order items to create one giant order.
                foreach (var orderItem in database.OrderItems)
                {
                    order.Items.Add(orderItem);
                    
                }
                database.Orders.Add(order);
                database.SaveChanges();
            }
        }
    }
}
