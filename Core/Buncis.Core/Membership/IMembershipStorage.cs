using Buncis.Framework.Core.Membership;

namespace Buncis.Core.Membership
{
    public interface IMembershipStorage
    {
        IUserProfile GetUserProfileFromStorage(string key);
        void SaveUserProfileToStorage(string key, IUserProfile userProfile);
        void ClearStorage(string key);
    }
}