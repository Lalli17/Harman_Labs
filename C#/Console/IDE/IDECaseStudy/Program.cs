namespace IDECaseStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDE ide = new IDE();
            LangJava java = new LangJava();
            LangCSharp cs = new LangCSharp();
            LangC c = new LangC();

            ide.Languages.Add(java);
            ide.Languages.Add(cs);
            ide.Languages.Add(c);

            ide.DoWork();
        }
    }


    interface ILanguage
    {
        string GetName();
        string GetUnit();
        string GetParadigm();

    }

    class IDE
    {
        //public LangJava Java { get; set; }
        //public LangCSharp CS { get; set; }
        //public LangC C { get; set; }

        public List<ILanguage> Languages = new List<ILanguage>();

        public void DoWork()
        {

            foreach (ILanguage lang in Languages)
            {
                Console.WriteLine(lang.GetName());
                Console.WriteLine(lang.GetUnit());
                Console.WriteLine(lang.GetParadigm());
                Console.WriteLine("----------------------");//similarly for all
            }
        }
    }


    class OOLanguage
    {
        public string GetUnit()
        {
            return "Class";
        }
        public string GetParadigm()
        {
            return "Object oriented";
        }
    }


    class LangJava : OOLanguage, ILanguage
    {
        public string GetName()
        {
            return "Java Language";
        }
       
    }
    class LangCSharp :OOLanguage, ILanguage 
    {
        public string GetName()
        {
            return "C# Language";
        }
      
    }

    class LangC : ILanguage 
    {
        public string GetName()
        {
            return "C Language";
        }
        public string GetUnit()
        {
            return "Function";
        }
        public string GetParadigm()
        {
            return "Procedure oriented";
        }
    }//new feature new code


}
