using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDSB.SparseMethods;
using NDSB.FileUtils;
using NDSB.SparseMappings;
using NDSB.Models;

namespace NDSB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void processBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(IntPtr.Size.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int nbNeighbours = Convert.ToInt32(nbNeighbTbx.Text);

            string[] trainFilePaths = new string[1];
            string validationFilePath = "";

            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Validation file path";
            if (fdlg.ShowDialog() == DialogResult.OK)
                validationFilePath = fdlg.FileName;

            fdlg = new OpenFileDialog();
            fdlg.Multiselect = true;
            fdlg.Title = "Train file path";
            if (fdlg.ShowDialog() == DialogResult.OK)
                trainFilePaths = fdlg.FileNames;

            NearestCentroid[] models = new NearestCentroid[] { new NearestCentroid(new PureInteractions(2, 20)), new NearestCentroid(new PureInteractions(1, 25)) };

            for (int i = 0; i < trainFilePaths.Length; i++)
                SparseClassificationHelper.PrepareDataAndValidateModels(models, trainFilePaths[i], validationFilePath);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Multiselect = true;
            fdlg.Title = "Files to merge";
            string[] filePaths = new string[1];
            if (fdlg.ShowDialog() == DialogResult.OK)
                filePaths = fdlg.FileNames;

            CSVHelper.ColumnBind(filePaths);
        }

        private void shuffleAndSplitBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Multiselect = true;
            fdlg.Title = "Files to merge";
            string[] filePaths = new string[1];
            if (fdlg.ShowDialog() == DialogResult.OK)
                filePaths = fdlg.FileNames;

            for (int i = 0; i < filePaths.Length; i++)
            {
                string shuffledFilePath = FShuffler.Shuffle(filePaths[i], 0);
                FSplitter.Split(shuffledFilePath, 15700000);
            }
        }

        private void downSampleBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Multiselect = true;
            fdlg.Title = "Files to merge";
            string[] filePaths = new string[1];
            if (fdlg.ShowDialog() == DialogResult.OK)
                filePaths = fdlg.FileNames;

            int[] eltsPerClass = downSampleTbx.Text.Split(';').Select(c => Convert.ToInt32(c)).ToArray();
            for (int i = 0; i < eltsPerClass.Length; i++)
                for (int j = 0; j < filePaths.Length; j++)
                    DownSample.Run(filePaths[j], eltsPerClass[i], DSCdiscountUtils.GetLabelCDiscountDB);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

    }
}
