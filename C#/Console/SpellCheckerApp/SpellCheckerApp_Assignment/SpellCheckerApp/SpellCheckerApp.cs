namespace SpellCheckerApp_Assignment.SpellCheckerApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class SpellCheckerApp
    {
        public string InputFile { get; set; }
        public string OutputFile { get; set; }
        private CancellationTokenSource _cts;

        public void StartSpellCheck(string inputFile, string outputFile)
        {
            InputFile = inputFile;
            OutputFile = outputFile;
            _cts = new CancellationTokenSource();

            try
            {
                var dictionaryLoader = new DictionaryFileLoader();
                var inputLoader = new InputFileLoader();
                var levenshtein = new LevenshteinDistance();

                var dictionary = dictionaryLoader.Load("dictionary.txt"); // Path to your dictionary file
                var inputWords = inputLoader.Load(InputFile);

                var spellChecker = new SpellChecker(levenshtein, dictionary);

                var misspelledWords = inputWords
                    .Where(word => !string.IsNullOrWhiteSpace(word) && !dictionary.Contains(word, StringComparer.OrdinalIgnoreCase))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();

                var results = new Dictionary<string, List<string>>();
                var tasks = new List<Task>();

                object lockObj = new object();

                foreach (var word in misspelledWords)
                {
                    var localWord = word;
                    var task = Task.Run(() =>
                    {
                        if (_cts.Token.IsCancellationRequested) return;
                        var suggestions = spellChecker.Check(localWord);
                        lock (lockObj)
                        {
                            results[localWord] = suggestions;
                        }
                    }, _cts.Token);
                    tasks.Add(task);
                }

                Console.WriteLine("Press 'q' to cancel spell checking...");

                // Monitor for cancellation
                Task.Run(() =>
                {
                    if (Console.ReadKey(true).KeyChar == 'q')
                    {
                        _cts.Cancel();
                    }
                });

                Task.WaitAll(tasks.ToArray());

                // Write output
                using (var writer = new StreamWriter(OutputFile))
                {
                    foreach (var kvp in results)
                    {
                        writer.WriteLine(kvp.Key);
                        foreach (var suggestion in kvp.Value)
                        {
                            writer.WriteLine("    " + suggestion);
                        }
                        writer.WriteLine();
                    }
                }

                Console.WriteLine("Spell checking completed. Output written to " + OutputFile);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Spell checking cancelled by user.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
} 