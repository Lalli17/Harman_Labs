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

            //ide.Java = java;
            //ide.C = c;
            //ide.CS = cs;

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

        public List<ILanguage> Languages { get; set; } = new List<ILanguage>();

        public void DoWork()
        {
            foreach (ILanguage lang in Languages)
            {
                Console.WriteLine(lang.GetName());
                Console.WriteLine(lang.GetUnit());
                Console.WriteLine(lang.GetParadigm());
                Console.WriteLine("---------------------");
            }
            //Console.WriteLine(CS.GetName());
            //Console.WriteLine(CS.GetUnit());
            //Console.WriteLine(CS.GetParadigm());
            //Console.WriteLine("---------------------");

            //Console.WriteLine(C.GetName());
            //Console.WriteLine(C.GetUnit());
            //Console.WriteLine(C.GetParadigm());


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
            return "Object Oriented";
        }
    }

    class LangJava : OOLanguage, ILanguage
    {
        public string GetName()
        {
            return "Java Language";
        }


    }
    class LangCSharp : OOLanguage, ILanguage
    {
        public string GetName()
        {
            return "CSharp Language";
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
            return "Procedure Oriented";
        }
    }
}
