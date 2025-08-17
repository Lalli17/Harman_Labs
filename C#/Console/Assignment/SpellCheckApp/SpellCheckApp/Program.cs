namespace SpellCheckApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
                var app = new SpellCheckerApp();
                string inputPath = "input.txt";
                string outputPath = "output.txt";

                CancellationTokenSource cts = new();

                Task spellCheckTask = Task.Run(() =>
                {
                    app.StartSpellCheck(inputPath, outputPath, cts.Token);
                });

                Console.WriteLine("Press 'Q' to cancel spell check...");
                while (!spellCheckTask.IsCompleted)
                {
                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q)
                    {
                        cts.Cancel();
                        break;
                    }
                }

                spellCheckTask.Wait();
                Console.WriteLine("Program completed.");
            }
        }
    }
