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
using NDSB.Models.SparseModels;
using DataScienceECom;
using DataScienceECom.Phis;
using DataScienceECom.Models;

namespace NDSB
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void processBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(IntPtr.Size.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] nbNeighboursArray = nbNeighbTbx.Text.Split(';').Select(c => Convert.ToInt32(c)).ToArray();

            string trainFilePath = "";
            string validationFilePath = "";

            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Validation file path";
            if (fdlg.ShowDialog() == DialogResult.OK)
                validationFilePath = fdlg.FileName;

            fdlg = new OpenFileDialog();
            fdlg.Title = "Train file(s) path";
            if (fdlg.ShowDialog() == DialogResult.OK)
                trainFilePath = fdlg.FileName;

            double minTfIdf = 0.2;

            List<KNNII> models = new List<KNNII>();
            for (int j = 0; j < nbNeighboursArray.Length; j++)
                models.Add(new KNNII(Distances.Euclide, nbNeighboursArray[j], minTfIdf));

            KNNIIHelper.PrepareDataAndValidateModels(models.ToArray(), new ToSphere(), trainFilePath, validationFilePath);
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

        private void shuffleBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            int[] seeds = shuffleSeedTbx.Text.Split(';').Select(c => Convert.ToInt32(c)).ToArray();

            fdlg.Multiselect = true;
            fdlg.Title = "Files to shuffle";
            string[] filePaths = new string[1];
            if (fdlg.ShowDialog() == DialogResult.OK)
                filePaths = fdlg.FileNames;

            foreach (int seed in seeds)
                for (int i = 0; i < filePaths.Length; i++)
                    FShuffler.Shuffle(filePaths[i], seed);
        }

        private void splitBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            double part = Convert.ToDouble(splitTbx.Text);

            fdlg.Multiselect = true;
            fdlg.Title = "Files to split";
            string[] filePaths = new string[1];
            if (fdlg.ShowDialog() == DialogResult.OK)
                filePaths = fdlg.FileNames;

            for (int i = 0; i < filePaths.Length; i++)
                FSplitter.SplitRelative(filePaths[i], part);
        }

        private void downSampleBtn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Multiselect = true;
            fdlg.Title = "Files to down sample";
            string[] filePaths = new string[1];
            if (fdlg.ShowDialog() == DialogResult.OK)
                filePaths = fdlg.FileNames;

            int[] eltsPerClass = downSampleTbx.Text.Split(';').Select(c => Convert.ToInt32(c)).ToArray();
            for (int i = 0; i < eltsPerClass.Length; i++)
                for (int j = 0; j < filePaths.Length; j++)
                    DownSample.Run(filePaths[j], eltsPerClass[i], DSCdiscountUtils.GetLabelCDiscountDB);
        }

        private void nearestCentroidPredictBtn_Click(object sender, EventArgs e)
        {
            string[] trainFilePaths = new string[1];
            string testFilePath = "";

            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Test file path";
            if (fdlg.ShowDialog() == DialogResult.OK)
                testFilePath = fdlg.FileName;

            fdlg = new OpenFileDialog();
            fdlg.Multiselect = true;
            fdlg.Title = "Train file(s) path";
            if (fdlg.ShowDialog() == DialogResult.OK)
                trainFilePaths = fdlg.FileNames;

            for (int i = 0; i < trainFilePaths.Length; i++)
            {
                List<NearestCentroid> models = new List<NearestCentroid>();
                models.Add(new NearestCentroid(new PureInteractions(1, 20)));
                NearestCentroidHelper.TrainPredictAndWrite(models.ToArray(), trainFilePaths[i], testFilePath);
                models.Clear();
            }
        }

        private void getHistogramBtn_Click(object sender, EventArgs e)
        {
            string trainFilePath = "";
            OpenFileDialog fdlg = new OpenFileDialog();

            if (fdlg.ShowDialog() == DialogResult.OK)
                trainFilePath = fdlg.FileName;

            int[] labels = DSCdiscountUtils.ReadLabelsFromTraining(trainFilePath);

            EmpiricScore es = new EmpiricScore();
            for (int i = 0; i < labels.Length; i++)
                es.UpdateKey(labels[i], 1);

            es = es.Normalize();

            string[] text = es.Scores.OrderBy(c => c.Value).Select(c => c.Key + " " + c.Value).ToArray();
            File.WriteAllLines(trainFilePath.Split('.')[0] + "_hist.txt", text);

            MessageBox.Show("h");
        }

        private void predictSGDBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog trainingFilesOFD = new OpenFileDialog();
            trainingFilesOFD.Multiselect = true;
            trainingFilesOFD.Title = "Train files path";
            trainingFilesOFD.ShowDialog();
            if (!trainingFilesOFD.CheckFileExists) return;

            OpenFileDialog validationFilesOFD = new OpenFileDialog();
            validationFilesOFD.Multiselect = true;
            trainingFilesOFD.Title = "Validation files path";
            validationFilesOFD.ShowDialog();

            if (!validationFilesOFD.CheckFileExists) return;

            string currentDirectory = Path.GetDirectoryName(trainingFilesOFD.FileNames[0]),
                testFilePath = currentDirectory + "\\test.csv",
                cvFilePath = currentDirectory + "\\CrossValidation.csv";

            List<Phi> phis = new List<Phi> { Phis.phi13 };

            string[] learningFiles = trainingFilesOFD.FileNames;
            Array.Sort(learningFiles);
            string[] validationFiles = validationFilesOFD.FileNames;
            Array.Sort(validationFiles);

            foreach (IStreamingModel model in ModelGenerators.Entropia5())
                for (int i = 0; i < learningFiles.Length; i++)
                    foreach (Phi phi in phis)
                    {
                        string file = learningFiles[i];
                        model.ClearModel();
                        TrainModels.TrainStreamingModel(model, phi, file);
                        string modelString = Path.GetFileNameWithoutExtension(file) + ";" + Path.GetFileNameWithoutExtension(validationFiles[i]) +
                            phi.Method.Name + ";" + model.ToString();

                        List<int> testModelPredictions = TrainModels.Predict(model, phi, testFilePath);

                        File.WriteAllLines(Path.GetDirectoryName(file) + "\\submissions\\" +
                            modelString + "_pred.csv",
                            testModelPredictions.Select(t => t.ToString()));

                        string validationFileName = validationFiles[i];

                        var validationModelPredictions = TrainModels.Validate(model, phi, validationFileName);

                        File.WriteAllLines(Path.GetDirectoryName(file) + "\\validations\\" +
                            modelString + "_val.csv",
                            validationModelPredictions.Item1.Select(t => t.ToString()));

                        File.AppendAllText(cvFilePath, modelString + ";" + (validationModelPredictions.Item2 * 100f).ToString() + Environment.NewLine);
                    }
        }

        private void predictKNNBtn_Click(object sender, EventArgs e)
        {
            int[] nbNeighboursArray = nbNeighbTbx.Text.Split(';').Select(c => Convert.ToInt32(c)).ToArray();

            string[] trainFilePaths = new string[1];
            string testFilePath = "";

            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Test file path";
            if (fdlg.ShowDialog() == DialogResult.OK)
                testFilePath = fdlg.FileName;

            fdlg = new OpenFileDialog();
            fdlg.Multiselect = true;
            fdlg.Title = "Train file(s) path";
            if (fdlg.ShowDialog() == DialogResult.OK)
                trainFilePaths = fdlg.FileNames;

            double minTfIdf = 0.25;

            for (int i = 0; i < trainFilePaths.Length; i++)
            {
                List<KNNII> models = new List<KNNII>();
                for (int j = 0; j < nbNeighboursArray.Length; j++)
                    models.Add(new KNNII(Distances.Euclide, nbNeighboursArray[j], minTfIdf));
                KNNIIHelper.PrepareDataAndWritePredictions(models.ToArray(), new ToSphere(), trainFilePaths[i], testFilePath);
            }
        }

        private void splitTbx_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
