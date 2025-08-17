namespace SuperCalculator.Business
{
    public class NegetiveInputException : ApplicationException
    {
        public NegetiveInputException(string msg = null, Exception inner = null) : base(msg, inner)
        {

        }
    }
}
