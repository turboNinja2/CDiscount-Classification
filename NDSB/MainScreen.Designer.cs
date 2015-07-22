namespace NDSB
{
    partial class MainScreen
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nearestCentroidPredictBtn = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // processBtn
            // 
            this.processBtn.Location = new System.Drawing.Point(550, 8);
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
            this.groupBox3.Location = new System.Drawing.Point(11, 123);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(203, 103);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "KNN";
            this.groupBox3.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nb neighbours (KNN)";
            // 
            // nbNeighbTbx
            // 
            this.nbNeighbTbx.Location = new System.Drawing.Point(116, 23);
            this.nbNeighbTbx.Margin = new System.Windows.Forms.Padding(2);
            this.nbNeighbTbx.Name = "nbNeighbTbx";
            this.nbNeighbTbx.Size = new System.Drawing.Size(76, 20);
            this.nbNeighbTbx.TabIndex = 2;
            // 
            // validateKNNBtn
            // 
            this.validateKNNBtn.Location = new System.Drawing.Point(4, 42);
            this.validateKNNBtn.Margin = new System.Windows.Forms.Padding(2);
            this.validateKNNBtn.Name = "validateKNNBtn";
            this.validateKNNBtn.Size = new System.Drawing.Size(188, 20);
            this.validateKNNBtn.TabIndex = 0;
            this.validateKNNBtn.Text = "CV";
            this.validateKNNBtn.UseVisualStyleBackColor = true;
            this.validateKNNBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(9, 80);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(162, 19);
            this.button6.TabIndex = 5;
            this.button6.Text = "CSVMerger";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // downSampleTbx
            // 
            this.downSampleTbx.Location = new System.Drawing.Point(105, 57);
            this.downSampleTbx.Name = "downSampleTbx";
            this.downSampleTbx.Size = new System.Drawing.Size(67, 20);
            this.downSampleTbx.TabIndex = 20;
            // 
            // shuffleBtn
            // 
            this.shuffleBtn.Location = new System.Drawing.Point(9, 10);
            this.shuffleBtn.Margin = new System.Windows.Forms.Padding(2);
            this.shuffleBtn.Name = "shuffleBtn";
            this.shuffleBtn.Size = new System.Drawing.Size(91, 19);
            this.shuffleBtn.TabIndex = 21;
            this.shuffleBtn.Text = "Shuffle";
            this.shuffleBtn.UseVisualStyleBackColor = true;
            this.shuffleBtn.Click += new System.EventHandler(this.shuffleBtn_Click);
            // 
            // splitBtn
            // 
            this.splitBtn.Location = new System.Drawing.Point(9, 33);
            this.splitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.splitBtn.Name = "splitBtn";
            this.splitBtn.Size = new System.Drawing.Size(91, 19);
            this.splitBtn.TabIndex = 22;
            this.splitBtn.Text = "Split";
            this.splitBtn.UseVisualStyleBackColor = true;
            this.splitBtn.Click += new System.EventHandler(this.splitBtn_Click);
            // 
            // downSampleBtn
            // 
            this.downSampleBtn.Location = new System.Drawing.Point(9, 57);
            this.downSampleBtn.Margin = new System.Windows.Forms.Padding(2);
            this.downSampleBtn.Name = "downSampleBtn";
            this.downSampleBtn.Size = new System.Drawing.Size(91, 19);
            this.downSampleBtn.TabIndex = 23;
            this.downSampleBtn.Text = "DownSample";
            this.downSampleBtn.UseVisualStyleBackColor = true;
            this.downSampleBtn.Click += new System.EventHandler(this.downSampleBtn_Click_1);
            // 
            // shuffleSeedTbx
            // 
            this.shuffleSeedTbx.Location = new System.Drawing.Point(105, 10);
            this.shuffleSeedTbx.Name = "shuffleSeedTbx";
            this.shuffleSeedTbx.Size = new System.Drawing.Size(67, 20);
            this.shuffleSeedTbx.TabIndex = 24;
            // 
            // splitTbx
            // 
            this.splitTbx.Location = new System.Drawing.Point(105, 34);
            this.splitTbx.Name = "splitTbx";
            this.splitTbx.Size = new System.Drawing.Size(67, 20);
            this.splitTbx.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nearestCentroidPredictBtn);
            this.groupBox1.Location = new System.Drawing.Point(250, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nearest Centroids";
            // 
            // nearestCentroidPredictBtn
            // 
            this.nearestCentroidPredictBtn.Location = new System.Drawing.Point(6, 38);
            this.nearestCentroidPredictBtn.Name = "nearestCentroidPredictBtn";
            this.nearestCentroidPredictBtn.Size = new System.Drawing.Size(75, 23);
            this.nearestCentroidPredictBtn.TabIndex = 0;
            this.nearestCentroidPredictBtn.Text = "Predict";
            this.nearestCentroidPredictBtn.UseVisualStyleBackColor = true;
            this.nearestCentroidPredictBtn.Click += new System.EventHandler(this.nearestCentroidPredictBtn_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 252);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitTbx);
            this.Controls.Add(this.shuffleSeedTbx);
            this.Controls.Add(this.downSampleBtn);
            this.Controls.Add(this.splitBtn);
            this.Controls.Add(this.shuffleBtn);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.downSampleTbx);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.processBtn);
            this.Name = "MainScreen";
            this.Text = "Form1";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button nearestCentroidPredictBtn;
    }
}

