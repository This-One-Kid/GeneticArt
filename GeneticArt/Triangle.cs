using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static GeneticArt.GeneticArtTrainer;

namespace GeneticArt
{
    
    public struct Triangle
    {
        static int mutates = 0;
        static int copies = 0;
        bool modded = false;

        Color color;
        PointF[] points;
        SolidBrush brush;
        public Triangle(PointF[] points, Color color, SolidBrush myBrush)
        {
            this.points = points;
            this.color = color;
            brush = myBrush;                
        }
        public Triangle(PointF point0, PointF point1, PointF point2, Color color, SolidBrush myBrush)
            : this(new PointF[] { point0, point1, point2 }, color, myBrush) { }
        public Triangle(PointF point0, PointF point1, PointF point2, Color color)
            : this(point0, point1, point2, color, new SolidBrush(color)) { }
        
        public void DrawTriangle(Graphics g, float xCoefficient, float yCoefficient)
        {
            g.FillPolygon(brush, points);
        }
        public void Mutate(Random random)
        {
            if (random.NextDouble() > TriangleArtConstants.mutateColorThreshold)
            {
                //Console.WriteLine($"mutates: {mutates++}");
                if (!modded)
                {
                    //points = (PointF[])points.Clone();
                    //modded = true;
                }
                if (random.NextDouble() > .5f)
                {
                    points[random.Next(3)].X = random.Next(GeneticArtTrainer.width);
                }
                else
                {
                    points[random.Next(3)].Y = random.Next(GeneticArtTrainer.height);
                }
            }
            else
            {
                int rand = random.Next(4);//ARGB
                int a = color.A;
                int r = color.R;
                int g = color.G;
                int b = color.B;
                if (rand == 0)
                {
                    a += random.Next(-TriangleArtConstants.maxModdedAmt, TriangleArtConstants.maxModdedAmt);
                    a = Math.Clamp(a, 0, 255);
                }
                else if (rand == 1)
                {
                    r += random.Next(-TriangleArtConstants.maxModdedAmt, TriangleArtConstants.maxModdedAmt);
                    r = Math.Clamp(r, 0, 255);
                }
                else if (rand == 2)
                {
                    g += random.Next(-TriangleArtConstants.maxModdedAmt, TriangleArtConstants.maxModdedAmt);
                    g = Math.Clamp(g, 0, 255);
                }
                else
                {
                    b += random.Next(-TriangleArtConstants.maxModdedAmt, TriangleArtConstants.maxModdedAmt);
                    b = Math.Clamp(b, 0, 255);
                }
                color = Color.FromArgb(a, r, g, b);
                brush = new SolidBrush(color);
            }
        }
        public Triangle Copy() => new Triangle(points[0], points[1], points[2], color, new SolidBrush(color)); //TODO: look at this next week 

        public static Triangle RandomTriangle(Random rand) => new Triangle(new PointF(rand.Next(width), rand.Next(GeneticArtTrainer.height)), new PointF(rand.Next(GeneticArtTrainer.width), rand.Next(GeneticArtTrainer.height)), new PointF(rand.Next(GeneticArtTrainer.width), rand.Next(GeneticArtTrainer.height)), Color.FromArgb(rand.Next(TriangleArtConstants.minA, TriangleArtConstants.maxA), rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)));
        
    }
}
