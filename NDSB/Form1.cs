using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDSB.SparseMethods;
using NDSB.FileUtils;
using NDSB.SparseMappings;

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
                trainPathTbx.Text = fdlg.FileName;
        }

        private void loadTestBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            if (fdlg.ShowDialog() == DialogResult.OK)
                testPathTbx.Text = fdlg.FileName;
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            int nbNeighbours = Convert.ToInt32(nbNeighboursTbx.Text);

            Dictionary<string, double>[] trainPoints = CSRHelper.ImportPoints(trainPathTbx.Text);
            Dictionary<string, double>[] testPoints = CSRHelper.ImportPoints(testPathTbx.Text);
            int[] labels = DSCdiscountUtils.ReadLabels(labelsTbx.Text);

            string outfileName = Path.GetDirectoryName(trainPathTbx.Text) + "\\" + Path.GetFileNameWithoutExtension(trainPathTbx.Text) + "_knn_pred.txt";
            string[] predicted = new string[testPoints.Count()];

            for (int i = 0; i < trainPoints.Length; i++)
                trainPoints[i] = LinearSpace.ToCube(trainPoints[i]);


            /*
            KNNII.StampInverseDictionary(trainPoints, 0.5);

            Parallel.For(0, testPoints.Length, i =>
            {
                int[] pred = KNNII.NearestNeighbours(labels, trainPoints, LinearSpace.ToCube(testPoints[i]), nbNeighbours, MetricSpace.ManhattanDistance);
                predicted[i] = String.Join(";", pred);
            });
             */
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
                labelsTbx.Text = fdlg.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DownSample.Split(trainPathTbx.Text,
                Convert.ToInt32(maxOccurencesOfClassTbx.Text),
                DSCdiscountUtils.GetLabelCDiscountDB);
        }

        private void processBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(IntPtr.Size.ToString());
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Dictionary<string, double>[] trainPoints = CSRHelper.ImportPoints(trainPathTbx.Text);
            Dictionary<string, double>[] testPoints = CSRHelper.ImportPoints(testPathTbx.Text);
            int[] labels = DSCdiscountUtils.ReadLabels(labelsTbx.Text);

            string outfileName = Path.GetDirectoryName(trainPathTbx.Text) + "\\" + Path.GetFileNameWithoutExtension(trainPathTbx.Text) + "_centroid_pred.txt";

            NearestCentroid sr = new NearestCentroid(new Identity<Dictionary<string, double>>());
            sr.Train(labels, trainPoints);

            string[] predicted = new string[testPoints.Count()];
            Parallel.For(0, testPoints.Length, i =>
            //for(int i =0; i < testPoints.Length; i++)
            {
                int pred = sr.Predict(testPoints[i]);
                predicted[i] = String.Join(";", pred);
            });
            File.AppendAllText(outfileName, String.Join(Environment.NewLine, predicted));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int maxEltsPerClass = Convert.ToInt32(maxEltsPerClassTbx.Text),
                nbNeighbours = Convert.ToInt32(nbNeighbTbx.Text);

            string[] trainFilePaths = new string[1];
            string testFilePath = "";


            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Test file path";
            if (fdlg.ShowDialog() == DialogResult.OK)
                testFilePath = fdlg.FileName;

            fdlg = new OpenFileDialog();
            fdlg.Multiselect = true;
            fdlg.Title = "Train file path";
            if (fdlg.ShowDialog() == DialogResult.OK)
                trainFilePaths = fdlg.FileNames;

            for (int i = 0; i < trainFilePaths.Length; i++)
                MLHelper.TFIDFTrainAndPredict(maxEltsPerClass, nbNeighbours, trainFilePaths[i], testFilePath);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Multiselect = true;
            fdlg.Title = "Files to merge";
            string[] filePaths = new string[1];
            if (fdlg.ShowDialog() == DialogResult.OK)
                filePaths = fdlg.FileNames;

            CSVHelper.MergeToOneFile(filePaths);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string dsFilePath = DownSample.Split(trainPathTbx.Text,
                Convert.ToInt32(maxEltsPerClassTbx.Text),
                DSCdiscountUtils.GetLabelCDiscountDB);
            LIBSVMHelper.Convert(dsFilePath, DSCdiscountUtils.GetLabelCDiscountDB);
            LIBSVMHelper.Convert(testPathTbx.Text, c => "0");
        }
    }
}
