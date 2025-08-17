using ComputerKioskApp.Data;
using ComputerKioskApp.Data.Repositories;
using ComputerKioskApp.Entities;
using ComputerKioskApp.Exceptions;


namespace ComputerKioskApp.Presentation
{
    public class Program
    {
        private static IComputerRepository _computerRepo = new ComputerRepository();
        private static List<Customer> _customers = new();
        private static List<Order> _orders = new();
        private static Admin _admin = new("4321", "admin123", "Admin", 30, "M");
        private static int _customerIdCounter = 1;
        private static int _orderIdCounter = 1;

        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    ShowMainMenu();
                    string? choice = Console.ReadLine()?.ToLower();

                    switch (choice)
                    {
                        case "a":
                            AdminLogin();
                            break;
                        case "n":
                            CreateNewCustomer();
                            break;
                        case "e":
                            ExistingCustomerLogin();
                            break;
                        case "s":
                            SearchAndOrder();
                            break;
                        case "x":
                            Console.WriteLine("Exiting application...");
                            return;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("\nWelcome to NEWAGE COMPUTER KIOSK");
            Console.WriteLine("=============================================================================");
            Console.WriteLine("MAIN MENU\n-----------------------------------------------------------------------------");
            Console.WriteLine("a - Admin Login");
            Console.WriteLine("n - Create a new Customer");
            Console.WriteLine("e - Existing Customer Login");
            Console.WriteLine("s - Search");
            Console.WriteLine("x - Quit");
            Console.Write("Please enter your option: ");
        }

        private static void AdminLogin()
        {
            Console.Write("Enter Login Id: ");
            string? id = Console.ReadLine();

            Console.Write("Enter Password: ");
            string? pwd = Console.ReadLine();

            if (id == _admin.AdminId && pwd == _admin.Password)
            {
                Console.WriteLine("Admin Authenticated...");
                ShowAdminMenu();
            }
            else
            {
                throw new InvalidLoginException("Invalid admin credentials.");
            }
        }

        private static void ShowAdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\n-----------------------------------------------------------------------------");
                Console.WriteLine("ADMIN MENU\n-----------------------------------------------------------------------------");
                Console.WriteLine("c - Create a new Computer");
                Console.WriteLine("p - Process pending Orders");
                Console.WriteLine("x - Quit");
                Console.Write("Please enter your option: ");

                string? option = Console.ReadLine()?.ToLower();
                switch (option)
                {
                    case "c":
                        _computerRepo.CreateComputer();
                        break;
                    case "p":
                        ProcessPendingOrders();
                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }
            }
        }

        private static void CreateNewCustomer()
        {
            Console.Write("Enter Customer Name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
                throw new FormatException("Invalid age.");

            Console.Write("Enter Gender: ");
            string? gender = Console.ReadLine();

            Console.Write("Enter Shipping Address: ");
            string? address = Console.ReadLine();

            var customer = new Customer
            {
                CustomerId = _customerIdCounter++,
                Name = name!,
                Age = age,
                Gender = gender!,
                ShippingAddress = address!
            };

            _customers.Add(customer);
            Console.WriteLine($"Customer registered successfully! Your ID is {customer.CustomerId}");
        }

        private static void ExistingCustomerLogin()
        {
            Console.Write("Enter your customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            var customer = _customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
                throw new EntityNotFoundException("Customer", id);

            Console.WriteLine($"Welcome back, {customer.Name}!");
        }

    
        private static void SearchAndOrder()
        {
            Console.WriteLine("Search Options:\nl - Laptop\nd - Desktop");
            string? type = Console.ReadLine()?.ToLower();

            if (string.IsNullOrWhiteSpace(type) || (type != "l" && type != "d"))
            {
                Console.WriteLine("Invalid type selection.");
                return;
            }

            var results = _computerRepo.SearchComputers(type);

            if (!results.Any())
            {
                Console.WriteLine("No products match your search.");
                return;
            }

            Console.WriteLine("\nAvailable Products:");
            Console.WriteLine("ProductID | Type     | CPU Speed | CPU Type | Graphics | HDD | Price | Monitor | Weight | Battery");
            foreach (var comp in results)
            {
                Console.WriteLine(comp.Display());
            }

            Console.Write("\nDo you wish to place order (Y/N)? ");
            if (Console.ReadLine()?.ToLower() != "y") return;

            Console.Write("Existing Customers enter ID. New Customers enter 0: ");
            if (!int.TryParse(Console.ReadLine(), out int custId))
            {
                Console.WriteLine("Invalid customer ID.");
                return;
            }

            Customer customer;
            if (custId == 0)
            {
                CreateNewCustomer();
                customer = _customers.Last();
            }
            else
            {
                customer = _customers.FirstOrDefault(c => c.CustomerId == custId)
                    ?? throw new OrderPlacementException("Customer ID not found.");
            }

            Console.Write("Please enter product ID to order: ");
            if (!int.TryParse(Console.ReadLine(), out int pid))
            {
                Console.WriteLine("Invalid product ID.");
                return;
            }

            var product = _computerRepo.GetComputerById(pid)
                ?? throw new OrderPlacementException("Product not found.");

            var order = new Order
            {
                OrderId = _orderIdCounter++,
                Cust = customer,
                Product = product,
                Status = OrderStatus.PENDING
            };

            _orders.Add(order);
            PrintOrderConfirmation(order);
        }

        private static void PrintOrderConfirmation(Order order)
        {
            Console.WriteLine("\n=============================================================================");
            Console.WriteLine("                              ORDER CONFIRMATION                             ");
            Console.WriteLine("=============================================================================");
            Console.WriteLine($" Order Id         : {order.OrderId}");
            Console.WriteLine($" Customer Id      : {order.Cust.CustomerId}");
            Console.WriteLine($" Customer Name    : {order.Cust.Name}");
            Console.WriteLine($" Shipping Address : {order.Cust.ShippingAddress}");
            Console.WriteLine($" Order Status     : {order.Status}");
            Console.WriteLine("Ordered Computer Information");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("ProductID Computer Type CPU Speed CPU Type Graphics Card HDCapacity Price MonitorSize Weight BatteryDuration");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine(order.Product.Display());
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Thank you for placing the order with us.");
            Console.WriteLine("The ordered product will be sent to the above Shipping Address within 48 hours.");
            Console.WriteLine("We request a Cash On Delivery on receipt of the consignment.");
        }

        private static void ProcessPendingOrders()
        {
            var pending = _orders.Where(o => o.Status == OrderStatus.PENDING).ToList();

            if (!pending.Any())
            {
                Console.WriteLine("No pending orders.");
                return;
            }

            Console.WriteLine("Pending Orders:");
            foreach (var o in pending)
            {
                Console.WriteLine($"OrderID: {o.OrderId}, Customer: {o.Cust.Name}, ProductID: {o.Product.ProductId}");
                o.Status = OrderStatus.DELIVERED;
            }

            Console.WriteLine("All pending orders marked as DELIVERED.");
        }
    }
}
