using System;
using System.Collections.Generic;

namespace ORM_NetCore_EF.Database.Tables
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime? Created { get; set; }

        /// <summary>
        /// This represents a 1-to-many relationship
        /// </summary>
        public ICollection<OrderItem> Items { get; set; }
    }
}
