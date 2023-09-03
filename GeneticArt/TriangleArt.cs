﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticArt
{
    public class TriangleArt
    {
        public int maxTriangles;
        public Triangle[] triangles;
        public int count = 0;
        public Bitmap originalImage;
        public Bitmap curDrawnImage;
        private Graphics mapGFX;
        bool cloneArrays;

        public TriangleComparer triangleComparer { get; private set; } = new();

        public TriangleArt(int maxTris, Bitmap original, bool cloneArrays)
        {
            maxTriangles = maxTris;
            triangles = new Triangle[maxTriangles];
            originalImage = original;
            this.cloneArrays = cloneArrays;
        }

        public override bool Equals(object other)
        {
            var coolerOther = (TriangleArt)other;

            if (count != coolerOther.count) return false;

            for (int i = 0; i < coolerOther.count; i++)
            {
                if (!triangles[i].Equals(coolerOther.triangles[i])) return false;
            }
            return true;
        }

        public void Mutate(Random rand)
        {
            double randNum = rand.NextDouble();
            if (randNum < TriangleArtConstants.addTriangleThreshold)
            {
                AddTriangle(rand);
            }
            else if (randNum < TriangleArtConstants.removeTriangleThreshold)
            {
                RemoveTriangle(rand);
            }
            else if (count > 0)
            {
                triangles[rand.Next(count)].Mutate(rand);
            }
        }
        public void RemoveTriangle(Random rand)
        {
            if (count == 0) return;

            int indToRem = rand.Next(count);
            for (var i = indToRem;i < count;i ++)
            {
                triangles[i] = triangles[i + 1]; 
            }
            count--;
        }
        public void AddTriangle(Random rand)
        {
            while (count >= maxTriangles)
            {
                for (var i = 0; i < count; i++)
                {
                    triangles[i] = triangles[i + 1];
                }
            }
            triangles[count++] = Triangle.RandomTriangle(rand, cloneArrays);
        }
        public Bitmap DrawImage(int width, int height)
        {
            if (curDrawnImage == null)
            {
                curDrawnImage = new Bitmap(width, height, originalImage.PixelFormat);
                mapGFX = Graphics.FromImage(curDrawnImage);
            }
            else
            {
                mapGFX.Clear(Color.Transparent);
            }
            for (var i = 0; i < count; i++)
            {
                triangles[i].DrawTriangle(mapGFX, width, height);
            }
            return curDrawnImage;
        }
        public double GetError()
        {
            DrawImage(originalImage.Width, originalImage.Height);
            var curImageBits = curDrawnImage.LockBits(new Rectangle(0, 0, curDrawnImage.Width, curDrawnImage.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, curDrawnImage.PixelFormat);
            var originalImageBits = originalImage.LockBits(new Rectangle(0, 0, originalImage.Width, originalImage.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, originalImage.PixelFormat);
            IntPtr curImagePtr = curImageBits.Scan0;
            IntPtr originalPtr = originalImageBits.Scan0;
            int bytes = Math.Abs(curImageBits.Stride) * curDrawnImage.Height;
            byte[] curImageRGBVals = new byte[bytes];
            byte[] originalRGBVals = new byte[bytes];
            System.Runtime.InteropServices.Marshal.Copy(curImagePtr, curImageRGBVals, 0, bytes);
            System.Runtime.InteropServices.Marshal.Copy(originalPtr, originalRGBVals, 0, bytes);

            double error = 0;
            for (var i = 0; i < bytes; i++)
            {
                error += Math.Pow(curImageRGBVals[i] - originalRGBVals[i], 2);
            }
            curDrawnImage.UnlockBits(curImageBits);
            originalImage.UnlockBits(originalImageBits);
            return error;
        }
        public void CopyTo(TriangleArt tri)
        {
            for (var i = 0; i < count; i++)
            {
                tri.triangles[i] = triangles[i].Copy();
            }
        }

        public class TriangleComparer : IEqualityComparer<Triangle>
        {
            public bool Equals(Triangle x, Triangle y)
            {
                return x.Equals(y);
            }

            public int GetHashCode([DisallowNull] Triangle obj)
            {
                throw new NotImplementedException();
            }
        }
    }
}
