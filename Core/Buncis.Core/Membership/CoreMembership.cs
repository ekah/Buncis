using Buncis.Core.Repositories;
using Buncis.Framework.Core.Membership;

namespace Buncis.Core.Membership
{
    public class CoreMembership : IMembership
    {
        private const string KEY_USERENTITY = "_loggedIn_UserEntity_";
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMembershipStorage _membershipStorage;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreMembership"/> class.
        /// </summary>
        /// <param name="membershipRepository">The membership repository.</param>
        /// <param name="membershipStorage">The membership storage.</param>
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
                if (LoggedInUserProfile != null)
                    v = LoggedInUserProfile.UserId;
                return v;
            }
        }

        /// <summary>
        /// Gets the logged in user entity.
        /// </summary>
        public IUserProfile LoggedInUserProfile
        {
            get { return _membershipStorage.GetUserProfileFromStorage(KEY_USERENTITY); }
        }

        /// <summary>
        /// Users the has access to module.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns></returns>
        public bool UserHasAccessToModule(ApplicationModule module)
        {
            // ToDo: change this.
            return false;
        }

        /// <summary>
        /// Does the login.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool DoLogin(string username, string password)
        {
            // ToDo: Change this
            return false;
        }

        /// <summary>
        /// Does the logout.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        public bool DoLogout(int userId)
        {
            return false;
        }

        #endregion
    }
}