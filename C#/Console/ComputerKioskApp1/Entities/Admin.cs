namespace ComputerKioskApp.Entities
{
    public class Admin
    {
        public string AdminId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Admin(string id, string password, string name, int age, string gender)
        {
            AdminId = id;
            Password = password;
            Name = name;
            Age = age;
            Gender = gender;
        }
    }
}
