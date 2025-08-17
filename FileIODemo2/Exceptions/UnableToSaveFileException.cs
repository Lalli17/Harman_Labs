namespace FileIODemo2.Exceptions
{
    public class UnableToSaveFileException : ApplicationException
    {
        public UnableToSaveFileException(string msg = "", Exception innerException = null) : base(msg)
        {

        }
    }
}
