using System.Runtime.CompilerServices;

namespace Demo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1= new Employee();
            //e1.name = "Ram";
            //e1.salary = 60000;

            e1.Name = "Ramesh";
            e1.Salary = 65000;
            
            
            // e1.SetName("Ramesh");
            //Console.WriteLine(e1.GetName());
            //e1.SetSalary(10000);
            //Console.WriteLine(e1.GetSalary());
         
            Product p1= new Product();
            p1.ProductID = 1;
            p1.Name = "Laptop";
            p1.Cost = 65000;


        }
    }

    public class Employee
    {
        //for automatic property do not create any variable by default the compiler creates a backingfield variable 
       // private string name;//by default they r private visible only to employee
        private int salary; //data members

        //clubbing both get an set methods via property

        public string Name //autmatic property and compiler does the work 
        {
            set;// { name = value; }
            get;// { return name;  }
        }

        public int Salary
        {
            set 
            {
                if(value>=0)
                    salary = value;
                else
                    salary = 0;
            } //remove this for read only
            get { return salary; }//remove this for write only
        }

    //public void SetSalary(int salary)
    //    {
    //        if (salary >= 0)
    //        {
    //            this.salary = salary;
    //        }
    //        else
    //            this.salary = 0;
    //    }
    //    public int GetSalary()
    //    {
    //        return this.salary;
    //    }
    //    public void SetName(string name)
    //    {
    //        this.name = name;   
    //    }
    //    public string GetName() {
    //        return this.name;
    //    }
    }

    class Product
    {
        public int ProductID { set; get; }
        public string Name { set; get; }
        public int Cost { set; get; }
    }



}



