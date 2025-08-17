using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIO_Demo1.Exceptions
{
    public class UnableToSaveFile:ApplicationException
    {
        public UnableToSaveFile(string msg="", Exception innerException=null): base(msg) 
        {

        }
        
    }
}
