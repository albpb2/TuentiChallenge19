using Challenge4.Model;
using System.Linq;

namespace Challenge4
{
    public class CandiesCalculator : ICandiesCalculator
    {
        public (long candies, long people) CalculateAverageCandies(PartyList partyLists)
        {
            var groups = partyLists.List.GroupBy(element => element).ToDictionary(g => g.Key, g => g.Count());

            var highestGroup = groups.Keys.Max();

            long listRepetitions = 1;

            for (var i = 0; i < groups.Count; i++)
            {
                listRepetitions = Maths.CalculateLeastCommonMultiple(listRepetitions, groups.Keys.ToList()[i]); 
            }

            long candies = groups.Sum(g => listRepetitions * g.Value);
            long people = groups.Sum(g => (listRepetitions * g.Value) / g.Key);

            return Maths.ReduceFraction(candies, people);
        }

        private static bool IsValidMultipleForGroup(int multiple, int candies, int repetitions)
        {
            return (multiple * repetitions) % candies == 0;
        }
    }
}
