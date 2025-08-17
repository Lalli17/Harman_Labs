namespace Task3_Queue_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Create and populate Queue and Stack
            Queue<string> nameQueue = new Queue<string>();
            Stack<string> nameStack = new Stack<string>();

            nameQueue.Enqueue("Alice");
            nameQueue.Enqueue("Bob");
            nameQueue.Enqueue("Charlie");
            nameQueue.Enqueue("Diana");
            nameQueue.Enqueue("Ethan");

            nameStack.Push("Alice");
            nameStack.Push("Bob");
            nameStack.Push("Charlie");
            nameStack.Push("Diana");
            nameStack.Push("Ethan");

            Console.WriteLine("----Oueue----");
            foreach (string item in nameQueue)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("----Stack----");
            foreach (string items in nameStack)
            {
                Console.WriteLine(items);
            }
            Console.WriteLine();


            // Step 2: Demonstrate Queue operations
            Console.WriteLine("=== Queue Operations ===");
            Console.WriteLine("Dequeued from Queue: " + DequeueItem(nameQueue));
            EnqueueItem(nameQueue, "Frank");

            // Step 3: Demonstrate Stack operations
            Console.WriteLine("\n=== Stack Operations ===");
            Console.WriteLine("Popped from Stack: " + PopItem(nameStack));
            PushItem(nameStack, "Frank");

            // Step 4: Iterate without removing elements
            Console.WriteLine("\nQueue Contents (without removing):");
            IterateQueue(nameQueue);

            Console.WriteLine("\nStack Contents (without removing):");
            IterateStack(nameStack);
        }

        // Queue Methods
        static void EnqueueItem(Queue<string> queue, string item)
        {
            queue.Enqueue(item);
            Console.WriteLine($"Enqueued '{item}' to the Queue.");
        }

        static string DequeueItem(Queue<string> queue)
        {
            return queue.Count > 0 ? queue.Dequeue() : "Queue is empty.";
        }

        static void IterateQueue(Queue<string> queue)
        {
            foreach (string item in queue)
            {
                Console.WriteLine(item);
            }
        }

        // Stack Methods
        static void PushItem(Stack<string> stack, string item)
        {
            stack.Push(item);
            Console.WriteLine($"Pushed '{item}' to the Stack.");
        }

        static string PopItem(Stack<string> stack)
        {
            return stack.Count > 0 ? stack.Pop() : "Stack is empty.";
        }

        static void IterateStack(Stack<string> stack)
        {
            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
