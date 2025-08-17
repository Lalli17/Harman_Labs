using FileIO_Demo1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO_Demo1.Data
{
    public interface IContactRepository
    {
       void Create(Contact contact);
        List<Contact> GetAll();
        
        List<Contact> GetByName(string name);
        void Delete(string id);
        
        void Edit(Contact contact);
        Contact GetById(string id);
    }//implement this in a class
}
