using System.Xml.Linq;

namespace LinqToXMLDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var xml = XDocument.Load("XMLFile1.xml");

            // get all book titles and authors
            // SQL: select title, author from books

            //var titles = from t in xml.Descendants("title")
            //             select t.Value;

            var books = from bk in xml.Descendants("book")
                        select new
                        {
                            Title = bk.Element("title").Value,
                            Author = bk.Element("author").Value
                        };

            foreach (var bk in books) { Console.WriteLine(bk.Title + " " + bk.Author); }
        }
    }

    //class TitleAuthor
    //{
    //    public string Title { get; set; }
    //    public string Author { get; set; }
    //}
}
