using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.TestProject1
{
    public class NegativeIInputException : ApplicationException
    {
        public NegativeIInputException(string msg = null, Exception inner = null) : base(msg, inner)
        {

        }
    }
}
