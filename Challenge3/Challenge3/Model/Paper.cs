using System.Collections.Generic;

namespace Challenge3.Model
{
    public class Paper
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public List<Fold> Folds { get; set; }

        public List<Coordinate> Punches { get; set; }
    }
}
