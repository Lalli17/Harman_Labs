using SuperCalculator.Data;

namespace SuperCalculator.Business
{
    public class Calculator : ICalculator // BLL SRP
    {
        ICalculatorRepository repo = null; //new CalculatorRepository(); // DIP

        public Calculator()
        {
            repo = new CalculatorRepository(); // by default
        }

        public Calculator(ICalculatorRepository repo)
        {
            this.repo = repo;
        }

        public int FindSum(int fno, int sno) // BL Code SRP
        {
            // BL Code
            // Rules: find sum for only +ve, non Zero and Even numbers only otherwise throw exp
            // Req: on success result...save the result

            if (fno < 0 && sno < 0)
            {
                throw new NegetiveInputException("Provide only +ve input");
            }

            if (fno == 0 || sno == 0)
            {
                throw new ZeroInputException("Provide only non zero input");
            }

            if (fno % 2 != 0 || sno % 2 != 0)
            {
                throw new NonEvenInputException("Provide only even number input");
            }

            // save the result into file system
            // write code to save into file

            repo.Save($"{fno} + {sno} = {fno + sno}");

            return fno + sno;
        }
    }
} // BLL