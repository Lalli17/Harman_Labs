namespace SuperCalculator.Business
{
    public class NonEvenInputException : ApplicationException
    {
        public NonEvenInputException(string msg = "", Exception inner = null) : base(msg, inner)
        {

        }
    }
}
