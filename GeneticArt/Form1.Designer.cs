namespace GeneticArt
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
            components = new System.ComponentModel.Container();
            AIPic1 = new PictureBox();
            inputImage = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            button1 = new Button();
            trainButton = new Button();
            autoTimer = new System.Windows.Forms.Timer(components);
            AIPic2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)AIPic1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AIPic2).BeginInit();
            SuspendLayout();
            // 
            // AIPic1
            // 
            AIPic1.Location = new Point(242, 1);
            AIPic1.Margin = new Padding(3, 4, 3, 4);
            AIPic1.Name = "AIPic1";
            AIPic1.Size = new Size(542, 460);
            AIPic1.TabIndex = 1;
            AIPic1.TabStop = false;
            // 
            // inputImage
            // 
            inputImage.Location = new Point(790, 1);
            inputImage.Margin = new Padding(3, 4, 3, 4);
            inputImage.Name = "inputImage";
            inputImage.Size = new Size(480, 928);
            inputImage.TabIndex = 2;
            inputImage.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // button1
            // 
            button1.Location = new Point(26, 164);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 3;
            button1.Text = "Load";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // trainButton
            // 
            trainButton.Location = new Point(26, 203);
            trainButton.Margin = new Padding(3, 4, 3, 4);
            trainButton.Name = "trainButton";
            trainButton.Size = new Size(86, 31);
            trainButton.TabIndex = 4;
            trainButton.Text = "Start";
            trainButton.UseVisualStyleBackColor = true;
            trainButton.Click += trainButton_Click;
            // 
            // autoTimer
            // 
            autoTimer.Enabled = true;
            autoTimer.Interval = 1;
            autoTimer.Tick += autoTimer_Tick;
            // 
            // AIPic2
            // 
            AIPic2.Location = new Point(241, 468);
            AIPic2.Name = "AIPic2";
            AIPic2.Size = new Size(543, 461);
            AIPic2.TabIndex = 5;
            AIPic2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1283, 945);
            Controls.Add(AIPic2);
            Controls.Add(trainButton);
            Controls.Add(button1);
            Controls.Add(inputImage);
            Controls.Add(AIPic1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)AIPic1).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)AIPic2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox AIPic1;
        private PictureBox inputImage;
        private OpenFileDialog openFileDialog1;
        private Button button1;
        private Button trainButton;
        private System.Windows.Forms.Timer autoTimer;
        private PictureBox AIPic2;
    }
}