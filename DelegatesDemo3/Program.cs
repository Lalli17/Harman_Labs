namespace DelegatesDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(); // open account
            account.Alert += Notification.SendSMS;
            account.Alert += Notification.SendMail;
            account.Alert += Notification.SendWhatsApp;
            account.Alert -= Notification.SendSMS;
            account.Alert += Notification.SendVoiceMsg;
            account.Deposit(5000); // transaction

            //account.Alert("Your account has been credited by $100000000000000000000");

            //account.Subscribe(Notification.SendMail);
            // account.Deposit(10000);

            Console.WriteLine(account.Balance);
            //account.Withdraw(1000);
            //Console.WriteLine(account.Balance);
        }
    }


    // backend dev team

    public delegate void AlertDelegate(string message);

    class Account // SRP  OCP
    {
        public int Balance { get; private set; }
        public event AlertDelegate Alert = null; //new AlertDelegate(Notification.SendMail);

        //public void Subscribe(AlertDelegate alert) { Alert += alert; }
        //public void Unsubscribe(AlertDelegate alert) { Alert -= alert; }

        public void Deposit(int amount) // SRP
        {
            Balance += amount;
            // write email sendig code here
            //Notification.SendMail($"Your account has been credited {amount}");
            //Notification.SendSMS($"Your account has been credited {amount}");
            //Notification.SendWhatsApp($"Your account has been credited {amount}");
            if (Alert != null)
                Alert($"Your account has been credited {amount}");

        }
        public void Withdraw(int amount)
        {
            Balance -= amount;
            // write email sendig code here
            //Notification.SendMail($"Your account has been debited {amount}");
            //Notification.SendSMS($"Your account has been debited {amount}");
            //Notification.SendWhatsApp($"Your account has been debited {amount}");
            if (Alert != null)
                Alert($"Your account has been debited {amount}");
        }


    }

    class Notification
    {
        public static void SendMail(string msg) // SRP
        {
            //MailMessage msg = new MailMessage("xyz@bank.com","customer1@mail.com");
            //msg.Subject = "Account transaction";
            //msg.Body = "sdfsdfsdfsdf";

            //SmtpClient smtp = new SmtpClient();
            //// configure smtp
            //smtp.Send(msg);
            Console.WriteLine($"Mail:  {msg}");
        }

        public static void SendSMS(string msg)
        {
            Console.WriteLine($"SMS: {msg}");
        }
        public static void SendWhatsApp(string msg)
        {
            Console.WriteLine($"WhatsApp: {msg}");
        }

        public static void SendVoiceMsg(string msg)
        {
            Console.WriteLine($"Voice Msg: {msg}");
        }
    }
}
