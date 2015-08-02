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
            this.predictKNNBtn = new System.Windows.Forms.Button();
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
            this.getHistogramBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.predictSGDBtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nTreesTbx = new System.Windows.Forms.TextBox();
            this.nTreesLbl = new System.Windows.Forms.Label();
            this.minEltsLeafTbx = new System.Windows.Forms.TextBox();
            this.minEltLeafLbl = new System.Windows.Forms.Label();
            this.maxDepthLbl = new System.Windows.Forms.Label();
            this.maxDepthTbx = new System.Windows.Forms.TextBox();
            this.decisionTreePredictBtn = new System.Windows.Forms.Button();
            this.translateAndPredictRFBtn = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // processBtn
            // 
            this.processBtn.Location = new System.Drawing.Point(653, 42);
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
            this.groupBox3.Controls.Add(this.predictKNNBtn);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.nbNeighbTbx);
            this.groupBox3.Controls.Add(this.validateKNNBtn);
            this.groupBox3.Location = new System.Drawing.Point(15, 178);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(271, 127);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "KNN";
            this.groupBox3.UseCompatibleTextRendering = true;
            // 
            // predictKNNBtn
            // 
            this.predictKNNBtn.Location = new System.Drawing.Point(5, 81);
            this.predictKNNBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.predictKNNBtn.Name = "predictKNNBtn";
            this.predictKNNBtn.Size = new System.Drawing.Size(251, 25);
            this.predictKNNBtn.TabIndex = 5;
            this.predictKNNBtn.Text = "Predict";
            this.predictKNNBtn.UseVisualStyleBackColor = true;
            this.predictKNNBtn.Click += new System.EventHandler(this.predictKNNBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nb neighbours (KNN)";
            // 
            // nbNeighbTbx
            // 
            this.nbNeighbTbx.Location = new System.Drawing.Point(155, 28);
            this.nbNeighbTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nbNeighbTbx.Name = "nbNeighbTbx";
            this.nbNeighbTbx.Size = new System.Drawing.Size(100, 22);
            this.nbNeighbTbx.TabIndex = 2;
            // 
            // validateKNNBtn
            // 
            this.validateKNNBtn.Location = new System.Drawing.Point(5, 52);
            this.validateKNNBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.validateKNNBtn.Name = "validateKNNBtn";
            this.validateKNNBtn.Size = new System.Drawing.Size(251, 25);
            this.validateKNNBtn.TabIndex = 0;
            this.validateKNNBtn.Text = "CV";
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
            this.splitTbx.TextChanged += new System.EventHandler(this.splitTbx_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nearestCentroidPredictBtn);
            this.groupBox1.Location = new System.Drawing.Point(293, 178);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(267, 123);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nearest Centroids";
            // 
            // nearestCentroidPredictBtn
            // 
            this.nearestCentroidPredictBtn.Location = new System.Drawing.Point(8, 52);
            this.nearestCentroidPredictBtn.Margin = new System.Windows.Forms.Padding(4);
            this.nearestCentroidPredictBtn.Name = "nearestCentroidPredictBtn";
            this.nearestCentroidPredictBtn.Size = new System.Drawing.Size(100, 28);
            this.nearestCentroidPredictBtn.TabIndex = 0;
            this.nearestCentroidPredictBtn.Text = "Predict";
            this.nearestCentroidPredictBtn.UseVisualStyleBackColor = true;
            this.nearestCentroidPredictBtn.Click += new System.EventHandler(this.nearestCentroidPredictBtn_Click);
            // 
            // getHistogramBtn
            // 
            this.getHistogramBtn.Location = new System.Drawing.Point(12, 128);
            this.getHistogramBtn.Margin = new System.Windows.Forms.Padding(4);
            this.getHistogramBtn.Name = "getHistogramBtn";
            this.getHistogramBtn.Size = new System.Drawing.Size(216, 28);
            this.getHistogramBtn.TabIndex = 27;
            this.getHistogramBtn.Text = "Histogram";
            this.getHistogramBtn.UseVisualStyleBackColor = true;
            this.getHistogramBtn.Click += new System.EventHandler(this.getHistogramBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.predictSGDBtn);
            this.groupBox2.Location = new System.Drawing.Point(293, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(267, 130);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SGD";
            // 
            // predictSGDBtn
            // 
            this.predictSGDBtn.Location = new System.Drawing.Point(8, 52);
            this.predictSGDBtn.Margin = new System.Windows.Forms.Padding(4);
            this.predictSGDBtn.Name = "predictSGDBtn";
            this.predictSGDBtn.Size = new System.Drawing.Size(100, 28);
            this.predictSGDBtn.TabIndex = 0;
            this.predictSGDBtn.Text = "Predict";
            this.predictSGDBtn.UseVisualStyleBackColor = true;
            this.predictSGDBtn.Click += new System.EventHandler(this.predictSGDBtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.translateAndPredictRFBtn);
            this.groupBox4.Controls.Add(this.nTreesTbx);
            this.groupBox4.Controls.Add(this.nTreesLbl);
            this.groupBox4.Controls.Add(this.minEltsLeafTbx);
            this.groupBox4.Controls.Add(this.minEltLeafLbl);
            this.groupBox4.Controls.Add(this.maxDepthLbl);
            this.groupBox4.Controls.Add(this.maxDepthTbx);
            this.groupBox4.Controls.Add(this.decisionTreePredictBtn);
            this.groupBox4.Location = new System.Drawing.Point(568, 116);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(267, 190);
            this.groupBox4.TabIndex = 27;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Decision Tree";
            // 
            // nTreesTbx
            // 
            this.nTreesTbx.Location = new System.Drawing.Point(97, 74);
            this.nTreesTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nTreesTbx.Name = "nTreesTbx";
            this.nTreesTbx.Size = new System.Drawing.Size(100, 22);
            this.nTreesTbx.TabIndex = 7;
            // 
            // nTreesLbl
            // 
            this.nTreesLbl.AutoSize = true;
            this.nTreesLbl.Location = new System.Drawing.Point(32, 77);
            this.nTreesLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nTreesLbl.Name = "nTreesLbl";
            this.nTreesLbl.Size = new System.Drawing.Size(47, 20);
            this.nTreesLbl.TabIndex = 6;
            this.nTreesLbl.Text = "nTrees";
            this.nTreesLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.nTreesLbl.UseCompatibleTextRendering = true;
            // 
            // minEltsLeafTbx
            // 
            this.minEltsLeafTbx.Location = new System.Drawing.Point(97, 48);
            this.minEltsLeafTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minEltsLeafTbx.Name = "minEltsLeafTbx";
            this.minEltsLeafTbx.Size = new System.Drawing.Size(100, 22);
            this.minEltsLeafTbx.TabIndex = 5;
            // 
            // minEltLeafLbl
            // 
            this.minEltLeafLbl.AutoSize = true;
            this.minEltLeafLbl.Location = new System.Drawing.Point(4, 52);
            this.minEltLeafLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minEltLeafLbl.Name = "minEltLeafLbl";
            this.minEltLeafLbl.Size = new System.Drawing.Size(75, 20);
            this.minEltLeafLbl.TabIndex = 4;
            this.minEltLeafLbl.Text = "MinEltsLeaf";
            this.minEltLeafLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.minEltLeafLbl.UseCompatibleTextRendering = true;
            // 
            // maxDepthLbl
            // 
            this.maxDepthLbl.AutoSize = true;
            this.maxDepthLbl.Location = new System.Drawing.Point(15, 25);
            this.maxDepthLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.maxDepthLbl.Name = "maxDepthLbl";
            this.maxDepthLbl.Size = new System.Drawing.Size(71, 17);
            this.maxDepthLbl.TabIndex = 3;
            this.maxDepthLbl.Text = "MaxDepth";
            // 
            // maxDepthTbx
            // 
            this.maxDepthTbx.Location = new System.Drawing.Point(97, 21);
            this.maxDepthTbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maxDepthTbx.Name = "maxDepthTbx";
            this.maxDepthTbx.Size = new System.Drawing.Size(100, 22);
            this.maxDepthTbx.TabIndex = 2;
            // 
            // decisionTreePredictBtn
            // 
            this.decisionTreePredictBtn.Location = new System.Drawing.Point(97, 143);
            this.decisionTreePredictBtn.Margin = new System.Windows.Forms.Padding(4);
            this.decisionTreePredictBtn.Name = "decisionTreePredictBtn";
            this.decisionTreePredictBtn.Size = new System.Drawing.Size(100, 28);
            this.decisionTreePredictBtn.TabIndex = 0;
            this.decisionTreePredictBtn.Text = "Predict";
            this.decisionTreePredictBtn.UseVisualStyleBackColor = true;
            this.decisionTreePredictBtn.Click += new System.EventHandler(this.decisionTreePredictBtn_Click);
            // 
            // translateAndPredictRFBtn
            // 
            this.translateAndPredictRFBtn.Location = new System.Drawing.Point(97, 107);
            this.translateAndPredictRFBtn.Margin = new System.Windows.Forms.Padding(4);
            this.translateAndPredictRFBtn.Name = "translateAndPredictRFBtn";
            this.translateAndPredictRFBtn.Size = new System.Drawing.Size(100, 28);
            this.translateAndPredictRFBtn.TabIndex = 8;
            this.translateAndPredictRFBtn.Text = "Translate and predict";
            this.translateAndPredictRFBtn.UseVisualStyleBackColor = true;
            this.translateAndPredictRFBtn.Click += new System.EventHandler(this.translateAndPredictRFBtn_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 319);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.getHistogramBtn);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainScreen";
            this.Text = "Form1";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.Button getHistogramBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button predictSGDBtn;
        private System.Windows.Forms.Button predictKNNBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button decisionTreePredictBtn;
        private System.Windows.Forms.TextBox maxDepthTbx;
        private System.Windows.Forms.TextBox minEltsLeafTbx;
        private System.Windows.Forms.Label minEltLeafLbl;
        private System.Windows.Forms.Label maxDepthLbl;
        private System.Windows.Forms.TextBox nTreesTbx;
        private System.Windows.Forms.Label nTreesLbl;
        private System.Windows.Forms.Button translateAndPredictRFBtn;
    }
}

