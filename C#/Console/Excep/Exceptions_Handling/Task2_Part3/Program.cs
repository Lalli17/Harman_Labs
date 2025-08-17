namespace Task2_Part3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Using throw ===");
            try
            {
                CauseExceptionWithThrow();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught in Main (throw):");
                Console.WriteLine(ex);
            }

            Console.WriteLine("\n=== Using throw ex ===");
            try
            {
                CauseExceptionWithThrowEx();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught in Main (throw ex):");
                Console.WriteLine(ex);
            }
        }

        static void CauseExceptionWithThrow()
        {
            try
            {
                int x = 0;
                int result = 10 / x; // Causes DivideByZeroException
            }
            catch (Exception)
            {
                // Rethrow using 'throw' — preserves original stack trace
                throw;
            }
        }

        static void CauseExceptionWithThrowEx()
        {
            try
            {
                int x = 0;
                int result = 10 / x; // Causes DivideByZeroException
            }
            catch (Exception ex)
            {
                // Rethrow using 'throw ex' — resets stack trace
                throw ex;
            }
        }
    }
}
