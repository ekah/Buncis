using System;
using System.Linq;
using Buncis.Framework.Core.Membership;
using Security = System.Web.Security;
using System.Web.Security;

namespace Buncis.Web.Common.Membership
{
    internal class AspNetMembership : IWebMembership
    {
        private const string KEY_MEMBERSHIP_STORAGE = "_user_entity_stored";

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

        public IWebUserProfile LoggedInWebUserProfile
        {
            get
            {
                return null;
            }
        }

        public IUserProfile LoggedInUserProfile
        {
            get
            {
                return (IUserProfile)LoggedInWebUserProfile;
            }
        }

        public bool UserHasAccessToModule(ApplicationModule module)
        {
            return true;
        }

        public bool DoLogin(string username, string password)
        {
            if (Security.Membership.ValidateUser(username, password))
            {
                var ticket = new FormsAuthenticationTicket(1,
                    username,
                    DateTime.Now,
                    DateTime.Now.AddDays(20),
                    false,
                    null,
                    FormsAuthentication.FormsCookiePath);

                var encryptedValue = FormsAuthentication.Encrypt(ticket);
                FormsAuthentication.SetAuthCookie(encryptedValue, true);

                return true;
            }

            return false;
        }

        public bool DoLogout(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
