using ComputerKioskApp.Entities;

namespace ComputerKioskApp.Data
{
    public interface IComputerRepository
    {
        void CreateComputer();
        List<Computer> SearchComputers(string type);
        Computer? GetComputerById(int id);
    }
}
