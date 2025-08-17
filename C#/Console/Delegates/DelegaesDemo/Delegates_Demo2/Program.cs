using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Delegates_Demo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //client developer 1

            //ProcessManager.ShowProcessList(delegate
            // {
            //    return true;
            //  }
            //);//anonymous delegate
            ProcessManager.ShowProcessList(_ => true);


            //client developer 2
            //ProcessManager.ShowProcessList("S");//new requirement new code
            //FilterDelegate filter = new FilterDelegate(FilterByName);
            //ProcessManager.ShowProcessList(filter);
            // ProcessManager.ShowProcessList(delegate (Process p) //we shd passs the parameter list also
            // {
            //   return p.ProcessName.StartsWith("S");
            // }
            //);


            //client 3 more than 100mb of memory

            // ProcessManager.ShowProcessList(FilterBySize);


            ProcessManager.ShowProcessList(delegate (Process p) //we shd passs the parameter list also
            {
                return p.WorkingSet >= 500 * 1024 * 1024;
            });

            //lambda statement
            ProcessManager.ShowProcessList((Process p)=> //we shd passs the parameter list also
                {
                    return p.WorkingSet >= 500 * 1024 * 1024;
                });

            //Lambda Expression
            //light weight expression
            //single statement
            //no keywords
            //no symbols

            ProcessManager.ShowProcessList((Process p) =>

               p.WorkingSet >= 500 * 1024 * 1024 
            );

            ProcessManager.ShowProcessList(p => p.WorkingSet >= 500 * 1024 * 1024);//return true or false

        }




        public static bool NoFilter(Process p)
        {
            return true;
        }
        public static bool FilterByName(Process p)
        {
            return p.ProcessName.StartsWith("S");
        }
        public static bool FilterBySize(Process p)
        {
            return p.WorkingSet >= 500 * 1024 * 1024;
        }

    }


    //backend developer
    public delegate bool FilterDelegate(Process p);
    public class ProcessManager
    {
        //public static void ShowProcessList()
        //{
        //  foreach (Process p in Process.GetProcesses())
        //    {
        //        Console.WriteLine(p.ProcessName);
        //    }
        //}
        public static void ShowProcessList(FilterDelegate filter)
        {
            foreach (Process p in Process.GetProcesses())
            {
                if (filter(p))
                    Console.WriteLine(p.ProcessName);
            }
        }

        //public static void ShowProcessList(long size)
        //{
        //    foreach (Process p in Process.GetProcesses())
        //    {
        //        if (p.WorkingSet64>=size)
        //            Console.WriteLine(p.ProcessName);
        //    }
        //}
    }
}


