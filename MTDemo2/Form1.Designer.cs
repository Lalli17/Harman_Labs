namespace MTDemo2
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
            panel1.Location = new Point(21, 59);
            panel1.Name = "panel1";
            panel1.Size = new Size(484, 356);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Location = new Point(574, 59);
            panel2.Name = "panel2";
            panel2.Size = new Size(484, 356);
            panel2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(144, 22);
            button1.Name = "button1";
            button1.Size = new Size(197, 23);
            button1.TabIndex = 2;
            button1.Text = "Draw Red Rectangles";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(743, 22);
            button2.Name = "button2";
            button2.Size = new Size(203, 23);
            button2.TabIndex = 3;
            button2.Text = "Draw Blue Rectangles";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 450);
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
