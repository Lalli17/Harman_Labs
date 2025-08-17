namespace MT_DEMO2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(93, 98);
            panel1.Name = "panel1";
            panel1.Size = new Size(567, 425);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Location = new Point(772, 98);
            panel2.Name = "panel2";
            panel2.Size = new Size(567, 425);
            panel2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(222, 54);
            button1.Name = "button1";
            button1.Size = new Size(204, 23);
            button1.TabIndex = 0;
            button1.Text = "Draw Red Rectangle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(932, 54);
            button2.Name = "button2";
            button2.Size = new Size(246, 23);
            button2.TabIndex = 1;
            button2.Text = "Draw Blue rectangle";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1444, 625);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button button1;
        private Button button2;
    }
}
