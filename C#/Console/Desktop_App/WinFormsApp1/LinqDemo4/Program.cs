using System.Net;
using System.Xml.Linq;

namespace LinqDemo4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var xml = XDocument.Load("XMLFile1.xml");
            //get all book titles

            //var titles=from t in xml.Descendants("title")
            //           select t.Value;

            var books = from bk in xml.Descendants("book")
                        select new 
                        {
                            Title = bk.Element("title").Value,
                            Author = bk.Element("author").Value
                        };

            foreach (var bk in books) {Console.WriteLine(bk.Title); }

        }
    }

    //class TitleAuthor
    //{
    //    public string Title { get; set; }
    //    public string Author { get; set; }
    //}
    //when more data use the anonymous content where there is no class name in the selct new
}
