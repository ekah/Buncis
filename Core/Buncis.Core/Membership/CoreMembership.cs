using System;
using Buncis.Core.Repositories;
using Buncis.Framework.Core.Membership;

namespace Buncis.Core.Membership
{
    public class CoreMembership : IMembership
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMembershipStorage _membershipStorage;

        private const string KEY_USERENTITY = "_loggedIn_UserEntity_";

        /// <summary>
        /// Initializes a new instance of the <see cref="BuncisMembership"/> class.
        /// </summary>
        /// <param name="membershipRepository">The membership repository.</param>
        public CoreMembership(IMembershipRepository membershipRepository, IMembershipStorage membershipStorage)
        {
            _membershipStorage = membershipStorage;
            _membershipRepository = membershipRepository;
        }

        #region IMembership Members

        /// <summary>
        /// Gets the logged in user id.
        /// </summary>
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

        /// <summary>
        /// Gets the logged in user entity.
        /// </summary>
        public UserProfile LoggedInUserEntity
        {
            get
            {
                return _membershipStorage.GetUserProfileFromStorage(KEY_USERENTITY);
            }
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
