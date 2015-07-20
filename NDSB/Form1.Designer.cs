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
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nbNeighbTbx = new System.Windows.Forms.TextBox();
            this.maxEltsPerClassTbx = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
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
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.nbNeighbTbx);
            this.groupBox3.Controls.Add(this.maxEltsPerClassTbx);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Location = new System.Drawing.Point(49, 23);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(299, 134);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Latest";
            this.groupBox3.UseCompatibleTextRendering = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 103);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(225, 72);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
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
            this.nbNeighbTbx.Margin = new System.Windows.Forms.Padding(2);
            this.nbNeighbTbx.Name = "nbNeighbTbx";
            this.nbNeighbTbx.Size = new System.Drawing.Size(76, 20);
            this.nbNeighbTbx.TabIndex = 2;
            // 
            // maxEltsPerClassTbx
            // 
            this.maxEltsPerClassTbx.Location = new System.Drawing.Point(115, 17);
            this.maxEltsPerClassTbx.Margin = new System.Windows.Forms.Padding(2);
            this.maxEltsPerClassTbx.Name = "maxEltsPerClassTbx";
            this.maxEltsPerClassTbx.Size = new System.Drawing.Size(76, 20);
            this.maxEltsPerClassTbx.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(194, 16);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 41);
            this.button5.TabIndex = 0;
            this.button5.Text = "KNN + NCs";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 252);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.processBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button processBtn;
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

