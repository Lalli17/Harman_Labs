using Moq;
using SuperCalculator.Business;
using SuperCalculator.Data;

namespace SuperCalculator.TestProject
{

    //class MockCalculatorRepository : ICalculatorRepository
    //{
    //    public void Save(string result)
    //    {
    //        //
    //    }
    //}


    [TestClass]
    public sealed class CalculatorTest
    {
        Calculator target = null;
        Moq.Mock<ICalculatorRepository> mock = null;

        [TestInitialize]
        public void Init()
        {
            // execute before every test method

            mock = new Moq.Mock<ICalculatorRepository>();
            mock.Setup(m => m.Save(""));

            target = new Calculator(mock.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // execures after every test method
            target = null;
        }


        [TestMethod]
        public void SumTest_WithValidInput_ShouldReturnValidResult() // +ve Test case
        {
            // no conditional stmts
            // no looping stmts
            // no exception blocks

            // AAA 
            // A - Arrage
            //Calculator target = new Calculator();
            int fno = 10;
            int sno = 20;
            int actual = 0;
            int expected = 30;
            // A - Act
            actual = target.FindSum(fno, sno);
            // A - Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(NegetiveInputException))]
        public void SumTest_WithNegativeInput_ShouldThrowsExp() // -ve Test case
        {
            // no conditional stmts
            // no looping stmts
            // no exception blocks

            // AAA 
            // A - Arrage
            //Calculator target = new Calculator();
            //int fno = 10;
            //int sno = 20;
            //int actual = 0;
            //int expected = 30;
            // A - Act
            int actual = target.FindSum(-1, -1);
            // A - Assert
            // Assert.AreEqual(-1 + -1, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(ZeroInputException))]
        public void SumTest_WithZeroInput_ShouldThrowExp()
        {
            //Calculator target = new Calculator();
            int actual = target.FindSum(0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(NonEvenInputException))]
        public void SumTest_WithNonEvenInput_ShouldThrowExp()
        {
            target.FindSum(3, 7);
        }

        [TestMethod]
        public void SumTest_UponSuccess_ShouldCallSave()
        {
            target.FindSum(2, 4);
            mock.Verify(m => m.Save("2 + 4 = 6"), Times.AtLeastOnce);
        }
    }
}
