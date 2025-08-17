using FileIO_Demo1.Data;
using FileIO_Demo1.Entity;

namespace FileIO_Demo1.Presentation
{
    internal class Program
    {
        public static IContactRepository contactRepository = new ClassRepository();
        public static object contacts;

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Contact Management");
                Console.WriteLine("======================");
                Console.WriteLine("1. Create Contact");
                Console.WriteLine("2. Display Contacts");
                Console.WriteLine("3. Search contact by Id");
                Console.WriteLine("4. Search contact by Name");
                Console.WriteLine("5 Edit Contact");
                Console.WriteLine("6. Delete Contact");
                Console.WriteLine("7. Exit");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Enter your choice");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: create(); break;
                    case 2: Display(); break;
                    case 3: SearchById(); break;
                    case 4: SearchByName(contacts); break;
                    case 5: Edit(); break;
                    case 6: Delete(); break;
                    case 7: return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 7.");
                        break;

                }

            }
        }

        private static void SearchByName(object contacts)
        {
            throw new NotImplementedException();
        }

        private static void create()
        {
            Contact c = new Contact();

            Console.WriteLine("enter contact name");
            c.Name = Console.ReadLine();

            Console.WriteLine("enter email");
            c.Email = Console.ReadLine();

            Console.WriteLine("enter mobile");
            c.Mobile = Console.ReadLine();

            Console.WriteLine("enter location");
            c.Location = Console.ReadLine();

            Console.WriteLine("enter gender");
            c.Gender = Console.ReadLine();

            c.Id=Guid.NewGuid().ToString();


            contactRepository.Create(c);
            Console.WriteLine("Contact created successfully.\n");
        }


            private static void Display()
            {
                var contacts = contactRepository.GetAll();

                //if (!contacts.Any())
                //{
                //    Console.WriteLine("No contacts found.\n");
                //    return;
                //}

                // Header with spacing
                Console.WriteLine(
                    $"{Pad("ID", 36)} {Pad("Name", 15)} {Pad("Email", 25)} {Pad("Mobile", 15)} {Pad("Location", 15)} {Pad("Gender", 10)}");

                Console.WriteLine(new string('-', 120));

                foreach (var c in contacts)
                {
                    Console.WriteLine(
                        $"{Pad(c.Id, 36)} {Pad(c.Name, 15)} {Pad(c.Email, 25)} {Pad(c.Mobile, 15)} {Pad(c.Location, 15)} {Pad(c.Gender, 10)}");
                }

                Console.WriteLine();
            }

            private static void SearchById()
            {
                Console.Write("Enter contact Id to search: ");
                string id = Console.ReadLine();

                var contact = contactRepository.GetById(id);

                if (contact == null)
                {
                    Console.WriteLine("Contact not found.");
                }
                else
                {
                    PrintContact(contact);
                }
            }

            private static void SearchByName(Contact contacts)
            {
                Console.Write("Enter contact name to search: ");
                string name = Console.ReadLine();

                var con = contactRepository.GetByName(name);

                if (!contacts.Any())
                {
                    Console.WriteLine("No contacts found with that name.");
                }
                else
                {
                    foreach (var c in con)
                    {
                        PrintContact(c);
                    }
                }
            }

            private static void Edit()
            {
                Console.Write("Enter contact Id to edit: ");
                string id = Console.ReadLine();

                var contact = contactRepository.GetById(id);

                if (contact == null)
                {
                    Console.WriteLine("Contact not found.");
                    return;
                }

                Console.WriteLine("Leave blank to keep current value.");

                Console.Write($"Enter new name ({contact.Name}): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name)) contact.Name = name;

                Console.Write($"Enter new email ({contact.Email}): ");
                string email = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(email)) contact.Email = email;

                Console.Write($"Enter new mobile ({contact.Mobile}): ");
                string mobile = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(mobile)) contact.Mobile = mobile;

                Console.Write($"Enter new location ({contact.Location}): ");
                string location = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(location)) contact.Location = location;

                Console.Write($"Enter new gender ({contact.Gender}): ");
                string gender = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(gender)) contact.Gender = gender;

                contactRepository.Edit(contact);
                Console.WriteLine("Contact updated successfully.");
            }

            private static void Delete()
            {
                Console.Write("Enter contact Id to delete: ");
                string id = Console.ReadLine();

                var contact = contactRepository.GetById(id);

                if (contact == null)
                {
                    Console.WriteLine("Contact not found.");
                    return;
                }

                contactRepository.Delete(id);
                Console.WriteLine("Contact deleted successfully.");
            }

            private static void PrintContact(Contact c)
            {
                Console.WriteLine();
                Console.WriteLine($"Id       : {c.Id}");
                Console.WriteLine($"Name     : {c.Name}");
                Console.WriteLine($"Email    : {c.Email}");
                Console.WriteLine($"Mobile   : {c.Mobile}");
                Console.WriteLine($"Location : {c.Location}");
                Console.WriteLine($"Gender   : {c.Gender}");
                Console.WriteLine();
            }

            // Utility for spacing
            private static string Pad(string text, int width)
            {
                if (text == null) return new string(' ', width);
                return text.Length >= width ? text.Substring(0, width - 1) + "…" : text.PadRight(width);
            }
        }
    }



//            StreamReader sr = null;
//            try
//            {
//                //read line by line
//                sr = new StreamReader("test.txt");
//                string name;
//                while (!sr.EndOfStream)//put in a loop to avoid duplication
//                {
//                    name= sr.ReadLine();
//                    Console.WriteLine(name);//where the current pointer is there that name is returned and to call many names, repeat the lines again and again

//                }

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {
//                sr.Close();
//            }
//        }

//        private static void ReadAll()
//        {
//            StreamReader sr = null;
//            try
//            {
//                sr = new StreamReader("test.txt");
//                string allNames = sr.ReadToEnd();
//                Console.WriteLine(allNames);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {
//                sr.Close();
//            }
//        }

//        private static void Write()
//        {
//            Console.WriteLine("Enter your Name:");
//            string name = Console.ReadLine();

//            //store the name into file
//            StreamWriter sw = null;
//            try
//            {
//                sw = new StreamWriter("test.txt", true);//pipe between harddrive to application
//                sw.WriteLine(name);
//                //very necessary to close the pipe as the data may not be flushed out to the hardisk
//            }
//            catch (Exception ex) { Console.WriteLine(ex.Message); }
//            finally
//            {
//                sw.Close();
//            }
//        }
//    }
//}
