using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticArt
{
    public class TriangleArtConstants
    {
        public static float mutateColorThreshold = .5f;//> .5f mutate color, less than this mutate point
        public static int maxModdedAmt = 50;
        public static int minA = 100;
        public static int maxA = 200;
        public static float addTriangleThreshold = .33f;
        public static float removeTriangleThreshold = .67f;

    }
}
