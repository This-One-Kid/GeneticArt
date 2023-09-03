using System.Text.Json.Serialization;


namespace GeneticArt
{
    public partial class Form1 : Form
    {
        public static Random rand = new Random(5);
        //public static Random cloneRand = new Random(5);

        public static GeneticArtTrainer artTrainer = null;
        public static bool autoTrain = false;

        static GeneticArtTrainer clonetrainer;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void inputImage_Click(object sender, EventArgs e)
        {

            //  Graphics gfx = Graphics.FromImage(InputImage.Image);
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*jpg;*jpeg;*png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //img save
                inputImage.Image = new Bitmap(openFileDialog1.FileName);
                if (artTrainer == null)
                {
                    const int maxTriangles = 150;
                    const int popSize = 50;
                    artTrainer = new GeneticArtTrainer((Bitmap)inputImage.Image, maxTriangles, popSize, false);
                    //clonetrainer = new GeneticArtTrainer((Bitmap)inputImage.Image, maxTriangles, popSize, true);
                }
                else
                {
                    artTrainer.SetOGImage((Bitmap)inputImage.Image);
                }
            }
        }

        private void trainButton_Click(object sender, EventArgs e)
        {
            autoTrain = !autoTrain;
            if (autoTrain)
            {
                trainButton.Text = "Stop";
            }
            else
            {
                trainButton.Text = "Start";
            }
        }

        private void autoTimer_Tick(object sender, EventArgs e)
        {
            if (autoTrain)
            {
                //Action bob = () => { };
                //int a = 0;
                //List<int> b = new List<int>()
                //{ 0 };

                Action<int> act = (a) => { var img = artTrainer.Train(rand); AIPic1.Image = img.Item2; };

                //Parallel.For(0, 10, act);//TODO: Modify bitmap inside for
                var img = artTrainer.Train(rand);//Parallel.For(0, 10, artTrainer.Train(rand));
                for (var i = 0; i < 10; i++)
                {
                    img = artTrainer.Train(rand);
                }//capture train
                AIPic1.Image = img.Item2;
                //AIPic2.Image = clonetrainer.Train(cloneRand).Item2;
                //var a = artTrainer.Equals(clonetrainer);
                ;
                
            }
        }
    }
}