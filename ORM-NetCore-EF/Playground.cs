using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM_NetCore_EF.Database;

namespace ORM_NetCore_EF
{
    [TestClass]
    public class Playground
    {
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
    }
}
