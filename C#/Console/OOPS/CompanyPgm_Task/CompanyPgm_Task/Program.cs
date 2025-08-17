

namespace CompanyPgm_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company
            {
                Name = "TechCorp",
                IncorporatedDt = new DateTime(2010, 5, 12)
            };

            company.AddEmployee(new Employee { EmpId = 1, Name = "Alice", Basic = 50000, Experience = 3 });
            company.AddEmployee(new Employee { EmpId = 2, Name = "Bob", Basic = 60000, Experience = 7 });

            company.AddCustomer(new Customer { CustomerId = 1, Name = "Charlie", Email = "charlie@example.com" });

            Console.WriteLine("Total Salary Payout: " + company.GetTotalSalaryPayout());
            Console.WriteLine("Total Employees: " + company.GetTotalEmployees());
            Console.WriteLine("Total Customers: " + company.GetTotalCustomers());

            Employee e = company.GetEmployee(1);
            Console.WriteLine($"Employee Found: {e?.Name}, Salary: {e?.GetSalary()}");
        }
    }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
        }

        public class Employee : Person
        {
            public int EmpId { get; set; }
            public double Basic { get; set; }
            public double Experience { get; set; }

            public double GetSalary()
            {
                double allowance = SalaryCalculator.CalculateSalary(Experience, Basic);
                return Basic + allowance;
            }
        }

        public class Customer : Person
        {
            public int CustomerId { get; set; }
            public string Email { get; set; }
        }

        public static class SalaryCalculator
        {
            public static double CalculateSalary(double experience, double basic)
            {
                double rate = 0;

                if (experience <= 2)
                    rate = 0.30;
                else if (experience <= 4)
                    rate = 0.40;
                else if (experience <= 6)
                    rate = 0.50;
                else
                    rate = 0.65;

                return basic * rate;
            }
        }

        public class Branch
        {
            public string Name { get; set; }
            public string Location { get; set; }

            // Optional: You can add flag like IsRegisteredOffice, IsCorporateOffice
        }

        public class Company
        {
            public string Name { get; set; }
            public DateTime IncorporatedDt { get; set; }

            private List<Employee> employees = new List<Employee>();
            private List<Customer> customers = new List<Customer>();
            private List<Branch> branches = new List<Branch>();

            public void AddEmployee(Employee emp)
            {
                employees.Add(emp);
            }

            public void AddCustomer(Customer customer)
            {
                customers.Add(customer);
            }

            public void AddBranch(Branch branch)
            {
                branches.Add(branch);
            }

            public Employee GetEmployee(int empId)
            {
                return employees.FirstOrDefault(e => e.EmpId == empId);
            }

            public double GetTotalSalaryPayout()
            {
                return employees.Sum(e => e.GetSalary());
            }

            public int GetTotalCustomers()
            {
                return customers.Count;
            }

            public int GetTotalEmployees()
            {
                return employees.Count;
            }
        }
    }

    