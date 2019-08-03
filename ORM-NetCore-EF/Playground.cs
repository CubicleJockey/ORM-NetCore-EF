using System;
using Bogus;
using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM_NetCore_EF.Database;
using ORM_NetCore_EF.Database.Tables;

namespace ORM_NetCore_EF
{
    [TestClass]
    public class Playground
    {
        private readonly Commerce commerceFaker;
        private readonly Lorem lorem;

        public Playground()
        {
            commerceFaker = new Commerce();
            lorem = new Lorem();
        }

        [TestMethod]
        public void ReadData()
        {
            using (var database = new DatabaseContext())
            {
                var orders = database.Orders;
                foreach (var order in orders)
                {
                    Console.WriteLine(order);
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
                    Console.WriteLine($"Product Id: [{product.ProductId}]");
                    Console.WriteLine($"Product Description: [{product.Description}]");
                    Console.WriteLine($"Product Price: [{product.Price}]");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine();
                }

            }
        }
    }
}
