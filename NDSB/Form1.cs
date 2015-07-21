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
                DirtyHelpers.RunKNN(trainFilePaths[i], testFilePath, nbNeighbours, maxEltsPerClass);
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

    }
}
