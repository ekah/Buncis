using Buncis.Framework.Core.Membership;

namespace Buncis.Core.Membership
{
    public interface IMembershipStorage
    {
        UserProfile GetUserProfileFromStorage(string key);
        void SaveUserProfileToStorage(string key, UserProfile userProfile);
        void ClearStorage(string key);
    }
}