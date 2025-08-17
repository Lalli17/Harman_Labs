namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            stack.Push("string1");
            stack.Push("string2");
            stack.Push("string4");
            stack.Push("string5");

            
            Console.WriteLine("Contents of stack:");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }


            Stack<string> tempStack = new Stack<string>();

            
            while (stack.Count > 0)
            {
                string top = stack.Pop();
                if (top == "string4")
                {
                    // First push string4
                    tempStack.Push(top);
                    // Then push string3 before it
                    tempStack.Push("string3");
                    break;
                }
                else
                {
                    tempStack.Push(top);
                }
            }

           
            while (stack.Count > 0)
            {
                tempStack.Push(stack.Pop());
            }

            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }

            Console.WriteLine("\nStack after inserting 'string3' between 'string2' and 'string4':");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            // Step 4: Read only the topmost item without removing
            Console.WriteLine($"\nTopmost item (without removing): {stack.Peek()}");
        }
    }
}
