using System.Collections.Generic;

namespace Challenge3.Model.Paper
{
    public class TopFoldedPaper : Paper
    {
        public TopFoldedPaper(Paper paper) : base(paper)
        {
        }

        protected override void Unfold()
        {
            var newHeight = Height * 2;
            var newLastRow = newHeight - 1;
            var reflectedPunches = new List<Coordinate>();

            foreach (var punch in Punches)
            {
                punch.Y += Height;
                var reflectedPunch = new Coordinate(punch.X, newLastRow - punch.Y);
                reflectedPunches.Add(reflectedPunch);
            }

            Height = newHeight;

            Punches.AddRange(reflectedPunches);
        }
    }
}
