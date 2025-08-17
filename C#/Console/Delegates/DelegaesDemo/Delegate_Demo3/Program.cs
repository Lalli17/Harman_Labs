using System.Net.Mail;

namespace Delegate_Demo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Account account = new Account();//open account
            account.Alert += Notification.SendMsg;
            account.Alert += Notification.SendMail;

            account.Deposit(10000);//transaction
            //account.Alert("Your account has been creditd by 1000000000000000000000000000000000");

            Console.WriteLine(account.Balance);
            account.Withdraw(1000);
           Console.WriteLine(account.Balance);

        }
    }


    //backend dev team

    public delegate void AlertDelegate(string message);//custom delegate



    class Account //SRP OCP
    {
        public int Balance { get; private set; }
        public event AlertDelegate Alert = null; //new AlertDelegate(Notification.SendMail);
        
        //public void Subscribe(AlertDelegate alert) {  Alert = alert; }
        //public void Unsubscribe(AlertDelegate alert) { Alert = alert; } 
        
        
        
        
        public void Deposit(int amount) // SRP : method shd do onething at a time
        {
            Balance += amount;
            //write email sending code here
            //Notification.SendMail($"Your account has been credited {amount}");
            //Notification.SendMsg($"Your account has been credited {amount}");

            if (Alert != null)
            {

                Alert($"Your account has been credited {amount}");
            }
        }
        public void Withdraw(int amount)
        {
            Balance -= amount;
            //Notification.SendMail($"Your account has been debited {amount}");
            //Notification.SendMsg($"Your account has been credited {amount}");

            if (Alert != null)
            {
                Alert($"Your account has been debited {amount}");
            }
        }
    }
    class Notification
    {
        public static void SendMail(string msg)
        {
            //MailMessage msg = new MailMessage("abc@bank.com", "customer@mail.com");
            //msg.Subject = "Account Transaction";
            //msg.Body = "fafasfafafa";

            //SmtpClient smtp = new SmtpClient();
            //smtp.Send(msg);
            Console.WriteLine($"Mail:{msg}");
        }

        public static void SendMsg(string msg)
        {
            Console.WriteLine($"SMS:{msg}");    
        }
    }
}
