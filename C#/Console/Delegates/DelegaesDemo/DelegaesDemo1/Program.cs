namespace DelegaesDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //direct method invocaation
           // Greeting("Good morning");
            
            // Delegate d = new Delegate(); cannot be created so create a new class and then use the instance
            //step 2: Instantiation and initialization

           //can be done in other way also but shd allocate the memory
            //MyDelegate d = new MyDelegate(Greeting); // shd have a consructor that is must pass arguements and must pass a method address
                                                     //Greeting or main method address can be passed and just by the name of the method will give the references without parentheses
            MyDelegate d = null;

           

            Program p= new Program();

            d += p.Hi;//Subscription 
            //only hi is printed bcs its been replaced so add it
            d += Greeting;

            //  d -= Greeting;//unsubscribe 

            //Step 3: Invocation
            // d.Invoke("Good morning");

            if (d != null)
            {
                d("Good morning again");
            }
            
        }

        public static void Greeting(string text)//static method belonging to the same class
        {
            Console.WriteLine($"Greeting: {text}");
        }

        public void Hi(string msg)//instance method 
        {
            Console.WriteLine($"hi:{msg}");
        }

        public static string SomeMethod(string msg) //wrong return type or signature 
        {
            return msg.ToUpper();
        }

    }

    //public class MyDelegate:Delegate //invalid since abstract class or inheritance cannot be done
    public delegate void MyDelegate(string msg);//delegate declaration
    public delegate string MyDelegate1(string msg);


}
