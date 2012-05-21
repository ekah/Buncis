namespace Buncis.Framework.Core.Membership
{
    public interface IMembership
    {
        int? LoggedInUserId { get; }
        IUserProfile LoggedInUserProfile { get; }

        bool UserHasAccessToModule(ApplicationModule module);
        bool DoLogin(string username, string password);
        bool DoLogout(int userId);
    }
}