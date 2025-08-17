namespace SpellCheckApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    public class SpellCheckerApp
    {
        public string InputFile { get; set; }
        public string OutputFile { get; set; }

        public void StartSpellCheck(string inputFile, string outputFile, CancellationToken token)
        {
            InputFileLoader inputLoader = new InputFileLoader();
            DictionaryFileLoader dictLoader = new DictionaryFileLoader();

            var dictionary = dictLoader.Load("dictionary.txt");
            var spellChecker = new SpellChecker(dictionary);
            var words = inputLoader.Load(inputFile);

            List<string> outputLines = new();

            foreach (var word in words)
            {
                if (token.IsCancellationRequested) break;

                if (!dictionary.Contains(word, StringComparer.OrdinalIgnoreCase))
                {
                    var suggestions = spellChecker.Check(word, token);
                    string line = word + "\t" + string.Join("\t", suggestions);
                    outputLines.Add(line);
                }
            }

            if (!token.IsCancellationRequested)
            {
                File.WriteAllLines(outputFile, outputLines);
                Console.WriteLine($"Output written to {outputFile}");
            }
            else
            {
                Console.WriteLine("Spell checking was cancelled.");
            }
        }
    }
}
