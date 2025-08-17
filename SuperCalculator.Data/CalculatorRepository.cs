namespace SuperCalculator.Data
{
    public class CalculatorRepository : ICalculatorRepository
    {
        public void Save(string result)
        {
            string file = "a:\\result.txt";
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine(result);
            }
        }
    }
}
