using System;
using System.Linq;
using Buncis.Framework.Core.Membership;
using Security = System.Web.Security;

namespace Buncis.Web.Common.Membership
{
	public interface IWebUserProfile : IUserProfile
	{
		Security.MembershipUser SystemMembershipUser { get; }
	}
}
