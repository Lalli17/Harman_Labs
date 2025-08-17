using FileIODemo2.Entities;

namespace FileIODemo2.Data
{


    // install ef nuget packages
    // create ContactDbContext  class and map db and tables


    public class ContactEFRepository : IContactRepository
    {

        private ContactDbContext db = new ContactDbContext();
        public void Create(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
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
            throw new NotImplementedException();
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
