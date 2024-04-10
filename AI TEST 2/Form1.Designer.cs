namespace AI_TEST_2
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
            picOriginal = new PictureBox();
            picProcessed = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            cmbAlgorithm = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)picOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picProcessed).BeginInit();
            SuspendLayout();
            // 
            // picOriginal
            // 
            picOriginal.BackColor = SystemColors.ActiveCaption;
            picOriginal.Location = new Point(39, 63);
            picOriginal.Name = "picOriginal";
            picOriginal.Size = new Size(295, 345);
            picOriginal.TabIndex = 0;
            picOriginal.TabStop = false;
            picOriginal.Click += OriginalImage_Click;
            // 
            // picProcessed
            // 
            picProcessed.BackColor = SystemColors.ActiveCaption;
            picProcessed.Location = new Point(512, 63);
            picProcessed.Name = "picProcessed";
            picProcessed.Size = new Size(287, 345);
            picProcessed.TabIndex = 1;
            picProcessed.TabStop = false;
            picProcessed.Click += PictureBox2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(346, 355);
            button1.Name = "button1";
            button1.Size = new Size(160, 23);
            button1.TabIndex = 2;
            button1.Text = "Choose an image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(346, 384);
            button2.Name = "button2";
            button2.Size = new Size(160, 23);
            button2.TabIndex = 3;
            button2.Text = "Use a processing algorithm";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // cmbAlgorithm
            // 
            cmbAlgorithm.FormattingEnabled = true;
            cmbAlgorithm.Location = new Point(354, 63);
            cmbAlgorithm.Name = "cmbAlgorithm";
            cmbAlgorithm.Size = new Size(137, 23);
            cmbAlgorithm.TabIndex = 4;
            cmbAlgorithm.Text = "Choose an algorithm";
            cmbAlgorithm.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 476);
            Controls.Add(cmbAlgorithm);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(picProcessed);
            Controls.Add(picOriginal);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)picProcessed).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picOriginal;
        private PictureBox picProcessed;
        private Button button1;
        private Button button2;
        private ComboBox cmbAlgorithm;
    }
}
