using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.TestProject1
{
    public class ZeroInputExceptin : ApplicationException
    {
        public ZeroInputExceptin(string msg="",Exception inner=null) : base(msg,inner)
        { }
    }
}
