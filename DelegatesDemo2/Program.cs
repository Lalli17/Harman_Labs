using System.Diagnostics;

namespace DelegatesDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // client developer 1
            //ProcessManager.ShowProcessList(NoFilter);

            ProcessManager.ShowProcessList(delegate
                {
                    return true;
                }
                );

            ProcessManager.ShowProcessList(_ => true);

            // client 2
            //FilterDelegate filter = new FilterDelegate(FilterByName);

            Predicate<Process> filter = new Predicate<Process>(FilterBySize);
            ProcessManager.ShowProcessList(filter);

            //ProcessManager.ShowProcessList(delegate (Process p)
            //{
            //    return p.ProcessName.StartsWith("S");
            //});

            // client 3
            //ProcessManager.ShowProcessList(FilterBySize);

            // Anonymous Delegate

            //ProcessManager.ShowProcessList(delegate (Process p)
            //    {
            //        return p.WorkingSet >= 100 * 1024 * 1024;
            //    });

            // Lambda Statement

            ProcessManager.ShowProcessList((Process p) =>
            {
                return p.WorkingSet >= 100 * 1024 * 1024;
            });

            // Lambda Expression
            // single statement
            // no keywords 
            // no symbols
            //
            ProcessManager.ShowProcessList((Process p) =>

                 p.WorkingSet >= 100 * 1024 * 1024
            );

            ProcessManager.ShowProcessList(x => x.WorkingSet >= 100 * 1024 * 1024);

        }


        // Lambda Statements
        // Lambda Expressions - Light weight syntax for anonymous delegates


        // client 1
        public static bool NoFilter(Process p)
        {
            return true;
        }

        // client 2
        //public static bool FilterByName(Process p)
        //{
        //    return p.ProcessName.StartsWith("S");
        //}

        // client 3
        public static bool FilterBySize(Process p)
        {
            return p.WorkingSet >= 100 * 1024 * 1024;
        }
    }




    // backend developer



    //public delegate bool FilterDelegate(Process p);
    public class ProcessManager
    {
        //public static void ShowProcessList()
        //{
        //    foreach (Process p in Process.GetProcesses())
        //    {
        //        Console.WriteLine(p.ProcessName);
        //    }
        //}

        public static void ShowProcessList(Predicate<Process> filter)
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
        //        if (p.WorkingSet64 >= size)
        //            Console.WriteLine(p.ProcessName);
        //    }
        //}
    }
}
