namespace FileIODemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read line by line
            // Read all names
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("test.txt");
                //string allNames = sr.ReadToEnd();
                string name;
                while (!sr.EndOfStream)
                {
                    name = sr.ReadLine();
                    Console.WriteLine(name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { sr.Close(); }

        }

        private static void ReadAll()
        {
            // Read all names
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("test.txt");
                string allNames = sr.ReadToEnd();
                Console.WriteLine(allNames);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally { sr.Close(); }
        }

        private static void Write()
        {
            Console.WriteLine("Enter your Name:");
            string name = Console.ReadLine();

            // store the name into file
            StreamWriter sw = null;
            try
            {

                sw = new StreamWriter("test.txt", true);
                sw.WriteLine(name);
                //sdfdsfsdf
                //sdfsdf
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                sw.Close();
            }
        }
    }
}
