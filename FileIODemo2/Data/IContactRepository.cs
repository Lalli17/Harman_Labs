using FileIODemo2.Entities;

namespace FileIODemo2.Data
{
    public interface IContactRepository
    {
        void Create(Contact contact);
        List<Contact> GetAll();
        Contact GetById(int id);
        Contact GetByName(string name);
        void Delete(int id);
        void Edit(int id, Contact contact);
    }
}
