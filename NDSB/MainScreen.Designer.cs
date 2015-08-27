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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.knnStemChkbx = new System.Windows.Forms.CheckBox();
            this.predictKNNBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nbNeighbTbx = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.downSampleTbx = new System.Windows.Forms.TextBox();
            this.shuffleBtn = new System.Windows.Forms.Button();
            this.splitBtn = new System.Windows.Forms.Button();
            this.downSampleBtn = new System.Windows.Forms.Button();
            this.shuffleSeedTbx = new System.Windows.Forms.TextBox();
            this.splitTbx = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ncStemChkbx = new System.Windows.Forms.CheckBox();
            this.nearestCentroidPredictBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.trainAndPredictBtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rfStemChkbx = new System.Windows.Forms.CheckBox();
            this.translateAndPredictRFBtn = new System.Windows.Forms.Button();
            this.minEltsLeafTbx = new System.Windows.Forms.TextBox();
            this.minEltLeafLbl = new System.Windows.Forms.Label();
            this.extractColumnBtn = new System.Windows.Forms.Button();
            this.extractColumnTbx = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.knnStemChkbx);
            this.groupBox3.Controls.Add(this.predictKNNBtn);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.nbNeighbTbx);
            this.groupBox3.Location = new System.Drawing.Point(20, 172);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(237, 119);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "KNN";
            this.groupBox3.UseCompatibleTextRendering = true;
            // 
            // knnStemChkbx
            // 
            this.knnStemChkbx.AutoSize = true;
            this.knnStemChkbx.Location = new System.Drawing.Point(28, 16);
            this.knnStemChkbx.Margin = new System.Windows.Forms.Padding(4);
            this.knnStemChkbx.Name = "knnStemChkbx";
            this.knnStemChkbx.Size = new System.Drawing.Size(62, 21);
            this.knnStemChkbx.TabIndex = 2;
            this.knnStemChkbx.Text = "Stem";
            this.knnStemChkbx.UseVisualStyleBackColor = true;
            // 
            // predictKNNBtn
            // 
            this.predictKNNBtn.Location = new System.Drawing.Point(5, 76);
            this.predictKNNBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.predictKNNBtn.Name = "predictKNNBtn";
            this.predictKNNBtn.Size = new System.Drawing.Size(227, 25);
            this.predictKNNBtn.TabIndex = 5;
            this.predictKNNBtn.Text = "Translate and Predict";
            this.predictKNNBtn.UseVisualStyleBackColor = true;
            this.predictKNNBtn.Click += new System.EventHandler(this.predictKNNBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nb neighbours";
            // 
            // nbNeighbTbx
            // 
            this.nbNeighbTbx.Location = new System.Drawing.Point(13, 43);
            this.nbNeighbTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nbNeighbTbx.Name = "nbNeighbTbx";
            this.nbNeighbTbx.Size = new System.Drawing.Size(31, 22);
            this.nbNeighbTbx.TabIndex = 2;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 126);
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
            this.downSampleTbx.Text = "1000";
            // 
            // shuffleBtn
            // 
            this.shuffleBtn.Location = new System.Drawing.Point(12, 12);
            this.shuffleBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.splitBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.downSampleBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.shuffleSeedTbx.Text = "0";
            // 
            // splitTbx
            // 
            this.splitTbx.Location = new System.Drawing.Point(140, 42);
            this.splitTbx.Margin = new System.Windows.Forms.Padding(4);
            this.splitTbx.Name = "splitTbx";
            this.splitTbx.Size = new System.Drawing.Size(88, 22);
            this.splitTbx.TabIndex = 25;
            this.splitTbx.Text = "0.9";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ncStemChkbx);
            this.groupBox1.Controls.Add(this.nearestCentroidPredictBtn);
            this.groupBox1.Location = new System.Drawing.Point(16, 298);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(241, 89);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nearest Centroids";
            // 
            // ncStemChkbx
            // 
            this.ncStemChkbx.AutoSize = true;
            this.ncStemChkbx.Location = new System.Drawing.Point(35, 28);
            this.ncStemChkbx.Margin = new System.Windows.Forms.Padding(4);
            this.ncStemChkbx.Name = "ncStemChkbx";
            this.ncStemChkbx.Size = new System.Drawing.Size(62, 21);
            this.ncStemChkbx.TabIndex = 1;
            this.ncStemChkbx.Text = "Stem";
            this.ncStemChkbx.UseVisualStyleBackColor = true;
            // 
            // nearestCentroidPredictBtn
            // 
            this.nearestCentroidPredictBtn.Location = new System.Drawing.Point(8, 57);
            this.nearestCentroidPredictBtn.Margin = new System.Windows.Forms.Padding(4);
            this.nearestCentroidPredictBtn.Name = "nearestCentroidPredictBtn";
            this.nearestCentroidPredictBtn.Size = new System.Drawing.Size(219, 28);
            this.nearestCentroidPredictBtn.TabIndex = 0;
            this.nearestCentroidPredictBtn.Text = "Translate and Predict";
            this.nearestCentroidPredictBtn.UseVisualStyleBackColor = true;
            this.nearestCentroidPredictBtn.Click += new System.EventHandler(this.nearestCentroidPredictBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.trainAndPredictBtn);
            this.groupBox2.Location = new System.Drawing.Point(271, 298);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(235, 89);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SGD";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 54);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Train and predict (hierarchical)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trainAndPredictBtn
            // 
            this.trainAndPredictBtn.Location = new System.Drawing.Point(8, 21);
            this.trainAndPredictBtn.Margin = new System.Windows.Forms.Padding(4);
            this.trainAndPredictBtn.Name = "trainAndPredictBtn";
            this.trainAndPredictBtn.Size = new System.Drawing.Size(219, 28);
            this.trainAndPredictBtn.TabIndex = 1;
            this.trainAndPredictBtn.Text = "Train and predict";
            this.trainAndPredictBtn.UseVisualStyleBackColor = true;
            this.trainAndPredictBtn.Click += new System.EventHandler(this.trainAndPredictBtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rfStemChkbx);
            this.groupBox4.Controls.Add(this.translateAndPredictRFBtn);
            this.groupBox4.Controls.Add(this.minEltsLeafTbx);
            this.groupBox4.Controls.Add(this.minEltLeafLbl);
            this.groupBox4.Location = new System.Drawing.Point(271, 170);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(232, 122);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Decision Tree";
            // 
            // rfStemChkbx
            // 
            this.rfStemChkbx.AutoSize = true;
            this.rfStemChkbx.Location = new System.Drawing.Point(29, 23);
            this.rfStemChkbx.Margin = new System.Windows.Forms.Padding(4);
            this.rfStemChkbx.Name = "rfStemChkbx";
            this.rfStemChkbx.Size = new System.Drawing.Size(62, 21);
            this.rfStemChkbx.TabIndex = 2;
            this.rfStemChkbx.Text = "Stem";
            this.rfStemChkbx.UseVisualStyleBackColor = true;
            // 
            // translateAndPredictRFBtn
            // 
            this.translateAndPredictRFBtn.Location = new System.Drawing.Point(8, 79);
            this.translateAndPredictRFBtn.Margin = new System.Windows.Forms.Padding(4);
            this.translateAndPredictRFBtn.Name = "translateAndPredictRFBtn";
            this.translateAndPredictRFBtn.Size = new System.Drawing.Size(219, 28);
            this.translateAndPredictRFBtn.TabIndex = 8;
            this.translateAndPredictRFBtn.Text = "Translate and predict";
            this.translateAndPredictRFBtn.UseVisualStyleBackColor = true;
            this.translateAndPredictRFBtn.Click += new System.EventHandler(this.translateAndPredictRFBtn_Click);
            // 
            // minEltsLeafTbx
            // 
            this.minEltsLeafTbx.Location = new System.Drawing.Point(8, 50);
            this.minEltsLeafTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minEltsLeafTbx.Name = "minEltsLeafTbx";
            this.minEltsLeafTbx.Size = new System.Drawing.Size(36, 22);
            this.minEltsLeafTbx.TabIndex = 5;
            // 
            // minEltLeafLbl
            // 
            this.minEltLeafLbl.AutoSize = true;
            this.minEltLeafLbl.Location = new System.Drawing.Point(49, 54);
            this.minEltLeafLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minEltLeafLbl.Name = "minEltLeafLbl";
            this.minEltLeafLbl.Size = new System.Drawing.Size(75, 20);
            this.minEltLeafLbl.TabIndex = 4;
            this.minEltLeafLbl.Text = "MinEltsLeaf";
            this.minEltLeafLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.minEltLeafLbl.UseCompatibleTextRendering = true;
            // 
            // extractColumnBtn
            // 
            this.extractColumnBtn.Location = new System.Drawing.Point(12, 97);
            this.extractColumnBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.extractColumnBtn.Name = "extractColumnBtn";
            this.extractColumnBtn.Size = new System.Drawing.Size(121, 23);
            this.extractColumnBtn.TabIndex = 29;
            this.extractColumnBtn.Text = "Extract col";
            this.extractColumnBtn.UseVisualStyleBackColor = true;
            this.extractColumnBtn.Click += new System.EventHandler(this.extractColumnBtn_Click);
            // 
            // extractColumnTbx
            // 
            this.extractColumnTbx.Location = new System.Drawing.Point(140, 97);
            this.extractColumnTbx.Margin = new System.Windows.Forms.Padding(4);
            this.extractColumnTbx.Name = "extractColumnTbx";
            this.extractColumnTbx.Size = new System.Drawing.Size(88, 22);
            this.extractColumnTbx.TabIndex = 28;
            this.extractColumnTbx.Text = "3";
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 411);
            this.Controls.Add(this.extractColumnBtn);
            this.Controls.Add(this.extractColumnTbx);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitTbx);
            this.Controls.Add(this.shuffleSeedTbx);
            this.Controls.Add(this.downSampleBtn);
            this.Controls.Add(this.splitBtn);
            this.Controls.Add(this.shuffleBtn);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.downSampleTbx);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainScreen";
            this.Text = "CDiscount Classification tools";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nbNeighbTbx;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox downSampleTbx;
        private System.Windows.Forms.Button shuffleBtn;
        private System.Windows.Forms.Button splitBtn;
        private System.Windows.Forms.Button downSampleBtn;
        private System.Windows.Forms.TextBox shuffleSeedTbx;
        private System.Windows.Forms.TextBox splitTbx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button nearestCentroidPredictBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button predictKNNBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox minEltsLeafTbx;
        private System.Windows.Forms.Label minEltLeafLbl;
        private System.Windows.Forms.Button translateAndPredictRFBtn;
        private System.Windows.Forms.Button extractColumnBtn;
        private System.Windows.Forms.TextBox extractColumnTbx;
        private System.Windows.Forms.Button trainAndPredictBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ncStemChkbx;
        private System.Windows.Forms.CheckBox rfStemChkbx;
        private System.Windows.Forms.CheckBox knnStemChkbx;
    }
}

