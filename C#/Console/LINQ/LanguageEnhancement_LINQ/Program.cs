namespace LanguageEnhancement_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            //1. Local variable type Interference
            //no need of datatype as the compiler can infer it since it has the initial value
           // var data = 10;
           // var str = "hello";
           // var isDone = true;

           //var keyValuePairs= new Dictionary<int, List<String>>();

           // var p = new Person();
           // for (var i = 0; i < data; i++)
           // {

           // }

            //2. object Initialization Syntax

            var p = new Person();
            p.Id = 1;
            p.Name = "Test";
            p.Age = 30;


            var p2=new Person(111,"Name2",30);
        }
    }

    class Person
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        //add constructor

        public Person() 
        {

        } 
        //if parametrized constructor then add default constructor

        public Person(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }
        //constructor overloading
        public Person(int id)
        {
            this.Id=id;
        }


    }
}
