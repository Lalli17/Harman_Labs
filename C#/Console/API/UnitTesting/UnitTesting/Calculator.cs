using Calculator.TestProject1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class Calculator : ICalculator
    {

        //BL COdE
        //rules: find sum for only +ve numbers
            public static int FindSum(int fno, int sno)
            {
               
            if (fno < 0 && sno < 0)
            {
                throw new NegativeInputException("provide only +ve input");
            }

            if (fno == 0 || sno == 0)
            {
                throw new ZeroInputException("provide only non zero input");
            }
            if (fno % 2 != 0 || sno % 2 != 0)
            {
                throw NonEvenInputException("provide only even number input");
            }
            return fno + sno;
            }
        }
    }

