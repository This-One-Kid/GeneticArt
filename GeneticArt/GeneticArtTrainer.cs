using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticArt
{
    public class GeneticArtTrainer
    {
        TriangleArt[] population;
        double bestError = double.MaxValue;
        public static int width;
        public static int height;
        public GeneticArtTrainer(Bitmap originalImage, int maxTriangles, int populationSize, bool cloneArrays)
        {
            population = new TriangleArt[populationSize];
            width = originalImage.Width;
            height = originalImage.Height;
            for (var i = 0; i < populationSize; i++)
            {
                population[i] = new TriangleArt(maxTriangles, originalImage, cloneArrays);
            }
        }

        public override bool Equals(object obj)
        {
            return population.SequenceEqual(((GeneticArtTrainer)obj).population);
        }

        public (double, Bitmap) Train(Random rand)
        {
            (int ind, double error, Bitmap bitmap) lowestErrorInd = GetBestImage();
            // double lowestError = lowestErrorInd.error;
            for (var i = 0; i < population.Length; i++)
            {
                if (i == lowestErrorInd.ind) continue;

                population[lowestErrorInd.ind].CopyTo(population[i]);
                population[i].Mutate(rand);
            }
            //lowestErrorInd = GetBestImage();

            return (lowestErrorInd.error, population[lowestErrorInd.ind].curDrawnImage);
        }
        public (int, double, Bitmap) GetBestImage()
        {
            double lowestError = population[0].GetError();
            int ind = 0;
            //Parallel.For(0, population.Length, new Action<int>
            for (var i = 1; i < population.Length; i++)
            {
                double triError = population[i].GetError();
                if (triError < lowestError)
                {
                    lowestError = triError;
                    ind = i;
                }                
            }
            return (ind, lowestError, population[ind].curDrawnImage);//doing this for now, if it doesn't work then change to " population[ind].curDrawnImage;"
        }
        public void SetOGImage(Bitmap newImage)
        {
            for (var i = 0; i < population.Length; i++)
            {
                population[i].originalImage = newImage;
            }
        }
    }
}
