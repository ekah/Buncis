using System;
using Buncis.Framework.Core.Membership;
using Buncis.Framework.Core.SupportClasses;
using Security = System.Web.Security;
using System.Web.Security;
using System.Web;

namespace Buncis.Web.Common.Membership
{
	internal class WebMembership : IWebMembership
	{
		//public int? LoggedInUserId
		//{
		//    get
		//    {
		//        int? v = null;
		//        if (LoggedInWebUserProfile != null)
		//            v = LoggedInWebUserProfile.UserId;
		//        return v;
		//    }
		//}

		public IWebUserProfile LoggedInWebUserProfile
		{
			get
			{
				return (IWebUserProfile)HttpContext.Current.Profile;
			}
		}

		//public IUserProfile LoggedInUserProfile
		//{
		//    get
		//    {
		//        throw new Exception("Use LoggedInWebUserProfile");
		//    }
		//}

		public bool UserHasAccessToModule(ApplicationModule module)
		{
			return true;
		}

		public Response DoLogin(string username, string password)
		{
			if (Security.Membership.ValidateUser(username, password))
			{
				FormsAuthentication.SetAuthCookie(username, true);
				FormsAuthentication.RedirectFromLoginPage(username, true);
			}

			return new Response
			{
				IsSuccess = false,
				Message = "Invalid User"
			};
		}

		public Response DoLogout(int userId)
		{
			try
			{
				FormsAuthentication.SignOut();

				return new Response(true, string.Empty);
			}
			catch (Exception ex)
			{
				return new Response(false, ex.Message);
			}
		}
	}
}