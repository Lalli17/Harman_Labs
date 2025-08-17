namespace Async_Await
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("getting large data");
            //string[] data=GetData();
            Task<string[]> data = GetDataAsync();

            string[] result = data.Result;

            Console.WriteLine("got ");
            foreach (var s in result)
            {
                Console.WriteLine(s); 
            }
        }

        static string[] GetData()
        {
           return File.ReadAllLines("TextFile1.txt");
        
        }
        static async Task<string[]> GetDataAsync()
        {
            return await File.ReadAllLinesAsync("TextFile1.txt");

        }

    }
}
