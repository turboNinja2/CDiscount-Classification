namespace NDSB
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.processBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nbNeighbTbx = new System.Windows.Forms.TextBox();
            this.validateKNNBtn = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.downSampleTbx = new System.Windows.Forms.TextBox();
            this.shuffleBtn = new System.Windows.Forms.Button();
            this.splitBtn = new System.Windows.Forms.Button();
            this.downSampleBtn = new System.Windows.Forms.Button();
            this.shuffleSeedTbx = new System.Windows.Forms.TextBox();
            this.splitTbx = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // processBtn
            // 
            this.processBtn.Location = new System.Drawing.Point(632, 36);
            this.processBtn.Margin = new System.Windows.Forms.Padding(4);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(100, 28);
            this.processBtn.TabIndex = 11;
            this.processBtn.Text = "32_64btn";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Click += new System.EventHandler(this.processBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.nbNeighbTbx);
            this.groupBox3.Controls.Add(this.validateKNNBtn);
            this.groupBox3.Location = new System.Drawing.Point(381, 124);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(399, 127);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Latest";
            this.groupBox3.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nb neighbours (KNN)";
            // 
            // nbNeighbTbx
            // 
            this.nbNeighbTbx.Location = new System.Drawing.Point(153, 49);
            this.nbNeighbTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nbNeighbTbx.Name = "nbNeighbTbx";
            this.nbNeighbTbx.Size = new System.Drawing.Size(100, 22);
            this.nbNeighbTbx.TabIndex = 2;
            // 
            // validateKNNBtn
            // 
            this.validateKNNBtn.Location = new System.Drawing.Point(259, 20);
            this.validateKNNBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.validateKNNBtn.Name = "validateKNNBtn";
            this.validateKNNBtn.Size = new System.Drawing.Size(131, 50);
            this.validateKNNBtn.TabIndex = 0;
            this.validateKNNBtn.Text = "KNN";
            this.validateKNNBtn.UseVisualStyleBackColor = true;
            this.validateKNNBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 98);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(216, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "CSVMerger";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // downSampleTbx
            // 
            this.downSampleTbx.Location = new System.Drawing.Point(140, 70);
            this.downSampleTbx.Margin = new System.Windows.Forms.Padding(4);
            this.downSampleTbx.Name = "downSampleTbx";
            this.downSampleTbx.Size = new System.Drawing.Size(88, 22);
            this.downSampleTbx.TabIndex = 20;
            // 
            // shuffleBtn
            // 
            this.shuffleBtn.Location = new System.Drawing.Point(12, 12);
            this.shuffleBtn.Name = "shuffleBtn";
            this.shuffleBtn.Size = new System.Drawing.Size(121, 23);
            this.shuffleBtn.TabIndex = 21;
            this.shuffleBtn.Text = "Shuffle";
            this.shuffleBtn.UseVisualStyleBackColor = true;
            this.shuffleBtn.Click += new System.EventHandler(this.shuffleBtn_Click);
            // 
            // splitBtn
            // 
            this.splitBtn.Location = new System.Drawing.Point(12, 41);
            this.splitBtn.Name = "splitBtn";
            this.splitBtn.Size = new System.Drawing.Size(121, 23);
            this.splitBtn.TabIndex = 22;
            this.splitBtn.Text = "Split";
            this.splitBtn.UseVisualStyleBackColor = true;
            this.splitBtn.Click += new System.EventHandler(this.splitBtn_Click);
            // 
            // downSampleBtn
            // 
            this.downSampleBtn.Location = new System.Drawing.Point(12, 70);
            this.downSampleBtn.Name = "downSampleBtn";
            this.downSampleBtn.Size = new System.Drawing.Size(121, 23);
            this.downSampleBtn.TabIndex = 23;
            this.downSampleBtn.Text = "DownSample";
            this.downSampleBtn.UseVisualStyleBackColor = true;
            this.downSampleBtn.Click += new System.EventHandler(this.downSampleBtn_Click_1);
            // 
            // shuffleSeedTbx
            // 
            this.shuffleSeedTbx.Location = new System.Drawing.Point(140, 12);
            this.shuffleSeedTbx.Margin = new System.Windows.Forms.Padding(4);
            this.shuffleSeedTbx.Name = "shuffleSeedTbx";
            this.shuffleSeedTbx.Size = new System.Drawing.Size(88, 22);
            this.shuffleSeedTbx.TabIndex = 24;
            // 
            // splitTbx
            // 
            this.splitTbx.Location = new System.Drawing.Point(140, 42);
            this.splitTbx.Margin = new System.Windows.Forms.Padding(4);
            this.splitTbx.Name = "splitTbx";
            this.splitTbx.Size = new System.Drawing.Size(88, 22);
            this.splitTbx.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 310);
            this.Controls.Add(this.splitTbx);
            this.Controls.Add(this.shuffleSeedTbx);
            this.Controls.Add(this.downSampleBtn);
            this.Controls.Add(this.splitBtn);
            this.Controls.Add(this.shuffleBtn);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.downSampleTbx);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.processBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button processBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nbNeighbTbx;
        private System.Windows.Forms.Button validateKNNBtn;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox downSampleTbx;
        private System.Windows.Forms.Button shuffleBtn;
        private System.Windows.Forms.Button splitBtn;
        private System.Windows.Forms.Button downSampleBtn;
        private System.Windows.Forms.TextBox shuffleSeedTbx;
        private System.Windows.Forms.TextBox splitTbx;
    }
}

