using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace NDSB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadTrainBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                trainPathTbx.Text = fdlg.FileName;
            }
        }

        private void loadTestBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                testPathTbx.Text = fdlg.FileName;
            }
        }

        private void runBtn_Click(object sender, EventArgs e)
        {

            Dictionary<string, double>[] trainPoints = FileTransform.ImportPoints(trainPathTbx.Text);
            Dictionary<string, double>[] testPoints = FileTransform.ImportPoints(testPathTbx.Text);
            int[] labels = FileTransform.ImportLabels(labelsTbx.Text);

            string outfileName = Path.GetDirectoryName(trainPathTbx.Text) + "\\" + Path.GetFileNameWithoutExtension(trainPathTbx.Text) + "_pred.txt";
            string[] predicted = new string[testPoints.Count()];

            for(int i =0; i < trainPoints.Length; i++)
                trainPoints[i] = SparseKNN.ToCube(trainPoints[i]);

            for (int i = 0; i < testPoints.Length; i++)
            {
                int pred = SparseKNN.Predict(labels, trainPoints, SparseKNN.ToCube(testPoints[i]), 10);
                predicted[i] = pred.ToString();
            }
            File.AppendAllText(outfileName, String.Join(Environment.NewLine, predicted));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FileTransform.ExtractLabels(trainPathTbx.Text, 1000000);
            FileTransform.TextToSparseData(testPathTbx.Text, 1000000);
            FileTransform.TextToSparseData(trainPathTbx.Text, 1000000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                labelsTbx.Text = fdlg.FileName;
            }
        }

        private void cleanDataBtn_Click(object sender, EventArgs e)
        {
            CrowdFlowerFormatting.CleanFile(trainPathTbx.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CrowdFlowerFormatting.ExtractLabels(trainPathTbx.Text);
        }

    }
}
