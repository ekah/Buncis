using Buncis.Core.Repositories;
using Buncis.Framework.Core.Membership;

namespace Buncis.Core.Membership
{
    public class CoreMembership : IMembership
    {
        private const string KEY_USERENTITY = "_loggedIn_UserEntity_";
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMembershipStorage _membershipStorage;

        public CoreMembership(IMembershipRepository membershipRepository, IMembershipStorage membershipStorage)
        {
            _membershipStorage = membershipStorage;
            _membershipRepository = membershipRepository;
        }

        #region IMembership Members

        public int? LoggedInUserId
        {
            get
            {
                int? v = null;
                if (LoggedInUserEntity != null)
                    v = LoggedInUserEntity.UserId;
                return v;
            }
        }

        public UserProfile LoggedInUserEntity
        {
            get { return _membershipStorage.GetUserProfileFromStorage(KEY_USERENTITY); }
        }

        public bool UserHasAccessToModule(BuncisModule module)
        {
            // ToDo: change this.
            return false;
        }

        public bool DoLogin(string username, string password)
        {
            // ToDo: Change this
            return false;
        }

        public bool DoLogout(int userId)
        {
            return false;
        }

        #endregion
    }
}