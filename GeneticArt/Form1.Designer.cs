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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AIPic1 = new System.Windows.Forms.PictureBox();
            this.inputImage = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.trainButton = new System.Windows.Forms.Button();
            this.autoTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.AIPic1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputImage)).BeginInit();
            this.SuspendLayout();
            // 
            // AIPic1
            // 
            this.AIPic1.BackColor = System.Drawing.Color.Transparent;
            this.AIPic1.Location = new System.Drawing.Point(660, 47);
            this.AIPic1.Name = "AIPic1";
            this.AIPic1.Size = new System.Drawing.Size(386, 239);
            this.AIPic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AIPic1.TabIndex = 1;
            this.AIPic1.TabStop = false;
            // 
            // inputImage
            // 
            this.inputImage.BackColor = System.Drawing.Color.Transparent;
            this.inputImage.Location = new System.Drawing.Point(92, 12);
            this.inputImage.Name = "inputImage";
            this.inputImage.Size = new System.Drawing.Size(386, 239);
            this.inputImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inputImage.TabIndex = 2;
            this.inputImage.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trainButton
            // 
            this.trainButton.Location = new System.Drawing.Point(23, 152);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(75, 23);
            this.trainButton.TabIndex = 4;
            this.trainButton.Text = "Start";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // autoTimer
            // 
            this.autoTimer.Enabled = true;
            this.autoTimer.Interval = 1;
            this.autoTimer.Tick += new System.EventHandler(this.autoTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1123, 709);
            this.Controls.Add(this.trainButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inputImage);
            this.Controls.Add(this.AIPic1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.AIPic1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBox AIPic1;
        private PictureBox inputImage;
        private OpenFileDialog openFileDialog1;
        private Button button1;
        private Button trainButton;
        private System.Windows.Forms.Timer autoTimer;
    }
}