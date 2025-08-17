using System;

namespace Kiosk_App
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }

        public Admin(int id, string name, int age, string gender, string password)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            Password = password;
        }

        public bool Authenticate(string password)
        {
            return Password == password;
        }
    }
} 