using System.Collections.Generic;

namespace Challenge3.Model.Paper
{
    public class RightFoldedPaper : Paper
    {
        public RightFoldedPaper(Paper paper) : base(paper)
        {
        }

        protected override void Unfold()
        {
            Width *= 2;

            var lastColumn = Width - 1;
            var reflectedPunches = new List<Coordinate>();

            foreach (var punch in Punches)
            {
                var reflectedPunch = new Coordinate(lastColumn - punch.X, punch.Y);
                reflectedPunches.Add(reflectedPunch);
            }

            Punches.AddRange(reflectedPunches);
        }
    }
}
