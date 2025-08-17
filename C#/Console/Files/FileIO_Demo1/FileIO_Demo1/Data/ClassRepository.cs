using FileIO_Demo1.Entity;
using FileIO_Demo1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO_Demo1.Data
{
    /// <summary>
    /// Contact Repository provide contact CRUD operations and stores the data in file
    /// </summary>
    public class ClassRepository : IContactRepository
    {
        /// <summary>
        /// Create contact into file
        /// <param name="contact"></param>
        /// </summary>
        private readonly string fileName = "contacts.txt";
        public void Create(Contact contact)
        {
            //create sw
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(fileName, true);
                string csvContact = $"{contact.Id},{contact.Name},{contact.Email},{contact.Mobile},{contact.Location},{contact.Gender}";
                sw.WriteLine(csvContact);
            }
            catch (Exception ex)
            {
                UnableToSaveFile fileException = new UnableToSaveFile(ex.Message, ex);
                //creating a custom exception and then wrapping the exception into original exception

                throw fileException;
            }
            finally
            {
                sw.Close();
            }            
            //serialize the contact into csv format
            //write into sw
            //close sw
        }

        StreamReader sr = null;
        public List<Contact> contacts;

        public List<Contact> GetAll()
        {
           
            try
            {
                sr = new StreamReader(fileName);
                List<Contact> contacts = new List<Contact>();
                while (!sr.EndOfStream)
                {
                    Contact contact = new Contact();
                    string contactStr = sr.ReadLine();
                    string[] contactArray = contactStr.Split(',');
                    contact.Id = contactArray[0];
                    contact.Name = contactArray[1];
                    contact.Email = contactArray[2];
                    contact.Mobile = contactArray[3];
                    contact.Location = contactArray[4];
                    contact.Gender = contactArray[5];
                    contacts.Add(contact);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
               sr?.Close();
            }
            return contacts;
           
        }

        public Contact GetById(string id)
        {
            return contacts.FirstOrDefault(c => c.Id.Equals(id));
        }

        public void Edit(Contact updatedContact)
        {
            var existingContact = GetById(updatedContact.Id);
            if (existingContact != null)
            {
                existingContact.Name = updatedContact.Name;
                existingContact.Email = updatedContact.Email;
                existingContact.Mobile = updatedContact.Mobile;
                existingContact.Location = updatedContact.Location;
                existingContact.Gender = updatedContact.Gender;
            }
        }


        public void Delete(string id)
        {
         var contact=GetById(id);
            if (contact != null)
            {
                contacts.Remove(contact);
            }
        }

        List<Contact> IContactRepository.GetByName(string name)
        {
            return contacts 
                .Where(c=> c.Name.Equals(name,StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

     
    }
}
