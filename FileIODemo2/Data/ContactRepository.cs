using FileIODemo2.Entities;
using FileIODemo2.Exceptions;

namespace FileIODemo2.Data
{
    /// <summary>
    /// Contact Repository provide contact CRUD Operations and stores the data in file
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        private readonly string fileName = "contacts.txt";


        /// <summary>
        /// Creates contact into file
        /// </summary>
        /// <param name="contact"></param>
        /// <exception cref="UnableToSaveFileException"></exception>
        public void Create(Contact contact)
        {
            // create sw


            /*
             * xvvxcv
             * xcvxcv
             * xcvxcv
             * */

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(fileName, true);
                string csvContact = $"{contact.Id},{contact.Name},{contact.Email},{contact.Mobile},{contact.Location},{contact.Gender}";
                sw.WriteLine(csvContact);
            }
            catch (Exception ex)
            {
                UnableToSaveFileException fileException = new UnableToSaveFileException(ex.Message, ex);
                throw fileException;
            }
            finally { sw.Close(); }
            // serialize the contact into CSV format
            // write into sw
            // close sw
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, Contact contact)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            StreamReader sr = null;
            List<Contact> contacts = new List<Contact>();
            try
            {
                sr = new StreamReader(fileName);

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
            //catch (Exception)
            //{

            //    throw;
            //}
            finally { sr?.Close(); }
            return contacts;

        }

        public Contact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Contact GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
