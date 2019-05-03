using Challenge4.Model;
using System.Linq;

namespace Challenge4
{
    public class CandiesCalculator : ICandiesCalculator
    {
        public (int candies, int people) CalculateAverageCandies(PartyList partyLists)
        {
            var groups = partyLists.List.GroupBy(element => element).ToDictionary(g => g.Key, g => g.Count());

            var highestGroup = groups.Keys.Max();

            var leastCommonMultiple = Maths.CalculateLeastCommonMultiple(highestGroup, groups[highestGroup]);
            var listRepetitions = leastCommonMultiple;
            
            while (!groups.All(g => IsValidMultipleForGroup(listRepetitions, g.Key, g.Value)))
            {
                listRepetitions = listRepetitions + leastCommonMultiple;
            }

            var candies = groups.Sum(g => listRepetitions * g.Value);
            var people = groups.Sum(g => (listRepetitions * g.Value) / g.Key);

            return Maths.ReduceFraction(candies, people);
        }

        private static bool IsValidMultipleForGroup(int multiple, int candies, int repetitions)
        {
            return (multiple * repetitions) % 2 == 0;
        }
    }
}
