using System.Xml;
using System.Xml.Linq;

namespace LinqDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // List<string> words = new List<string>() {"one","two","three","four","five","six" };
            //get all short words , they all are in memory objects 

            var words = new XDocument.Load("XMLFile1.xml"); ;


            var shortWords = from w in words.Descendents("word")
                             where w.Value.Length <=3
                             select w.Value;

            foreach (var item in shortWords) 
            {
                Console.WriteLine(item);
            }
        }
    }
}
