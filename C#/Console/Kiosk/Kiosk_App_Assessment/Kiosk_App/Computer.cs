using System;

namespace Kiosk_App
{
    public abstract class Computer
    {
        public int Id { get; set; }
        public string ComputerType { get; set; } // "Desktop" or "Laptop"
        public string CpuType { get; set; }
        public double CpuSpeed { get; set; } // GHz
        public int HardDisk { get; set; } // GB
        public string GraphicsCard { get; set; }
        public decimal Price { get; set; }

        public Computer(int id, string computerType, string cpuType, double cpuSpeed, int hardDisk, string graphicsCard, decimal price)
        {
            Id = id;
            ComputerType = computerType;
            CpuType = cpuType;
            CpuSpeed = cpuSpeed;
            HardDisk = hardDisk;
            GraphicsCard = graphicsCard;
            Price = price;
        }

        public abstract void Display();
    }

    public class Desktop : Computer
    {
        public double MonitorSize { get; set; } // inches
        public Desktop(int id, string cpuType, double cpuSpeed, int hardDisk, string graphicsCard, decimal price, double monitorSize)
            : base(id, "Desktop", cpuType, cpuSpeed, hardDisk, graphicsCard, price)
        {
            MonitorSize = monitorSize;
        }
        public override void Display()
        {
            Console.WriteLine($"[Desktop] ID: {Id}, CPU: {CpuType} {CpuSpeed}GHz, HDD: {HardDisk}GB, GPU: {GraphicsCard}, Price: {Price:C}, Monitor: {MonitorSize}\" ");
        }
    }

    public class Laptop : Computer
    {
        public double Weight { get; set; } // kg
        public double BatteryDuration { get; set; } // hours
        public Laptop(int id, string cpuType, double cpuSpeed, int hardDisk, string graphicsCard, decimal price, double weight, double batteryDuration)
            : base(id, "Laptop", cpuType, cpuSpeed, hardDisk, graphicsCard, price)
        {
            Weight = weight;
            BatteryDuration = batteryDuration;
        }
        public override void Display()
        {
            Console.WriteLine($"[Laptop] ID: {Id}, CPU: {CpuType} {CpuSpeed}GHz, HDD: {HardDisk}GB, GPU: {GraphicsCard}, Price: {Price:C}, Weight: {Weight}kg, Battery: {BatteryDuration}h");
        }
    }
} 