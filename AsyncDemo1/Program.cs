namespace AsyncDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting large data");
            //string[] data = GetData();

            Task<string[]> data = GetDataAsync();


            //sdfsdfdf
            //sdfsdfsdf
            //sdfsdf
            //sdfsdfsdf
            //sdfsdfsdf

            Console.WriteLine("doing somethig.....");
            Console.WriteLine("doing somethig.....");
            Console.WriteLine("doing somethig.....");

            string[] result = data.Result;

            Console.WriteLine("I got the data");




            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }


        static string[] GetData()
        {
            return File.ReadAllLines("TextFile1.txt");
        }

        static async Task<string[]> GetDataAsync()
        {
            //return File.ReadAllLines("TextFile1.txt");

            return await File.ReadAllLinesAsync("TextFile1.txt");
        }
    }
}
