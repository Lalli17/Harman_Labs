namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 4: Assign method to delegate
            StringModifier modifier = StringOperations.Uppercase;

            // Step 5: Call the delegate
            string result = modifier("Hello World!");
            Console.WriteLine("Uppercase: " + result);

            // Change to Lowercase
            modifier = StringOperations.Lowercase;
            Console.WriteLine("Lowercase: " + modifier("Hello World!"));

            // Change to Reverse
            modifier = StringOperations.Reverse;
            Console.WriteLine("Reverse: " + modifier("Hello World!"));

            // ----- BONUS: Delegate Chaining -----
            // Note: Chaining works only when return value is not used (void).
            // To simulate chaining, we'll call methods manually in order.
            string input = "Hello World!";
            string upper = StringOperations.Uppercase(input);
            string reversed = StringOperations.Reverse(upper);
            Console.WriteLine("Uppercase + Reverse: " + reversed);
        }
    }

    public delegate string StringModifier(string input);


    public class StringOperations
    {
        public static string Uppercase(string input)
        {
            return input.ToUpper();
        }

        public static string Lowercase(string input)
        {
            return input.ToLower();
        }

        public static string Reverse(string input)
        {
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
