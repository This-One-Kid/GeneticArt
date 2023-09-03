using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using static GeneticArt.GeneticArtTrainer;

namespace GeneticArt
{


    public struct Triangle
    {
        static int GlobalID = 0;
        static object monke;

        static int mutates = 0;
        static int copies = 0;
        bool modded = false;
        bool cloneArray;
        Queue<string> operationLog;
        Color color;
        public PointF[] points; //a fixed array would be nice here, but sadly this is not a primitive type
        SolidBrush brush;
        int ID;
        public Triangle(PointF[] points, Color color, SolidBrush myBrush, bool cloneArray, Queue<string>? operationLog = null)
        {
            this.operationLog = operationLog ?? new();
            this.points = points;
            this.color = color;
            brush = myBrush;
            this.cloneArray = cloneArray;
            this.ID = GlobalID++;
        }

        public override readonly bool Equals(object? obj)
        {
            var other = (Triangle)obj;
            bool good = color == other.color;
            good &= brush.Color == other.brush.Color;
            good &= points.SequenceEqual(other.points);

            if (!good)
            {
                ;
            }
            return good;
        }

        public Triangle(PointF point0, PointF point1, PointF point2, Color color, SolidBrush myBrush, bool cloneArray)
            : this(new PointF[] { point0, point1, point2 }, color, myBrush, cloneArray) { }
        public Triangle(PointF point0, PointF point1, PointF point2, Color color, bool cloneArray)
            : this(point0, point1, point2, color, new SolidBrush(color), cloneArray) { }

        public void DrawTriangle(Graphics g, float xCoefficient, float yCoefficient)
        {
            g.FillPolygon(brush, points);
        }
        public void Mutate(Random random)
        {
            double randResult;
            if ((randResult = random.NextDouble()) > TriangleArtConstants.mutateColorThreshold)
            {
                //Console.WriteLine($"mutates: {mutates++}");
                if (!modded)
                {
                    points = BudgetClone(points);
                    modded = true;
                }

                int chosenIndex = random.Next(3);

                string changedVal = chosenIndex.ToString();

                if (randResult == 0.5316922876665798)
                    ;


                if (random.NextDouble() > .5f)
                {


                    changedVal += $": {points[chosenIndex]}.X => ";
                    points[chosenIndex].X = random.Next(GeneticArtTrainer.width);
                    changedVal += points[chosenIndex].X;
                }
                else
                {

                    if (randResult == 0.5316922876665798)
                    {
                        GeneticArtTrainer.Current.monke = this;
                    }
                    changedVal += $": {points[chosenIndex]}.Y => ";
                    points[chosenIndex].Y = random.Next(GeneticArtTrainer.height);
                    changedVal += points[chosenIndex].Y;
                }
                operationLog.Enqueue($"{randResult} < {TriangleArtConstants.mutateColorThreshold} : {changedVal}");
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
                operationLog.Enqueue($"{randResult} > {TriangleArtConstants.mutateColorThreshold} : Color, {color} => {color = Color.FromArgb(a, r, g, b)}");
                //color = Color.FromArgb(a, r, g, b);
                brush = new SolidBrush(color);
            }
        }
        private PointF[] BudgetClone(PointF[] points)
        {
            return new PointF[] { new PointF(points[0].X, points[0].Y), new PointF(points[1].X, points[1].Y), new PointF(points[2].X, points[2].Y) };
        }//new PointF[] { points[0], points[1], points[2] }
        public Triangle Copy() => new Triangle(points, color, brush, cloneArray, new (operationLog)); //TODO: look at this next week 

        public static Triangle RandomTriangle(Random rand, bool cloneArray) => new Triangle(new PointF(rand.Next(width), rand.Next(GeneticArtTrainer.height)), new PointF(rand.Next(GeneticArtTrainer.width), rand.Next(GeneticArtTrainer.height)), new PointF(rand.Next(GeneticArtTrainer.width), rand.Next(GeneticArtTrainer.height)), Color.FromArgb(rand.Next(TriangleArtConstants.minA, TriangleArtConstants.maxA), rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)), cloneArray);
        
    }
    
}
