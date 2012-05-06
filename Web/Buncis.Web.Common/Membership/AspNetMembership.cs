using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Membership;
using Buncis.Core.Membership;

namespace Buncis.Web.Common.Membership
{
    public class AspNetMembership : IMembership
    {
        private const string KEY_MEMBERSHIP_STORAGE = "_user_entity_stored";
        private readonly IMembershipStorage _membershipStorage;

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
            get
            {
                return _membershipStorage.GetUserProfileFromStorage(KEY_MEMBERSHIP_STORAGE);
            }
        }

        public AspNetMembership(IMembershipStorage membershipStorage)
        {
            _membershipStorage = membershipStorage;
        }

        public bool UserHasAccessToModule(BuncisModule module)
        {
            return true;
        }

        public bool DoLogin(string username, string password)
        {
            return true;
        }

        public bool DoLogout(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
