using Challenge4.Model;

namespace Challenge4
{
    public interface ICandiesCalculator
    {
        (int candies, int people) CalculateAverageCandies(PartyList partyLists);
    }
}
