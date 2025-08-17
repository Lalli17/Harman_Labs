namespace SpellCheckerApp_Assignment.SpellCheckerApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class InputFileLoader
    {
        public List<string> Load(string inputFile)
        {
            try
            {
                string text = File.ReadAllText(inputFile);
                var words = Regex.Split(text, @"\W+");
                return new List<string>(words);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading input file: " + ex.Message);
                return new List<string>();
            }
        }
    }
} 