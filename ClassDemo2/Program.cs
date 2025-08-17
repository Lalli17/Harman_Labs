namespace ClassDemo2
{
    internal class Program
    {
        //Employee e = new Employee(); // Has A
        static void Main(string[] args)
        {
            // want to store emp and address details
            Employee e = new Employee(); // Uses
            Address address = new Address();

            e.Name = "Sachin";
            e.Salary = 900000;

            address.Area = "Area 1";
            address.City = "Bangalore";
            address.Country = "India";

            e.TheAddress = address;

            // display emp and address details

            Console.WriteLine(e.Name);
            //Console.WriteLine(address.City);
            Console.WriteLine(e.TheAddress.City);
        }
    }

    class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        //Address address = new Address();
        public Address TheAddress { get; set; }
    }

    class Address
    {
        public string Area { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
