using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.TestProject1
{
    public class NonEvenInputException :ApplicationException
    {
        public NonEvenInputException(string msg="",Exception inner =null):base(msg,inner)  
        { }
    }
}
