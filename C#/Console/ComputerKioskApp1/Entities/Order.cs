namespace ComputerKioskApp.Entities
{
    public enum OrderStatus { PENDING, DELIVERED }

    public class Order
    {
        public int OrderId { get; set; }
        public required Customer Cust { get; set; }
        public required Computer Product { get; set; }
        public OrderStatus Status { get; set; }
    }
}
