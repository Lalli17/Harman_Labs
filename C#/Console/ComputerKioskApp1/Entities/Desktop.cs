namespace ComputerKioskApp.Entities
{
    public class Desktop : Computer
    {
        public int MonitorSize { get; set; }

        public override string Display() =>
            $"{ProductId} Desktop {CpuSpeed} {CpuType} {GraphicsCard} {HdCapacity} {Price} {MonitorSize} N.A. N.A.";
    }
}
