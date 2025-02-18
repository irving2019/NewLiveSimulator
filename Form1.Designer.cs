namespace NewLiveSimulator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudResolution = new System.Windows.Forms.NumericUpDown();
            this.nudDensity = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Startbtn = new System.Windows.Forms.Button();
            this.Stopbtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDensity)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Stopbtn);
            this.splitContainer1.Panel1.Controls.Add(this.Startbtn);
            this.splitContainer1.Panel1.Controls.Add(this.nudDensity);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.nudResolution);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 165;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(627, 446);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resolution";
            // 
            // nudResolution
            // 
            this.nudResolution.Location = new System.Drawing.Point(14, 42);
            this.nudResolution.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudResolution.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudResolution.Name = "nudResolution";
            this.nudResolution.Size = new System.Drawing.Size(120, 20);
            this.nudResolution.TabIndex = 1;
            this.nudResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudResolution.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nudDensity
            // 
            this.nudDensity.Location = new System.Drawing.Point(14, 112);
            this.nudDensity.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudDensity.Name = "nudDensity";
            this.nudDensity.Size = new System.Drawing.Size(120, 20);
            this.nudDensity.TabIndex = 3;
            this.nudDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDensity.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Small", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Density";
            // 
            // Startbtn
            // 
            this.Startbtn.Font = new System.Drawing.Font("Sitka Small", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Startbtn.Location = new System.Drawing.Point(15, 161);
            this.Startbtn.Name = "Startbtn";
            this.Startbtn.Size = new System.Drawing.Size(119, 23);
            this.Startbtn.TabIndex = 4;
            this.Startbtn.Text = "Start";
            this.Startbtn.UseVisualStyleBackColor = true;
            this.Startbtn.Click += new System.EventHandler(this.Startbtn_Click);
            // 
            // Stopbtn
            // 
            this.Stopbtn.Font = new System.Drawing.Font("Sitka Small", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Stopbtn.Location = new System.Drawing.Point(15, 209);
            this.Stopbtn.Name = "Stopbtn";
            this.Stopbtn.Size = new System.Drawing.Size(119, 23);
            this.Stopbtn.TabIndex = 5;
            this.Stopbtn.Text = "Stop";
            this.Stopbtn.UseVisualStyleBackColor = true;
            this.Stopbtn.Click += new System.EventHandler(this.Stopbtn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDensity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NumericUpDown nudResolution;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown nudDensity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Stopbtn;
        private System.Windows.Forms.Button Startbtn;
        private System.Windows.Forms.Timer timer1;
    }
}

