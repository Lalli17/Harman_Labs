namespace DelegatesDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Direct method invocation
            //Greeting("Good morning!");
            // Delegate d = new Delegate();
            // Step 2: Instatiation and initialization
            //MyDelegate d = new MyDelegate(Greeting);
            MyDelegate d = null;
            Program p = new Program();
            d += p.Hi; // Subscription

            //d -= Greeting; // Unsubscribe

            d += Greeting; // Sub

            // d += SomeMethod;
            // Step 3: Invocation
            //d.Invoke("Good morning!");
            if (d != null)
            {
                d("Good morning again");
            }
        }

        public static void Greeting(string text)
        {
            Console.WriteLine($"Greeting: {text}");
        }

        public void Hi(string msg)
        {
            Console.WriteLine($"Hi: {msg}");
        }

        public static string SomeMethod(string str)
        {
            return str.ToUpper();
        }
    }

    //public class MyDelegate : Delegate
    //{

    //}

    public delegate void MyDelegate(string msg); // Step:1 - delegate declaration
    public delegate string MyDelegate1(string str);


    public interface IAccount
    {
        void Deposit(int amount);
    }

    public class SavingsAccount : IAccount
    {
        public void Deposit(int amount) { }
    }
}
