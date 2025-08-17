namespace Calculator.TestProject1
{
    [TestClass]
    public sealed class CalculatorTest1
    {
        Calculator target = null;

        [TestInitialize]
        public void Init()
        {
            //execute before every test method
            target = new Calculator();
        }
        [TestCleanup]
        public void Cleanup()
        {
            //executes after every test method 

            target = null;
        }


        [TestMethod]
        [ExpectedException (typeof (NegativeInputException))]
        public void SumTest_WithValidInput_ShouldReturnValidResult() // test case
        {
            //no conditional stmts
            //no looping stmts
            //no exception blocks

            //AAA
            //A-arrange  creating a variable 
            //Calculator target = new Calculator();
            int fno = 10;
            int sno = 20;
            int actual = 0;
            int expected = 30;
            //A-Act
            actual = target.FindSum(fno, sno);
            //A-Assert

            Assert.AreEqual(expected, actual);

        }
    }
}
