namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ClsPerson> list = new List<ClsPerson>();
            {
                list.Add(new ClsPerson("Alice"));
                list.Add(new ClsPerson("Bob"));
                list.Add(new ClsPerson("Charlie"));
                list.Add(new ClsPerson("Dev"));
            }
            ;
            Console.WriteLine("Traversing in a List:");
            Console.WriteLine();
            //for each loop
            Console.WriteLine("foreach loop");
            foreach(var person in list) 
                {
                    Console.WriteLine(person.Name);
                }
            Console.WriteLine();
            Console.WriteLine("for loop with index");
            for (int i = 0; i < list.Count; i++) 
                {
                    Console.WriteLine(list[i].Name);
                }
            Console.WriteLine();
            Console.WriteLine("While Loop");
            int index = 0;
            while (index < list.Count) 
            {
                Console.WriteLine(list[index].Name);
                index++;
            }
        }
    }

    class ClsPerson
    {
        public string Name { get; set; }
        public ClsPerson(string name) 
            {
                Name = name;

            }
    }
}
