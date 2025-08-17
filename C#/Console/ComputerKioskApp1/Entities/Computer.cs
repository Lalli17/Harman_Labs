namespace ComputerKioskApp.Entities
{
    public abstract class Computer
    {
        public int ProductId { get; set; }
        public double CpuSpeed { get; set; }
        public string? CpuType { get; set; }           // changed from required
        public string? GraphicsCard { get; set; }      // changed from required
        public int HdCapacity { get; set; }
        public double Price { get; set; }

        public abstract string Display();
    }
}
