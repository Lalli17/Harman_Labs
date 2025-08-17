namespace Company_Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var item1 = new Item("Book", 100);
            var item2 = new Item("Pen", 10);

            var orderedItem1 = new OrderedItem(item1, 2); // 200
            var orderedItem2 = new OrderedItem(item2, 5); // 50

            var order = new Order();
            order.OrderedItems.Add(orderedItem1);
            order.OrderedItems.Add(orderedItem2);

            var regCustomer = new RegCustomer(10); // 10% discount
            regCustomer.Orders.Add(order);

            var normalCustomer = new Customer();
            var order2 = new Order();
            order2.OrderedItems.Add(new OrderedItem(item1, 1)); // 100
            normalCustomer.Orders.Add(order2);

            var company = new Company();
            company.Customers.Add(regCustomer);
            company.Customers.Add(normalCustomer);

            Console.WriteLine($"Total worth of orders: {company.GetTotalWorthOfOrdersPlaced()}");
        }
    }
    public class Item
    {
        public string Desc { get; set; }
        public double Rate { get; set; }

        public Item(string desc, double rate)
        {
            Desc = desc;
            Rate = rate;
        }
    }

    // === OrderedItem ===
    public class OrderedItem
    {
        public Item Item { get; set; }
        public int Qty { get; set; }

        public OrderedItem(Item item, int qty)
        {
            Item = item;
            Qty = qty;
        }

        public double GetTotal()
        {
            return Item.Rate * Qty;
        }
    }

    // === Order ===
    public class Order
    {
        public List<OrderedItem> OrderedItems { get; set; } = new List<OrderedItem>();

        public double GetOrderTotal()
        {
            return OrderedItems.Sum(item => item.GetTotal());
        }
    }

    // === Customer ===
    public class Customer
    {
        public List<Order> Orders { get; set; } = new List<Order>();
    }

    // === RegCustomer (inherits Customer) ===
    public class RegCustomer : Customer
    {
        public double SplDiscount { get; set; } // percentage

        public RegCustomer(double discount)
        {
            SplDiscount = discount;
        }

        public double GetSplDiscount()
        {
            return SplDiscount;
        }
    }

    // === Company ===
    public class Company
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public double GetTotalWorthOfOrdersPlaced()
        {
            double total = 0;

            foreach (var customer in Customers)
            {
                foreach (var order in customer.Orders)
                {
                    double orderTotal = order.GetOrderTotal();

                    if (customer is RegCustomer regCustomer)
                    {
                        double discount = regCustomer.GetSplDiscount();
                        orderTotal -= orderTotal * (discount / 100);
                    }

                    total += orderTotal;
                }
            }

            return total;
        }
    }
}