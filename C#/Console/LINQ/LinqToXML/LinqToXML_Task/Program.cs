using System.Xml.Linq;

namespace LinqToXML_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
                XDocument doc = XDocument.Load("XMLFile1.xml");

                Console.WriteLine("Lab 1: Entire XML Content");
                Console.WriteLine(doc);
                Console.WriteLine();

                Console.WriteLine("Lab 2: Names of all Employees");
                var names = doc.Descendants("Employee").Select(e => e.Element("Name")?.Value);
                foreach (var name in names)
                    Console.WriteLine(name);
                Console.WriteLine();

                Console.WriteLine("Lab 3: Employee Name and ID");
                var empNameId = doc.Descendants("Employee")
                    .Select(e => new {
                        ID = e.Element("EmpId")?.Value,
                        Name = e.Element("Name")?.Value
                    });
                foreach (var emp in empNameId)
                    Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}");
                Console.WriteLine();

                Console.WriteLine("Lab 4: Female Employees");
                var females = doc.Descendants("Employee")
                    .Where(e => e.Element("Sex")?.Value == "Female")
                    .Select(e => e.Element("Name")?.Value);
                foreach (var name in females)
                    Console.WriteLine(name);
                Console.WriteLine();

                Console.WriteLine("Lab 5: Home Phone Numbers");
                var homePhones = doc.Descendants("Phone")
                    .Where(p => p.Attribute("Type")?.Value == "Home")
                    .Select(p => p.Value);
                foreach (var phone in homePhones)
                    Console.WriteLine(phone);
                Console.WriteLine();

                Console.WriteLine("Lab 6: Employees living in Alta");
                var altaResidents = doc.Descendants("Employee")
                    .Where(e => e.Element("Address")?.Element("City")?.Value == "Alta")
                    .Select(e => e.Element("Name")?.Value);
                foreach (var name in altaResidents)
                    Console.WriteLine(name);
                Console.WriteLine();

                Console.WriteLine("Lab 7: Sorted Zip Codes");
                var zipCodes = doc.Descendants("Zip")
                    .Select(z => z.Value)
                    .OrderBy(z => z);
                foreach (var zip in zipCodes)
                    Console.WriteLine(zip);
                Console.WriteLine();

                Console.WriteLine("Lab 8: First 2 Employee Details");
                var firstTwo = doc.Descendants("Employee").Take(2);
                foreach (var emp in firstTwo)
                    Console.WriteLine(emp);
                Console.WriteLine();

                Console.WriteLine("Lab 9: Count of Employees in State 'CA'");
                var caCount = doc.Descendants("Employee")
                    .Count(e => e.Element("Address")?.Element("State")?.Value == "CA");
                Console.WriteLine($"CA Employees: {caCount}");
                Console.WriteLine();

                Console.WriteLine("Lab 10: Female Employees and City");
                var femaleCity = doc.Descendants("Employee")
                    .Where(e => e.Element("Sex")?.Value == "Female")
                    .Select(e => new {
                        Name = e.Element("Name")?.Value,
                        City = e.Element("Address")?.Element("City")?.Value
                    });
                foreach (var item in femaleCity)
                    Console.WriteLine($"Name: {item.Name}, City: {item.City}");
            }
        }
    }
