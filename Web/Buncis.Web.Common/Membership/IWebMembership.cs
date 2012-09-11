using System;
using System.Linq;
using Buncis.Framework.Core.Membership;

namespace Buncis.Web.Common.Membership
{
	public interface IWebMembership : IMembership
	{
		IWebUserProfile LoggedInWebUserProfile { get; }
	}
}
