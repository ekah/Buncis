using System;
using System.Web;
using Buncis.Core.Membership;
using Buncis.Framework.Core.Membership;

namespace Buncis.Web.Common.Membership
{
    public class WebMembershipStorage : IMembershipStorage
    {
        #region IMembershipStorage Members

        /// <summary>
        /// Gets the user profile from storage.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public IUserProfile GetUserProfileFromStorage(string key)
        {
            return HttpContext.Current.Session[key] as IUserProfile;
        }

        /// <summary>
        /// Saves the user profile to storage.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="userProfile">The user profile.</param>
        public void SaveUserProfileToStorage(string key, IUserProfile userProfile)
        {
            HttpContext.Current.Session[key] = userProfile;
        }

        /// <summary>
        /// Clears the storage.
        /// </summary>
        /// <param name="key">The key.</param>
        public void ClearStorage(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        #endregion
    }
}