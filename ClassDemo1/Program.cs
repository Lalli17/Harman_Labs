namespace ClassDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee();
            e1.Name = "Ramesh";
            Console.WriteLine(e1.Name);
            //e1.name = "Ramesh";
            //e1.SetName("Ramesh");
            //Console.WriteLine(e1.GetName();
            //e1.salary = 75000;
            //e1.SetSalary(-1000);
            //Console.WriteLine(e1.GetSalary());


            Product p = new Product();
            p.ProductID = 111;
            p.Name = "Laptop";


            int id = p.ProductID;
            string pname = p.Name;

        }
    }

    public class Employee
    {
        private int salary;
        //private string name;
        //private string backingfield23234234234234;

        public string Name // Auto Properties
        {
            set;// { name = value; }
            get;// { return name; }
        }

        //public void SetSalary(int salary)
        //{
        //    if (salary >= 0)
        //    {
        //        this.salary = salary;
        //    }
        //    else
        //        this.salary = 0;
        //}

        //public int GetSalary()
        //{
        //    return this.salary;
        //}

        //public void SetName(string name)
        //{
        //    this.name = name;
        //}

        //public string GetName()
        //{
        //    return name;
        //}

        // Property

        public int Salary
        {
            get { return salary; }
            set
            {
                if (value >= 0)
                    salary = value;
                else
                    salary = 0;
            }
        }

    }


    class Product
    {
        public int ProductID { set; get; }
        public string Name { get; set; }
        public int Cost { get; set; }
    }
}
