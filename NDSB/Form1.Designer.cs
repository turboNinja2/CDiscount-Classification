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
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nbNeighbTbx = new System.Windows.Forms.TextBox();
            this.validateKNNBtn = new System.Windows.Forms.Button();
            this.shuffleAndSplitBtn = new System.Windows.Forms.Button();
            this.downSampleBtn = new System.Windows.Forms.Button();
            this.downSampleTbx = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // processBtn
            // 
            this.processBtn.Location = new System.Drawing.Point(502, 12);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(75, 23);
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
            this.groupBox3.Location = new System.Drawing.Point(41, 78);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(299, 103);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Latest";
            this.groupBox3.UseCompatibleTextRendering = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(398, 122);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(202, 19);
            this.button6.TabIndex = 5;
            this.button6.Text = "CSVMerger";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nb neighbours (KNN)";
            // 
            // nbNeighbTbx
            // 
            this.nbNeighbTbx.Location = new System.Drawing.Point(115, 40);
            this.nbNeighbTbx.Margin = new System.Windows.Forms.Padding(2);
            this.nbNeighbTbx.Name = "nbNeighbTbx";
            this.nbNeighbTbx.Size = new System.Drawing.Size(76, 20);
            this.nbNeighbTbx.TabIndex = 2;
            // 
            // validateKNNBtn
            // 
            this.validateKNNBtn.Location = new System.Drawing.Point(194, 16);
            this.validateKNNBtn.Margin = new System.Windows.Forms.Padding(2);
            this.validateKNNBtn.Name = "validateKNNBtn";
            this.validateKNNBtn.Size = new System.Drawing.Size(98, 41);
            this.validateKNNBtn.TabIndex = 0;
            this.validateKNNBtn.Text = "KNN";
            this.validateKNNBtn.UseVisualStyleBackColor = true;
            this.validateKNNBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // shuffleAndSplitBtn
            // 
            this.shuffleAndSplitBtn.Location = new System.Drawing.Point(398, 65);
            this.shuffleAndSplitBtn.Name = "shuffleAndSplitBtn";
            this.shuffleAndSplitBtn.Size = new System.Drawing.Size(202, 23);
            this.shuffleAndSplitBtn.TabIndex = 18;
            this.shuffleAndSplitBtn.Text = "SuffleAndSplit";
            this.shuffleAndSplitBtn.UseVisualStyleBackColor = true;
            this.shuffleAndSplitBtn.Click += new System.EventHandler(this.shuffleAndSplitBtn_Click);
            // 
            // downSampleBtn
            // 
            this.downSampleBtn.Location = new System.Drawing.Point(504, 94);
            this.downSampleBtn.Name = "downSampleBtn";
            this.downSampleBtn.Size = new System.Drawing.Size(96, 23);
            this.downSampleBtn.TabIndex = 19;
            this.downSampleBtn.Text = "DownSample";
            this.downSampleBtn.UseVisualStyleBackColor = true;
            this.downSampleBtn.Click += new System.EventHandler(this.downSampleBtn_Click);
            // 
            // downSampleTbx
            // 
            this.downSampleTbx.Location = new System.Drawing.Point(398, 97);
            this.downSampleTbx.Name = "downSampleTbx";
            this.downSampleTbx.Size = new System.Drawing.Size(100, 20);
            this.downSampleTbx.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 252);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.downSampleTbx);
            this.Controls.Add(this.downSampleBtn);
            this.Controls.Add(this.shuffleAndSplitBtn);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.processBtn);
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
        private System.Windows.Forms.Button shuffleAndSplitBtn;
        private System.Windows.Forms.Button downSampleBtn;
        private System.Windows.Forms.TextBox downSampleTbx;
    }
}

