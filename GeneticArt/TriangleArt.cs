using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticArt
{
    public class TriangleArt
    {
        public int maxTriangles;
        public List<Triangle> triangles;
        public Bitmap originalImage;
        public Bitmap curDrawnImage;
        private Graphics mapGFX;
        public TriangleArt(int maxTris, Bitmap original)
        {
            maxTriangles = maxTris;
            triangles = new List<Triangle>(maxTriangles);
            originalImage = original;
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
            else if (triangles.Count > 0)
            {
                triangles[rand.Next(triangles.Count)].Mutate(rand);
            }
        }
        public void RemoveTriangle(Random rand)
        {
            if (triangles.Count == 0) return;

            triangles.RemoveAt(rand.Next(triangles.Count));
        }
        public void AddTriangle(Random rand)
        {
            while (triangles.Count >= maxTriangles)
            {
                triangles.RemoveAt(0);
            }
            triangles.Add(Triangle.RandomTriangle(rand));
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
            for (var i = 0;i < triangles.Count;i ++)
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
            for (var i = 0;i < bytes;i ++)
            {
                error += Math.Pow(curImageRGBVals[i] - originalRGBVals[i], 2);
            }
            curDrawnImage.UnlockBits(curImageBits);
            originalImage.UnlockBits(originalImageBits);
            return error;
        }
        public void CopyTo(TriangleArt tri)
        {
            tri.triangles.Clear();
            for (var i = 0;i < triangles.Count;i ++)
            {
                tri.triangles.Add(triangles[i].Copy());
            }
        }
    }
}
