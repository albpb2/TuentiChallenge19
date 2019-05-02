using System.Collections.Generic;

namespace Challenge3.Model.Paper
{
    public class LeftFoldedPaper : Paper
    {
        public LeftFoldedPaper(Paper paper) : base(paper)
        {
        }

        protected override void Unfold()
        {
            var newWidth = Width * 2;
            var newLastColumn = newWidth - 1;
            var reflectedPunches = new List<Coordinate>();

            foreach (var punch in Punches)
            {
                punch.X += Width;
                var reflectedPunch = new Coordinate(newLastColumn - punch.X, punch.Y);
                reflectedPunches.Add(reflectedPunch);
            }

            Width = newWidth;

            Punches.AddRange(reflectedPunches);
        }
    }
}
