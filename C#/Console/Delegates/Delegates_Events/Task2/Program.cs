namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Form myForm = new Form();
            myForm.HandleButtonClick();
        }
    }
    public delegate void ButtonClicked();


    public class Button
    {
        public event ButtonClicked OnButtonClicked;

        public void Click()
        {
            Console.WriteLine("Button was clicked!");
            OnButtonClicked?.Invoke();  // Raise the event if there are subscribers
        }
    }


    public class Form
    {
        private Button button = new Button();

        public void SubscribeToButtonClick()
        {
            // Subscribe using anonymous method
            button.OnButtonClicked += delegate
            {
                Console.WriteLine("Anonymous method: Button click event handled in Form.");
            };
        }

        public void HandleButtonClick()
        {
            // Subscribe to the event
            SubscribeToButtonClick();

            // Simulate button click
            button.Click();
        }
    }
}
