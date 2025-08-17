using System.Xml.Linq;

namespace LinqDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> words = new List<string>() { "one", "two", "three", "four", "five", "six" };

            // get all short words

            //var shortWords = from w in words
            //                 where w.Length <= 3
            //                 select w;

            var words = XDocument.Load("XMLFile1.xml"); ;



            var shortWords = from w in words.Descendants("word")
                             where w.Value.Length <= 3
                             select w.Value;

            foreach (var item in shortWords)
            {
                Console.WriteLine(item);
            }

        }
    }
}
