using Challenge4.Model;

namespace Challenge4
{
    public interface ICandiesCalculator
    {
        (long candies, long people) CalculateAverageCandies(PartyList partyLists);
    }
}
