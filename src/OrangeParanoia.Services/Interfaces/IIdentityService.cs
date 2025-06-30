namespace OrangeParanoia.Services.Interfaces
{
    public interface IIdentityService
    {
        IdentityData GenerateHumanIdentity(
            bool WithNobleTitle = false,
            bool WithTitle = false,
            bool WithMiddleName = false
            );
    }
}
