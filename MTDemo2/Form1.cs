namespace MTDemo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Task.Factory.StartNew(new Form1().DrawRedRect);
            Task t = new Task(this.DrawRedRect);
            t.Start();
        }

        private void DrawRedRect()
        {
            var red = panel1.CreateGraphics();
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int x = rnd.Next(panel1.Width);
                int y = rnd.Next(panel1.Height);

                red.DrawRectangle(Pens.Red, x, y, 20, 20);
                //Task.Delay(100000);
                Thread.Sleep(100);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Task(() =>
            //Parallel.Invoke(() =>
            {
                var red = panel2.CreateGraphics();
                Random rnd = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    int x = rnd.Next(panel2.Width);
                    int y = rnd.Next(panel2.Height);

                    red.DrawRectangle(Pens.Blue, x, y, 20, 20);
                    //Task.Delay(100000);
                    Thread.Sleep(100);
                }
            }).Start(); ;
        }
    }
}
