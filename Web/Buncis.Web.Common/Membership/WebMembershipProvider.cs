using Buncis.Framework.Core.Infrastructure.IoC;

namespace Buncis.Web.Common.Membership
{
	public static class WebMembershipProvider
	{
		private static IWebMembership _membership;
		public static IWebMembership Instance
		{
			get { return _membership ?? (_membership = IoC.Resolve<IWebMembership>()); }
		}
	}
}