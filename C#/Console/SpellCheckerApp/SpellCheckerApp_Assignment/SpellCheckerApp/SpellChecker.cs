namespace SpellCheckerApp_Assignment.SpellCheckerApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SpellChecker
    {
        private readonly LevenshteinDistance _levenshtein;
        private readonly List<string> _dictionary;

        public SpellChecker(LevenshteinDistance levenshtein, List<string> dictionary)
        {
            _levenshtein = levenshtein;
            _dictionary = dictionary;
        }

        public List<string> Check(string word)
        {
            return _dictionary
                .Select(dictWord => new { Word = dictWord, Distance = _levenshtein.CalculateDistance(word, dictWord) })
                .OrderBy(x => x.Distance)
                .ThenBy(x => x.Word)
                .Take(10)
                .Select(x => x.Word)
                .ToList();
        }
    }
} 