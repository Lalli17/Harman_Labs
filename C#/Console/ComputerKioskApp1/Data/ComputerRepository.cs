using ComputerKioskApp.Entities;

namespace ComputerKioskApp.Data.Repositories
{
    public class ComputerRepository : IComputerRepository
    {
        private readonly List<Computer> _computers = new();
        private int _productIdCounter = 1;

        public void CreateComputer()
        {
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("CUSTOMIZE YOUR COMPUTER MENU");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("l - Create a new Laptop");
            Console.WriteLine("d - Create a new Desktop");
            Console.WriteLine("b - Back to Admin Menu");

            Console.Write("Enter your option: ");
            string? choice = Console.ReadLine()?.ToLower();

            if (choice == "l")
                AddLaptop();
            else if (choice == "d")
                AddDesktop();
        }

        private void AddLaptop()
        {
            var laptop = new Laptop();
            laptop.ProductId = _productIdCounter++;

            FillCommonComputerDetails(laptop);

            Console.Write("Enter laptop weight: ");
            laptop.Weight = double.Parse(Console.ReadLine()!);

            Console.Write("Enter duration of battery: ");
            laptop.BatteryDuration = int.Parse(Console.ReadLine()!);

            _computers.Add(laptop);
            Console.WriteLine("Laptop added successfully.");
        }

        private void AddDesktop()
        {
            var desktop = new Desktop();
            desktop.ProductId = _productIdCounter++;

            FillCommonComputerDetails(desktop);

            Console.Write("Enter monitor size: ");
            desktop.MonitorSize = int.Parse(Console.ReadLine()!);

            _computers.Add(desktop);
            Console.WriteLine("Desktop added successfully.");
        }

        private void FillCommonComputerDetails(Computer computer)
        {
            Console.Write("Enter CPU speed (in GHz): ");
            computer.CpuSpeed = double.Parse(Console.ReadLine()!);

            Console.Write("Enter CPU type: ");
            computer.CpuType = Console.ReadLine()!;

            Console.Write("Enter Graphics Card: ");
            computer.GraphicsCard = Console.ReadLine()!;

            Console.Write("Enter Hard Disk Capacity (in GB): ");
            computer.HdCapacity = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Price: Rs.");
            computer.Price = double.Parse(Console.ReadLine()!);
        }

        public List<Computer> SearchComputers(string type)
        {
            return type switch
            {
                "l" => _computers.Where(c => c is Laptop).ToList(),
                "d" => _computers.Where(c => c is Desktop).ToList(),
                _ => new List<Computer>()
            };
        }

        public Computer? GetComputerById(int id)
        {
            return _computers.FirstOrDefault(c => c.ProductId == id);
        }
    }
}
