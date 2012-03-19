using System;
using System.Web;
using Buncis.Core.Membership;
using Buncis.Framework.Core.Membership;

namespace Buncis.Web.Common.Membership
{
    public class WebMembershipStorage : IMembershipStorage
    {
        #region IMembershipStorage Members

        public UserProfile GetUserProfileFromStorage(string key)
        {
            return HttpContext.Current.Session[key] as UserProfile;
        }

        public void SaveUserProfileToStorage(string key, UserProfile userProfile)
        {
            throw new NotImplementedException();
        }

        public void ClearStorage(string key)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}