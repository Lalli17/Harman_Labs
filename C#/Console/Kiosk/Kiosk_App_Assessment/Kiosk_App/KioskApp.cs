using System;
using System.Collections.Generic;
using System.Linq;

namespace Kiosk_App
{
    public class KioskApp
    {
        private List<Computer> computers = new List<Computer>();
        private List<Customer> customers = new List<Customer>();
        private List<Admin> admins = new List<Admin>();
        private List<Order> orders = new List<Order>();
        private int nextComputerId = 1;
        private int nextCustomerId = 1;
        private int nextOrderId = 1;
        private int nextAdminId = 1;
        private string shopName = "NEWAGE COMPUTER KIOSK";

        public KioskApp()
        {
            admins.Add(new Admin(nextAdminId++, "Admin", 30, "Other", "admin123"));
        }

        public void Run()
        {
            while (true)
            {
                PrintHeader();
                PrintMainMenu();
                Console.Write("Please enter your option:");
                var choice = Console.ReadLine()?.Trim().ToLower();
                switch (choice)
                {
                    case "a":
                        AdminLogin();
                        break;
                    case "n":
                        CreateCustomer();
                        break;
                    case "e":
                        ExistingCustomerLogin();
                        break;
                    case "s":
                        SearchMenu();
                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private void PrintHeader()
        {
            Console.WriteLine("=============================================================================");
            Console.WriteLine($"Welcome to {shopName}");
            Console.WriteLine("=============================================================================");
        }

        private void PrintMainMenu()
        {
            Console.WriteLine("-----------------------------------------------------------------------------\nMAIN MENU\n-----------------------------------------------------------------------------");
            Console.WriteLine("a - Admin Login");
            Console.WriteLine("n - Create a new Customer");
            Console.WriteLine("e - Existing Customer Login");
            Console.WriteLine("s - Search");
            Console.WriteLine("x - Quit");
        }

        private void AdminLogin()
        {
            Console.Write("Enter Login Id:");
            if (!int.TryParse(Console.ReadLine(), out int adminId))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }
            Console.Write("Enter password:");
            var password = Console.ReadLine();
            var admin = admins.FirstOrDefault(a => a.Id == adminId);
            if (admin != null && admin.Authenticate(password))
            {
                Console.WriteLine("Admin Authenticated...");
                AdminMenu();
            }
            else
            {
                Console.WriteLine("Authentication failed.");
            }
        }

        private void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("-----------------------------------------------------------------------------\nADMIN MENU\n-----------------------------------------------------------------------------");
                Console.WriteLine("c - Create a new Computer");
                Console.WriteLine("p - Process pending Orders");
                Console.WriteLine("x - Quit");
                Console.Write("Please enter your option:");
                var choice = Console.ReadLine()?.Trim().ToLower();
                switch (choice)
                {
                    case "c":
                        CustomizeComputerMenu();
                        break;
                    case "p":
                        Console.WriteLine("To process pending orders.....");
                        ProcessPendingOrders();
                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private void CustomizeComputerMenu()
        {
            while (true)
            {
                Console.WriteLine("-----------------------------------------------------------------------------\nCUSTOMIZE YOUR COMPUTER MENU\n-----------------------------------------------------------------------------");
                Console.WriteLine("l - Create a new Laptop");
                Console.WriteLine("d - Create a new Desktop");
                Console.WriteLine("b - Back to main menu");
                var type = Console.ReadLine()?.Trim().ToLower();
                if (type == "l")
                {
                    CreateLaptop();
                }
                else if (type == "d")
                {
                    CreateDesktop();
                }
                else if (type == "b")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }

        private void CreateLaptop()
        {
            Console.WriteLine("-----------------------------------------------------------------------------\nCREATE NEW LAPTOP\n-----------------------------------------------------------------------------");
            Console.Write("Enter CPU speed (in GHZ):"); if (!double.TryParse(Console.ReadLine(), out double speed)) return;
            Console.Write("Enter CPU Type:"); var cpu = Console.ReadLine();
            Console.Write("Enter Graphics Card:"); var gpu = Console.ReadLine();
            Console.Write("Enter Hard Disk Capacity(in GB):"); if (!int.TryParse(Console.ReadLine(), out int hdd)) return;
            Console.Write("Enter price :Rs."); if (!decimal.TryParse(Console.ReadLine(), out decimal price)) return;
            Console.Write("Enter laptop weight:"); if (!double.TryParse(Console.ReadLine(), out double weight)) return;
            Console.Write("Enter duration of battery:"); if (!double.TryParse(Console.ReadLine(), out double battery)) return;
            var laptop = new Laptop(nextComputerId++, cpu, speed, hdd, gpu, price, weight, battery);
            computers.Add(laptop);
            Console.WriteLine("-----------------------------------------------------------------------------\nLaptop Computer has been successfully added\n-----------------------------------------------------------------------------");
        }

        private void CreateDesktop()
        {
            Console.WriteLine("-----------------------------------------------------------------------------\nCREATE NEW DESKTOP\n-----------------------------------------------------------------------------");
            Console.Write("Enter CPU speed (in GHZ):"); if (!double.TryParse(Console.ReadLine(), out double speed)) return;
            Console.Write("Enter CPU Type:"); var cpu = Console.ReadLine();
            Console.Write("Enter Graphics Card:"); var gpu = Console.ReadLine();
            Console.Write("Enter Hard Disk Capacity(in GB):"); if (!int.TryParse(Console.ReadLine(), out int hdd)) return;
            Console.Write("Enter price :Rs."); if (!decimal.TryParse(Console.ReadLine(), out decimal price)) return;
            Console.Write("Enter monitor size (inches):"); if (!double.TryParse(Console.ReadLine(), out double monitor)) return;
            var desktop = new Desktop(nextComputerId++, cpu, speed, hdd, gpu, price, monitor);
            computers.Add(desktop);
            Console.WriteLine("-----------------------------------------------------------------------------\nDesktop Computer has been successfully added\n-----------------------------------------------------------------------------");
        }

        private void ProcessPendingOrders()
        {
            var pending = orders.Where(o => o.Status == OrderStatus.PENDING).ToList();
            if (!pending.Any())
            {
                Console.WriteLine("No pending orders.");
                return;
            }
            foreach (var order in pending)
            {
                order.Display();
                Console.Write($"Mark order {order.Id} as delivered? (y/n): ");
                if (Console.ReadLine()?.ToLower() == "y")
                {
                    order.MarkDelivered();
                    Console.WriteLine("Order delivered and payment collected.");
                }
            }
        }

        private void CreateCustomer()
        {
            Console.Write("Enter Name:"); var name = Console.ReadLine();
            Console.Write("Enter Age:"); if (!int.TryParse(Console.ReadLine(), out int age)) return;
            Console.Write("Enter Gender:"); var gender = Console.ReadLine();
            Console.Write("Enter Shipping Address:"); var address = Console.ReadLine();
            var customer = new Customer(nextCustomerId++, name, age, gender, address);
            customers.Add(customer);
            Console.WriteLine($"Customer created successfully. Your Customer ID is: {customer.Id}");
        }

        private void ExistingCustomerLogin()
        {
            Console.Write("Enter Customer ID:");
            if (!int.TryParse(Console.ReadLine(), out int custId))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }
            var customer = customers.FirstOrDefault(c => c.Id == custId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }
            Console.WriteLine($"Welcome back, {customer.Name}!");
            // Optionally, allow customer to view orders or place new order
        }

        private void SearchMenu()
        {
            Console.WriteLine("l - Laptop\nd - Desktop");
            Console.Write("Please enter your option:");
            var type = Console.ReadLine()?.Trim().ToLower();
            if (type != "l" && type != "d")
            {
                Console.WriteLine("Invalid option.");
                return;
            }
            string compType = type == "l" ? "Laptop" : "Desktop";
            Console.WriteLine("Choose the characteristics you would like to consider");
            Console.WriteLine("s - CPU speed\nt - CPU type\ng - Graphics Card\nh - Hard Disk Capacity\np - Price" + (type == "l" ? "\nw - Weight\nb - Battery Duration" : "\nm - Monitor Size"));
            var sortOpt = Console.ReadLine()?.Trim().ToLower();
            IEnumerable<Computer> filtered = computers.Where(c => c.ComputerType.ToLower() == compType.ToLower());
            switch (sortOpt)
            {
                case "s":
                    filtered = filtered.OrderBy(c => c.CpuSpeed);
                    break;
                case "t":
                    filtered = filtered.OrderBy(c => c.CpuType);
                    break;
                case "g":
                    filtered = filtered.OrderBy(c => c.GraphicsCard);
                    break;
                case "h":
                    filtered = filtered.OrderBy(c => c.HardDisk);
                    break;
                case "p":
                    filtered = filtered.OrderBy(c => c.Price);
                    break;
                case "w":
                    if (type == "l") filtered = filtered.Cast<Laptop>().OrderBy(l => l.Weight);
                    break;
                case "b":
                    if (type == "l") filtered = filtered.Cast<Laptop>().OrderBy(l => l.BatteryDuration);
                    break;
                case "m":
                    if (type == "d") filtered = filtered.Cast<Desktop>().OrderBy(d => d.MonitorSize);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }
            PrintComputerTable(filtered, type);
            Console.WriteLine("Do you wish to place order (Y/N)?");
            if (Console.ReadLine()?.Trim().ToLower() == "y")
            {
                PlaceOrderFlow(type);
            }
        }

        private void PrintComputerTable(IEnumerable<Computer> comps, string type)
        {
            string header = string.Format(
                "{0,-10} {1,-13} {2,-9} {3,-10} {4,-13} {5,-10} {6,-8} {7,-12} {8,-7} {9,-15}",
                "ProductID", "Computer Type", "CPU Speed", "CPU Type", "Graphics Card", "HDCapacity", "Price", "MonitorSize", "Weight", "BatteryDuration"
            );
            Console.WriteLine(header);
            foreach (var c in comps)
            {
                if (type == "l" && c is Laptop l)
                {
                    Console.WriteLine(
                        "{0,-10} {1,-13} {2,-9} {3,-10} {4,-13} {5,-10} {6,-8} {7,-12} {8,-7} {9,-15}",
                        l.Id, "Laptop", l.CpuSpeed, l.CpuType, l.GraphicsCard, l.HardDisk, l.Price, "N.A.", l.Weight, l.BatteryDuration
                    );
                }
                else if (type == "d" && c is Desktop d)
                {
                    Console.WriteLine(
                        "{0,-10} {1,-13} {2,-9} {3,-10} {4,-13} {5,-10} {6,-8} {7,-12} {8,-7} {9,-15}",
                        d.Id, "Desktop", d.CpuSpeed, d.CpuType, d.GraphicsCard, d.HardDisk, d.Price, d.MonitorSize, "N.A.", "N.A."
                    );
                }
            }
        }

        private void PlaceOrderFlow(string type)
        {
            Console.WriteLine("Existing Customers enter Login ID. New Customers enter 0 :");
            if (!int.TryParse(Console.ReadLine(), out int custId)) return;
            Customer customer = null;
            if (custId == 0)
            {
                CreateCustomer();
                customer = customers.Last();
            }
            else
            {
                customer = customers.FirstOrDefault(c => c.Id == custId);
                if (customer == null)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }
            }
            Console.WriteLine("Please enter product Id:");
            if (!int.TryParse(Console.ReadLine(), out int prodId)) return;
            var comp = computers.FirstOrDefault(c => c.Id == prodId && c.ComputerType.ToLower().StartsWith(type));
            if (comp == null)
            {
                Console.WriteLine("Computer not found.");
                return;
            }
            var order = new Order(nextOrderId++, customer, comp);
            orders.Add(order);
            PrintOrderConfirmation(order);
        }

        private void PrintOrderConfirmation(Order order)
        {
            Console.WriteLine("=============================================================================");
            Console.WriteLine("ORDER CONFIRMATION");
            Console.WriteLine("=============================================================================Order Id : " + order.Id);
            Console.WriteLine("Customer Id : " + order.Customer.Id);
            Console.WriteLine("Customer Name : " + order.Customer.Name);
            Console.WriteLine("Shipping Address : " + order.Customer.ShippingAddress);
            Console.WriteLine("Order Status : " + order.Status);
            Console.WriteLine("Ordered Computer Information");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            string header = string.Format(
                "{0,-10} {1,-13} {2,-9} {3,-10} {4,-13} {5,-10} {6,-8} {7,-12} {8,-7} {9,-15}",
                "ProductID", "Computer Type", "CPU Speed", "CPU Type", "Graphics Card", "HDCapacity", "Price", "MonitorSize", "Weight", "BatteryDuration"
            );
            Console.WriteLine(header);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            if (order.Computer is Laptop l)
                Console.WriteLine(
                    "{0,-10} {1,-13} {2,-9} {3,-10} {4,-13} {5,-10} {6,-8} {7,-12} {8,-7} {9,-15}",
                    l.Id, "Laptop", l.CpuSpeed, l.CpuType, l.GraphicsCard, l.HardDisk, l.Price, "N.A.", l.Weight, l.BatteryDuration
                );
            else if (order.Computer is Desktop d)
                Console.WriteLine(
                    "{0,-10} {1,-13} {2,-9} {3,-10} {4,-13} {5,-10} {6,-8} {7,-12} {8,-7} {9,-15}",
                    d.Id, "Desktop", d.CpuSpeed, d.CpuType, d.GraphicsCard, d.HardDisk, d.Price, d.MonitorSize, "N.A.", "N.A."
                );
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Thank you for placing the order with us.\nThe ordered product will be sent to the above Shipping Address within 48 hours\nWe request a Cash On Delivery on receipt of the consignment");
            Console.WriteLine("-----------------------------------------------------------------------------");
        }
    }
} 