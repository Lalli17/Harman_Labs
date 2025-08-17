namespace LanguageEnhancementsForLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Local Variable Type Inference - var

            //var data = 10;


            //var str = "hello";
            //var isDone = true;
            //var keyValuePairs = new Dictionary<int, List<string>>();

            //var p = new Person();
            //for (var i = 0; i < data; i++) { }

            //2. Object Initialization Syntax
            //var p = new Person();
            //p.Id = 1;
            //p.Name = "Test";
            //p.Age = 30;

            //var p2 = new Person(111, "Name2", 30);
            //var p3 = new Person(222);
            //var p4 = new Person(age: 34);
            //var p5 = new Person(name: "name200");

            //var p6 = new { Id = 111 }; // Object Initialization Syntax
            //var p7 = new { Id = 222, Name = "Name1" };
            //var p8 = new { Id = 245, Name = "name200", Age = 26 };


            //var person = new { Id = 111, Name = "Rama", Age = 30 };

            //var item = new { Id = 123, Name = "I Phone", Price = 90000 };

            ////item.Price = 0;
            //Console.WriteLine(item.Name);

            // Anonymous Types

            // Extension Methods

            string data = "Some confidential data";
            data = data.ToUpper();

            //GoodUtils goodUtils = new GoodUtils();
            data = GoodUtils.Encrypt(data);

            data = data.Encrypt();
            data.Encrypt();
            int x = 10;
            x.Encrypt();
            Program p = new Program();
            p.Encrypt();

        }
    }

    //class MyString : String
    //{

    //}

    static public class GoodUtils
    {
        public static string Encrypt(this object data)
        {
            return "@#$@#$#EFDFEWR@#%R@$TTRETergergdff23524%@#%@#%";
        }
    }

    class Anoy4523534545345
    {

    }

    //class Person
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //    //public Person()
    //    //{

    //    //}

    //    //public Person(int id)
    //    //{
    //    //    this.Id = id;
    //    //}

    //    //public Person(int id, string name) : this(id)
    //    //{
    //    //    //this.Id = id;
    //    //    this.Name = name;
    //    //}



    //    //public Person(int id, string name, int age) : this(id, name)
    //    //{
    //    //    //this.Id = id;
    //    //    //this.Name = name;
    //    //    this.Age = age;
    //    //}

    //    //public Person(int id = 0, string name = "", int age = 0)
    //    //{
    //    //    this.Id = id;
    //    //    this.Name = name;
    //    //    this.Age = age;
    //    //}
    //}
}
