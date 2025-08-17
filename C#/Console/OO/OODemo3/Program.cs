namespace OODemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // BankAccount acc1 = new BankAccount();
            //deposit and withdraw shd modify the balance therefore remove the set block by making it private


            //acc1.Deposit(1000);
            //acc1.Withdraw(500);
            //Console.WriteLine($"Balance :{acc1.Balance}");
            //Console.WriteLine($"Interest Earned:{acc1.CalculateInterestEarned()}");

            //SavingsBankAccount savings = new SavingsBankAccount();
            //savings.Deposit(1000);
            //Console.WriteLine($"Savings Balance :{savings.Balance}");
            //Console.WriteLine($"Interest Earned for Savings BankAccount:{savings.CalculateInterestEarned()}");

            //SrSavingsBankAccount srSavings = new SrSavingsBankAccount();
            //srSavings.Deposit(1000);
            //Console.WriteLine($"Sr Savings Balance :{srSavings.Balance}");
            //Console.WriteLine($"Interest Earned for SrSavings Account:{srSavings.CalculateInterestEarned()}");
            
            BankAccount acc1=new BankAccount();
            ManageAccount(acc1 );

            SavingsBankAccount acc2 = new SavingsBankAccount();
            ManageAccount(acc2);

            SrSavingsBankAccount acc3 = new SrSavingsBankAccount(); 
            ManageAccount(acc3 );

            Calculator calculator = new Calculator();
            calculator.Sum(1, 2);
            calculator.Sum(3, 4 , 5);
        }

        public static void ManageAccount(BankAccount acc)
        {
            acc.Deposit(1000);
            acc.Withdraw(500);
            Console.WriteLine($"Balance :{acc.Balance}");
            Console.WriteLine($"Interest Earned:{acc.CalculateInterestEarned()}");//static binding bcs BankAccount acc is created so interest is 0 by defaullt static binding happens 
        }
    }

    //inheritancce 

    class BankAccount // use sealed to stop inheriting or overriding
    {
        public string AccNo { get; set; }
        public int Balance { get; private set; }//state
        public void Deposit(int amount)//behavior
        {
            Balance += amount;
        }

        public void Withdraw(int amount)
        {
            Balance -= amount;
        }
        //no interest to the regular banck account
        public virtual double CalculateInterestEarned()//not virtual method and not polymorphic
        {
            Console.WriteLine("Bank Account");
            return 0;
        }// any method to be modified by the derieved clas mark it as virtual

    }
    //create a savings account and senior citizen acc and each shd inherit the same properties of base class called bankacc

    class SavingsBankAccount : BankAccount
    {
        public override double CalculateInterestEarned()
        {
            Console.WriteLine("Savings Bankaccount");
            return Balance*0.4;
        }//defaulty this method will be inherited so the base class will hide this method 
    }

    class SrSavingsBankAccount : BankAccount
    {
        public override double CalculateInterestEarned()
        {
            Console.WriteLine("SrSavings Bankaccount");
            return Balance*0.6;
        }
    }

    class Calculator//method overloading - static polymorphism
    {
        //public int Sum(int a, int b)
        //{
        //    return a + b;
        //}

        //public int Sum(int a, int b,int c)
        //{
        //    return a + b + c ;
        //}
        // to avaoid multiple methods give default parameters

        public int Sum(int a=0, int b=0,int c=0,int d=0)
        {
            return a + b + c + d;
        }
    }
}
