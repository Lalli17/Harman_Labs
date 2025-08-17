namespace SpellCheckerApp_Assignment.SpellCheckerApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class DictionaryFileLoader
    {
        public List<string> Load(string dictionaryFile)
        {
            try
            {
                return new List<string>(File.ReadAllLines(dictionaryFile));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading dictionary: " + ex.Message);
                return new List<string>();
            }
        }
    }
} 