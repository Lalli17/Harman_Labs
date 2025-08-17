using FileIODemo2.Data;
using FileIODemo2.Entities;

namespace FileIODemo2.Presentation
{
    internal class Program
    {
        private static IContactRepository contactRepository = new ContactEFRepository(); //DIP
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Contact Management");
                Console.WriteLine("===================");
                Console.WriteLine("1. Create Contact");
                Console.WriteLine("2. Display Contacts");
                Console.WriteLine("3. Search Contact by Id");
                Console.WriteLine("4. Search Contact by Name");
                Console.WriteLine("5. Edit Contact");
                Console.WriteLine("6. Delete Contact");
                Console.WriteLine("7. Exit");
                Console.WriteLine("-----------------------");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: create(); break;
                    case 2: display(); break;

                    case 7: return;
                    default:
                        break;
                }
            }


        }

        private static void create()
        {
            try
            {
                Contact c = new Contact();
                Console.Write("Enter Contact Name: ");
                c.Name = Console.ReadLine();

                Console.Write("Enter Email: ");
                c.Email = Console.ReadLine();

                Console.Write("Enter Mobile: ");
                c.Mobile = Console.ReadLine();

                Console.Write("Enter Location: ");
                c.Location = Console.ReadLine();

                Console.Write("Enter Gender: ");
                c.Gender = Console.ReadLine();

                c.Id = Guid.NewGuid().ToString();

                contactRepository.Create(c);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void display()
        {
            var contacts = contactRepository.GetAll();
            //Console.WriteLine("ID\t\tName\tEmail\tMobile\tLocation\tGender");
            Console.WriteLine("{0,-40} {1,-25} {2,-25} {3,-15} {4,-15} {5,-1}",
    "ID", "Name", "Email", "Mobile", "Location", "Gender");
            foreach (var c in contacts)
            {
                Console.WriteLine($"{c.Id,-40}{c.Name,-25}{c.Email,-25}{c.Mobile,-15}{c.Location,-15}\t{c.Gender,-1}");
            }
        }
    }
}
