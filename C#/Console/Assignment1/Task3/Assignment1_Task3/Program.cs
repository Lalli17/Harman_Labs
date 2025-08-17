namespace Assignment1_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Students exam score and their grades
            int marks;
            Console.WriteLine("enter marks max being 100");
            marks=int.Parse(Console.ReadLine());
            if (marks >= 90)
                Console.WriteLine("Grade : A");
            else if (marks >= 80 && marks < 90)
                Console.WriteLine("Grade : B");
            else if (marks >= 70 && marks < 80)
                Console.WriteLine("Grade : C");
            else if (marks >= 60 && marks < 70)
                Console.WriteLine("Grade : D");
            else
                Console.WriteLine("Grade : F");
        }
    }
}
