using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge3.Model.Paper
{
    public class Paper
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public List<Fold> Folds { get; set; }

        public List<Coordinate> Punches { get; set; }

        public bool IsFolded => Folds.Any();

        public void UnfoldOnce()
        {
            if (!IsFolded)
            {
                return;
            }

            var state = _statePerFoldDirection[Folds.First()](this);
            state.Unfold();
            Folds.RemoveAt(0);
        }

        public void UnfoldTotally()
        {
            while (IsFolded)
            {
                UnfoldOnce();
            }
        }

        protected virtual void Unfold()
        {
        }

        private Dictionary<Fold, Func<Paper, Paper>> _statePerFoldDirection = new Dictionary<Fold, Func<Paper, Paper>>
        {
            { Fold.Top, (p) => (TopFoldedPaper)p },
            { Fold.Bottom, (p) => (BottomFoldedPaper)p },
            { Fold.Left, (p) => (LeftFoldedPaper)p },
            { Fold.Right, (p) => (RightFoldedPaper)p }
        };
    }
}
