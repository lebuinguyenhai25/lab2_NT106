namespace cau1_lab2
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
            btnWrite = new Button();
            richTextBox1 = new RichTextBox();
            btnRead = new Button();
            SuspendLayout();
            // 
            // btnWrite
            // 
            btnWrite.Location = new Point(76, 260);
            btnWrite.Name = "btnWrite";
            btnWrite.Size = new Size(94, 42);
            btnWrite.TabIndex = 1;
            btnWrite.Text = "GHI FILE";
            btnWrite.UseVisualStyleBackColor = true;
            btnWrite.Click += btnWrite_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(292, 78);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(402, 317);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(76, 107);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(94, 44);
            btnRead.TabIndex = 0;
            btnRead.Text = "ĐỌC FILE";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 450);
            Controls.Add(richTextBox1);
            Controls.Add(btnWrite);
            Controls.Add(btnRead);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnWrite;
        private RichTextBox richTextBox1;
        private Button btnRead;
    }
}
