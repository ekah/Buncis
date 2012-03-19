namespace Buncis.Framework.Core.Membership
{
    public interface IMembership
    {
        int? LoggedInUserId { get; }
        UserProfile LoggedInUserEntity { get; }

        bool UserHasAccessToModule(BuncisModule module);
        bool DoLogin(string username, string password);
        bool DoLogout(int userId);
    }
}