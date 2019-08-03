namespace ORM_NetCore_EF.Database.Tables
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        
        /// <summary>
        /// Represents a FK
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
