namespace ComputerKioskApp.Entities
{
    public class Laptop : Computer
    {
        public double Weight { get; set; }
        public int BatteryDuration { get; set; }

        public override string Display() =>
            $"{ProductId} Laptop {CpuSpeed} {CpuType} {GraphicsCard} {HdCapacity} {Price} N.A. {Weight} {BatteryDuration}";
    }
}
