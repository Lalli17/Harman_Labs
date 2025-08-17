namespace OODemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BankAccount account = new BankAccount();
            //ManageAccount(account);
            //SavingsBankAccount account = new SavingsBankAccount();
            //ManageAccount(account);

            //SrSavingsBankAccount account = new SrSavingsBankAccount();
            //ManageAccount(account);

            Calculator calculator = new Calculator();
            calculator.Sum(1, 2);

            calculator.Sum(1, 2, 4);
            calculator.Sum(1, 2, 3, 4);

        }

        public static void ManageAccount(BankAccount acc)
        {
            acc.Deposit(1000);
            acc.Withdraw(500);
            Console.WriteLine($"Balance : {acc.Balance}");
            Console.WriteLine($"Interest Earned : {acc.CalculateInterestEarned()}");
        }
    }

    interface BankAccount
    {
        string AccNo { get; set; }
        int Balance { get; set; }

        void Deposit(int amount);
        //{
        //    Balance += amount;
        //}

        void Withdraw(int amount);
        //{
        //    Balance -= amount;
        //}

        double CalculateInterestEarned();
        //{
        //Console.WriteLine("Bank Account Interest");
        //return 0;
        //}

    }

    //class SavingsBankAccount : BankAccount
    //{


    //    public double CalculateInterestEarned()
    //    {
    //        Console.WriteLine("Savings Bank Account Interest");
    //        return Balance * 0.4;
    //    }
    //}

    //class SrSavingsBankAccount : BankAccount
    //{
    //    public override double CalculateInterestEarned()
    //    {
    //        Console.WriteLine("Sr. Savings Bank Account Interest");
    //        return Balance * 0.6;
    //    }
    //}



    class Calculator
    {
        //public int Sum(int a, int b)
        //{
        //    return a + b;
        //}
        //public int Sum(int a, int b, int c)
        //{
        //    return a + b + c;
        //}

        public int Sum(int a = 0, int b = 0, int c = 0, int d = 0)
        {
            return a + b + c + d;
        }
    }
}
