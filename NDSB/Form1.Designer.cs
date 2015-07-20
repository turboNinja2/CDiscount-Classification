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
            this.trainFileLbl = new System.Windows.Forms.Label();
            this.testFileLbl = new System.Windows.Forms.Label();
            this.loadTrainBtn = new System.Windows.Forms.Button();
            this.loadTestBtn = new System.Windows.Forms.Button();
            this.trainPathTbx = new System.Windows.Forms.TextBox();
            this.testPathTbx = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelsTbx = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.runBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.processBtn = new System.Windows.Forms.Button();
            this.runPegasosBtn = new System.Windows.Forms.Button();
            this.maxOccurencesOfClassTbx = new System.Windows.Forms.TextBox();
            this.nbNeighboursTbx = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nbNeighbTbx = new System.Windows.Forms.TextBox();
            this.maxEltsPerClassTbx = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // trainFileLbl
            // 
            this.trainFileLbl.AutoSize = true;
            this.trainFileLbl.Location = new System.Drawing.Point(11, 22);
            this.trainFileLbl.Name = "trainFileLbl";
            this.trainFileLbl.Size = new System.Drawing.Size(53, 13);
            this.trainFileLbl.TabIndex = 0;
            this.trainFileLbl.Text = "Train File ";
            // 
            // testFileLbl
            // 
            this.testFileLbl.AutoSize = true;
            this.testFileLbl.Location = new System.Drawing.Point(11, 49);
            this.testFileLbl.Name = "testFileLbl";
            this.testFileLbl.Size = new System.Drawing.Size(50, 13);
            this.testFileLbl.TabIndex = 1;
            this.testFileLbl.Text = "Test File ";
            // 
            // loadTrainBtn
            // 
            this.loadTrainBtn.Location = new System.Drawing.Point(70, 17);
            this.loadTrainBtn.Name = "loadTrainBtn";
            this.loadTrainBtn.Size = new System.Drawing.Size(75, 23);
            this.loadTrainBtn.TabIndex = 2;
            this.loadTrainBtn.Text = "Load";
            this.loadTrainBtn.UseVisualStyleBackColor = true;
            this.loadTrainBtn.Click += new System.EventHandler(this.loadTrainBtn_Click);
            // 
            // loadTestBtn
            // 
            this.loadTestBtn.Location = new System.Drawing.Point(70, 44);
            this.loadTestBtn.Name = "loadTestBtn";
            this.loadTestBtn.Size = new System.Drawing.Size(75, 23);
            this.loadTestBtn.TabIndex = 3;
            this.loadTestBtn.Text = "Load";
            this.loadTestBtn.UseVisualStyleBackColor = true;
            this.loadTestBtn.Click += new System.EventHandler(this.loadTestBtn_Click);
            // 
            // trainPathTbx
            // 
            this.trainPathTbx.Location = new System.Drawing.Point(151, 17);
            this.trainPathTbx.Name = "trainPathTbx";
            this.trainPathTbx.Size = new System.Drawing.Size(342, 20);
            this.trainPathTbx.TabIndex = 4;
            // 
            // testPathTbx
            // 
            this.testPathTbx.Location = new System.Drawing.Point(151, 45);
            this.testPathTbx.Name = "testPathTbx";
            this.testPathTbx.Size = new System.Drawing.Size(342, 20);
            this.testPathTbx.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelsTbx);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.testPathTbx);
            this.groupBox1.Controls.Add(this.trainPathTbx);
            this.groupBox1.Controls.Add(this.loadTestBtn);
            this.groupBox1.Controls.Add(this.loadTrainBtn);
            this.groupBox1.Controls.Add(this.testFileLbl);
            this.groupBox1.Controls.Add(this.trainFileLbl);
            this.groupBox1.Location = new System.Drawing.Point(66, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 95);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Path";
            // 
            // labelsTbx
            // 
            this.labelsTbx.Location = new System.Drawing.Point(151, 73);
            this.labelsTbx.Name = "labelsTbx";
            this.labelsTbx.Size = new System.Drawing.Size(342, 20);
            this.labelsTbx.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(70, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Labels File ";
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(69, 74);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(89, 23);
            this.runBtn.TabIndex = 6;
            this.runBtn.Text = "Run KNN";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Extract TFIDF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(69, 15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "DownSample";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            // runPegasosBtn
            // 
            this.runPegasosBtn.Location = new System.Drawing.Point(69, 98);
            this.runPegasosBtn.Name = "runPegasosBtn";
            this.runPegasosBtn.Size = new System.Drawing.Size(89, 23);
            this.runPegasosBtn.TabIndex = 12;
            this.runPegasosBtn.Text = "Run Pegasos";
            this.runPegasosBtn.UseVisualStyleBackColor = true;
            // 
            // maxOccurencesOfClassTbx
            // 
            this.maxOccurencesOfClassTbx.Location = new System.Drawing.Point(17, 18);
            this.maxOccurencesOfClassTbx.Name = "maxOccurencesOfClassTbx";
            this.maxOccurencesOfClassTbx.Size = new System.Drawing.Size(50, 20);
            this.maxOccurencesOfClassTbx.TabIndex = 13;
            // 
            // nbNeighboursTbx
            // 
            this.nbNeighboursTbx.Location = new System.Drawing.Point(17, 76);
            this.nbNeighboursTbx.Name = "nbNeighboursTbx";
            this.nbNeighboursTbx.Size = new System.Drawing.Size(50, 20);
            this.nbNeighboursTbx.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(69, 127);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Run Rocchio";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maxOccurencesOfClassTbx);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.runBtn);
            this.groupBox2.Controls.Add(this.nbNeighboursTbx);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.runPegasosBtn);
            this.groupBox2.Location = new System.Drawing.Point(66, 135);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(177, 159);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Obsolete";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.nbNeighbTbx);
            this.groupBox3.Controls.Add(this.maxEltsPerClassTbx);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Location = new System.Drawing.Point(277, 150);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(299, 134);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Latest";
            this.groupBox3.UseCompatibleTextRendering = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(225, 72);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(56, 19);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Elements Per Sample";
            // 
            // nbNeighbTbx
            // 
            this.nbNeighbTbx.Location = new System.Drawing.Point(115, 40);
            this.nbNeighbTbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nbNeighbTbx.Name = "nbNeighbTbx";
            this.nbNeighbTbx.Size = new System.Drawing.Size(76, 20);
            this.nbNeighbTbx.TabIndex = 2;
            // 
            // maxEltsPerClassTbx
            // 
            this.maxEltsPerClassTbx.Location = new System.Drawing.Point(115, 17);
            this.maxEltsPerClassTbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.maxEltsPerClassTbx.Name = "maxEltsPerClassTbx";
            this.maxEltsPerClassTbx.Size = new System.Drawing.Size(76, 20);
            this.maxEltsPerClassTbx.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(194, 16);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 41);
            this.button5.TabIndex = 0;
            this.button5.Text = "KNN + NCs";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 103);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 361);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.processBtn);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label trainFileLbl;
        private System.Windows.Forms.Label testFileLbl;
        private System.Windows.Forms.Button loadTrainBtn;
        private System.Windows.Forms.Button loadTestBtn;
        private System.Windows.Forms.TextBox trainPathTbx;
        private System.Windows.Forms.TextBox testPathTbx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox labelsTbx;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button processBtn;
        private System.Windows.Forms.Button runPegasosBtn;
        private System.Windows.Forms.TextBox maxOccurencesOfClassTbx;
        private System.Windows.Forms.TextBox nbNeighboursTbx;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nbNeighbTbx;
        private System.Windows.Forms.TextBox maxEltsPerClassTbx;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

