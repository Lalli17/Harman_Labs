namespace SuperCalculator.Business
{
    public class ZeroInputException : ApplicationException
    {
        public ZeroInputException(string msg = "", Exception inner = null) : base(msg, inner)
        {

        }
    }
}
