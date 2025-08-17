using System;

namespace Kiosk_App
{
    public enum OrderStatus
    {
        PENDING,
        DELIVERED
    }

    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Computer Computer { get; set; }
        public OrderStatus Status { get; set; }

        public Order(int id, Customer customer, Computer computer)
        {
            Id = id;
            Customer = customer;
            Computer = computer;
            Status = OrderStatus.PENDING;
        }

        public void MarkDelivered()
        {
            Status = OrderStatus.DELIVERED;
        }

        public void Display()
        {
            Console.WriteLine($"Order ID: {Id}, Customer: {Customer.Name}, Computer ID: {Computer.Id}, Status: {Status}");
        }
    }
} 