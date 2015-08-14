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
            this.predictSGDBtn = new System.Windows.Forms.Button();
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
            this.groupBox3.Location = new System.Drawing.Point(15, 140);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(178, 97);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "KNN";
            this.groupBox3.UseCompatibleTextRendering = true;
            // 
            // knnStemChkbx
            // 
            this.knnStemChkbx.AutoSize = true;
            this.knnStemChkbx.Location = new System.Drawing.Point(26, 13);
            this.knnStemChkbx.Name = "knnStemChkbx";
            this.knnStemChkbx.Size = new System.Drawing.Size(50, 17);
            this.knnStemChkbx.TabIndex = 2;
            this.knnStemChkbx.Text = "Stem";
            this.knnStemChkbx.UseVisualStyleBackColor = true;
            // 
            // predictKNNBtn
            // 
            this.predictKNNBtn.Location = new System.Drawing.Point(4, 62);
            this.predictKNNBtn.Margin = new System.Windows.Forms.Padding(2);
            this.predictKNNBtn.Name = "predictKNNBtn";
            this.predictKNNBtn.Size = new System.Drawing.Size(170, 20);
            this.predictKNNBtn.TabIndex = 5;
            this.predictKNNBtn.Text = "Translate and Predict";
            this.predictKNNBtn.UseVisualStyleBackColor = true;
            this.predictKNNBtn.Click += new System.EventHandler(this.predictKNNBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nb neighbours";
            // 
            // nbNeighbTbx
            // 
            this.nbNeighbTbx.Location = new System.Drawing.Point(10, 35);
            this.nbNeighbTbx.Margin = new System.Windows.Forms.Padding(2);
            this.nbNeighbTbx.Name = "nbNeighbTbx";
            this.nbNeighbTbx.Size = new System.Drawing.Size(24, 20);
            this.nbNeighbTbx.TabIndex = 2;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(9, 102);
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
            this.downSampleTbx.Text = "1000";
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
            this.shuffleSeedTbx.Text = "0";
            // 
            // splitTbx
            // 
            this.splitTbx.Location = new System.Drawing.Point(105, 34);
            this.splitTbx.Name = "splitTbx";
            this.splitTbx.Size = new System.Drawing.Size(67, 20);
            this.splitTbx.TabIndex = 25;
            this.splitTbx.Text = "0.9";
            this.splitTbx.TextChanged += new System.EventHandler(this.splitTbx_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ncStemChkbx);
            this.groupBox1.Controls.Add(this.nearestCentroidPredictBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 255);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 72);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nearest Centroids";
            // 
            // ncStemChkbx
            // 
            this.ncStemChkbx.AutoSize = true;
            this.ncStemChkbx.Location = new System.Drawing.Point(22, 23);
            this.ncStemChkbx.Name = "ncStemChkbx";
            this.ncStemChkbx.Size = new System.Drawing.Size(50, 17);
            this.ncStemChkbx.TabIndex = 1;
            this.ncStemChkbx.Text = "Stem";
            this.ncStemChkbx.UseVisualStyleBackColor = true;
            // 
            // nearestCentroidPredictBtn
            // 
            this.nearestCentroidPredictBtn.Location = new System.Drawing.Point(6, 46);
            this.nearestCentroidPredictBtn.Name = "nearestCentroidPredictBtn";
            this.nearestCentroidPredictBtn.Size = new System.Drawing.Size(164, 23);
            this.nearestCentroidPredictBtn.TabIndex = 0;
            this.nearestCentroidPredictBtn.Text = "Translate and Predict";
            this.nearestCentroidPredictBtn.UseVisualStyleBackColor = true;
            this.nearestCentroidPredictBtn.Click += new System.EventHandler(this.nearestCentroidPredictBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.trainAndPredictBtn);
            this.groupBox2.Controls.Add(this.predictSGDBtn);
            this.groupBox2.Location = new System.Drawing.Point(261, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 111);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SGD";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Train validate predict (hierarchical)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trainAndPredictBtn
            // 
            this.trainAndPredictBtn.Location = new System.Drawing.Point(6, 17);
            this.trainAndPredictBtn.Name = "trainAndPredictBtn";
            this.trainAndPredictBtn.Size = new System.Drawing.Size(188, 23);
            this.trainAndPredictBtn.TabIndex = 1;
            this.trainAndPredictBtn.Text = "Train and predict";
            this.trainAndPredictBtn.UseVisualStyleBackColor = true;
            this.trainAndPredictBtn.Click += new System.EventHandler(this.trainAndPredictBtn_Click);
            // 
            // predictSGDBtn
            // 
            this.predictSGDBtn.Location = new System.Drawing.Point(6, 46);
            this.predictSGDBtn.Name = "predictSGDBtn";
            this.predictSGDBtn.Size = new System.Drawing.Size(188, 23);
            this.predictSGDBtn.TabIndex = 0;
            this.predictSGDBtn.Text = "Train validate predict";
            this.predictSGDBtn.UseVisualStyleBackColor = true;
            this.predictSGDBtn.Click += new System.EventHandler(this.predictSGDBtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rfStemChkbx);
            this.groupBox4.Controls.Add(this.translateAndPredictRFBtn);
            this.groupBox4.Controls.Add(this.minEltsLeafTbx);
            this.groupBox4.Controls.Add(this.minEltLeafLbl);
            this.groupBox4.Location = new System.Drawing.Point(217, 153);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(174, 99);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Decision Tree";
            // 
            // rfStemChkbx
            // 
            this.rfStemChkbx.AutoSize = true;
            this.rfStemChkbx.Location = new System.Drawing.Point(22, 19);
            this.rfStemChkbx.Name = "rfStemChkbx";
            this.rfStemChkbx.Size = new System.Drawing.Size(50, 17);
            this.rfStemChkbx.TabIndex = 2;
            this.rfStemChkbx.Text = "Stem";
            this.rfStemChkbx.UseVisualStyleBackColor = true;
            // 
            // translateAndPredictRFBtn
            // 
            this.translateAndPredictRFBtn.Location = new System.Drawing.Point(6, 64);
            this.translateAndPredictRFBtn.Name = "translateAndPredictRFBtn";
            this.translateAndPredictRFBtn.Size = new System.Drawing.Size(164, 23);
            this.translateAndPredictRFBtn.TabIndex = 8;
            this.translateAndPredictRFBtn.Text = "Translate and predict";
            this.translateAndPredictRFBtn.UseVisualStyleBackColor = true;
            this.translateAndPredictRFBtn.Click += new System.EventHandler(this.translateAndPredictRFBtn_Click);
            // 
            // minEltsLeafTbx
            // 
            this.minEltsLeafTbx.Location = new System.Drawing.Point(6, 41);
            this.minEltsLeafTbx.Margin = new System.Windows.Forms.Padding(2);
            this.minEltsLeafTbx.Name = "minEltsLeafTbx";
            this.minEltsLeafTbx.Size = new System.Drawing.Size(28, 20);
            this.minEltsLeafTbx.TabIndex = 5;
            // 
            // minEltLeafLbl
            // 
            this.minEltLeafLbl.AutoSize = true;
            this.minEltLeafLbl.Location = new System.Drawing.Point(37, 44);
            this.minEltLeafLbl.Name = "minEltLeafLbl";
            this.minEltLeafLbl.Size = new System.Drawing.Size(63, 17);
            this.minEltLeafLbl.TabIndex = 4;
            this.minEltLeafLbl.Text = "MinEltsLeaf";
            this.minEltLeafLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.minEltLeafLbl.UseCompatibleTextRendering = true;
            // 
            // extractColumnBtn
            // 
            this.extractColumnBtn.Location = new System.Drawing.Point(9, 79);
            this.extractColumnBtn.Margin = new System.Windows.Forms.Padding(2);
            this.extractColumnBtn.Name = "extractColumnBtn";
            this.extractColumnBtn.Size = new System.Drawing.Size(91, 19);
            this.extractColumnBtn.TabIndex = 29;
            this.extractColumnBtn.Text = "Extract col";
            this.extractColumnBtn.UseVisualStyleBackColor = true;
            this.extractColumnBtn.Click += new System.EventHandler(this.extractColumnBtn_Click);
            // 
            // extractColumnTbx
            // 
            this.extractColumnTbx.Location = new System.Drawing.Point(105, 79);
            this.extractColumnTbx.Name = "extractColumnTbx";
            this.extractColumnTbx.Size = new System.Drawing.Size(67, 20);
            this.extractColumnTbx.TabIndex = 28;
            this.extractColumnTbx.Text = "3";
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 357);
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
        private System.Windows.Forms.Button predictSGDBtn;
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

