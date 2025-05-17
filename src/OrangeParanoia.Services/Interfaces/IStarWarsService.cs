namespace OrangeParanoia.Services.Interfaces
{
    public interface IStarWarsService
    {
        string JediNameClassic(string firstName, string lastName, string motherName, string birthCity);
        string JediNameRealForm(string firstName, string lastName, string motherName, string birthCity);
        string JediName2332(string firstName, string lastName, string motherName, string birthCity);
        string JediNameFromEnds(string firstName, string lastName, string motherName, string birthCity);
        string JediNameAstrology(string firstName, string lastName, string birthCity, string zodiacSign, string zodiacElement);
        string SithNameClassic(string petName, string streetName);
        string SithNameMethod1(string realName, string emotion, string virtue);
        string SithNameMethod2(string ambition, string realName, string weakness, string parentName);
        string SithNameMethod3(string realName, string emotion);
    }
}
