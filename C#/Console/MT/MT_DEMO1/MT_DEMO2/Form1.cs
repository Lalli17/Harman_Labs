namespace MT_DEMO2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Task.Factory.StartNew(new Form1().DrawRedRect);
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
                //Task.Delay(1000);
                Thread.Sleep(10);
                //shd be always done in the childthread and not the main thread
            }
         }

        private void button2_Click(object sender, EventArgs e)
        {
            //donot use Parallel.invoke(()=> bcs it will block the main thread and it becomes unresponsive again
            new Task(() =>
            {
            var blue = panel2.CreateGraphics();
            Random rnd = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    int x = rnd.Next(panel2.Width);
                    int y = rnd.Next(panel2.Height);

                    blue.DrawRectangle(Pens.Blue, x, y, 20, 20);
                    Thread.Sleep(10);//run in the child thread

                }
            }).Start();
            //rather than seperate method create an anonymous delegate
        }
    }
}
