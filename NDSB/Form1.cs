using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NDSB.SparseMethods;

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

            Dictionary<string, double>[] trainPoints = CSRHelper.ImportPoints(trainPathTbx.Text);
            Dictionary<string, double>[] testPoints = CSRHelper.ImportPoints(testPathTbx.Text);
            int[] labels = DSCdiscountUtils.ReadLabels(labelsTbx.Text);

            string outfileName = Path.GetDirectoryName(trainPathTbx.Text) + "\\" + Path.GetFileNameWithoutExtension(trainPathTbx.Text) + "_pred.txt";
            string[] predicted = new string[testPoints.Count()];

            for(int i =0; i < trainPoints.Length; i++)
                trainPoints[i] = SparseNormalizations.ToCube(trainPoints[i]);

            for (int i = 0; i < testPoints.Length; i++)
            {
                int[] pred = SparseKNN.NearestNeighbours(labels, trainPoints, SparseNormalizations.ToCube(testPoints[i]), 10, SparseDistances.ManhattanDistance);
                predicted[i] = String.Join(";",pred);
            }
            File.AppendAllText(outfileName, String.Join(Environment.NewLine, predicted));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DSCdiscountUtils.TextToTFIDFCSR(testPathTbx.Text);
            DSCdiscountUtils.TextToTFIDFCSR(trainPathTbx.Text);
            DSCdiscountUtils.ExtractLabelsFromTraining(trainPathTbx.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                labelsTbx.Text = fdlg.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DownSample.Run(trainPathTbx.Text, 200, DSCdiscountUtils.GetLabel);
        }


    }
}
