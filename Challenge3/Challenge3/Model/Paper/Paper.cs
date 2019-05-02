using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge3.Model.Paper
{
    public class Paper
    {
        public Paper()
        {
        }

        public Paper(Paper paper)
        {
            Width = paper.Width;
            Height = paper.Height;
            Folds = paper.Folds;
            Punches = paper.Punches;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public List<Fold> Folds { get; set; }

        public List<Coordinate> Punches { get; set; }

        public bool IsFolded => Folds.Any();

        public void UnfoldOnce()
        {
            Unfold();

            Folds.RemoveAt(0);
        }

        protected virtual void Unfold()
        {
        }
    }
}
