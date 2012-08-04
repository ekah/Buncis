using System;
using System.Collections.Generic;
using Buncis.Data.Domain.Membership;

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
		IEnumerable<MembershipRole> Roles { get; }
		string UserName { get; }
		bool IsAnonymous { get; }
	}
}