using System.Collections.Generic;

namespace Challenge3.Model.Paper
{
    public class BottomFoldedPaper : Paper
    {
        public BottomFoldedPaper(Paper paper) : base(paper)
        {
        }

        protected override void Unfold()
        {
            Height *= 2;

            var lastRow = Height - 1;
            var reflectedPunches = new List<Coordinate>();

            foreach (var punch in Punches)
            {
                var reflectedPunch = new Coordinate(punch.X, lastRow - punch.Y);
                reflectedPunches.Add(reflectedPunch);
            }

            Punches.AddRange(reflectedPunches);
        }
    }
}
