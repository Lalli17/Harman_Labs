using System;
using SpellCheckerApp_Assignment.SpellCheckerApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter input file path:");
        string inputFile = Console.ReadLine();

        Console.WriteLine("Enter output file path:");
        string outputFile = Console.ReadLine();

        var app = new SpellCheckerApp();
        app.StartSpellCheck(inputFile, outputFile);
    }
}
