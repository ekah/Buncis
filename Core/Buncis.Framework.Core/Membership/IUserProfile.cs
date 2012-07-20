using System;
using Buncis.Data.Domain.Membership;
using System.Collections.Generic;

namespace Buncis.Framework.Core.Membership
{
	public interface IUserProfile
	{
		int UserId { get; }
		string FirstName { get; }
		string LastName { get; }
		string FullName { get; }
		string Email { get; }
		bool IsLocked { get; }
		bool IsApproved { get; }
		DateTime? LastLoginDate { get; }
		int ClientId { get; }
		IList<MembershipRole> Roles { get; }
		string UserName { get; }
		bool IsAnonymous { get; }
	}
}