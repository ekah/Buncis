﻿using System;
using System.Linq;
using Buncis.Framework.Core.Membership;
using System.Web.Profile;
using Security = System.Web.Security;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Data.Domain.Membership;
using System.Collections.Generic;
using Buncis.Framework.Core.Repository.Membership;
using Buncis.Framework.Core.Infrastructure.Settings;

namespace Buncis.Web.Common.Membership
{
	public class WebUserProfile : ProfileBase, IWebUserProfile
	{
		private readonly IMembershipUserRepository _membershipUserRepository;
		private readonly IMembershipRoleRepository _membershipRoleRepository;
		private readonly ISystemSettings _systemSettings;

		private Security.MembershipUser _systemMembershipUser;
		public Security.MembershipUser SystemMembershipUser
		{
			get
			{
				if (_systemMembershipUser == null)
				{
					_systemMembershipUser = Security.Membership.GetUser();
				}
				return _systemMembershipUser;
			}
		}

		public WebUserProfile()
		{
			_membershipUserRepository = IoC.Resolve<IMembershipUserRepository>();
			_membershipRoleRepository = IoC.Resolve<IMembershipRoleRepository>();
			_systemSettings = IoC.Resolve<ISystemSettings>();
		}

		private MembershipUser _membershipUser;
		private MembershipUser MembershipUser
		{
			get
			{
				// assuming the user is not deleted
				if (_membershipUser == null)
				{
					var membershipUser = IsAnonymous
						? _membershipUserRepository.FindBy(o => o.ProfileUserId == Guid.Empty && o.ClientId == _systemSettings.ClientId)
						: _membershipUserRepository.FindBy(o => o.ProfileUserId == (Guid)SystemMembershipUser.ProviderUserKey);

					if (membershipUser == null)
					{
						throw new Exception("The user is not found in database");
					}
					_membershipUser = membershipUser;
				}
				return _membershipUser;
			}
		}


		public int UserId
		{
			get
			{
				return MembershipUser.UserId;
			}
		}

		public string FirstName
		{
			get
			{
				return MembershipUser.FirstName;
			}
		}

		public string LastName
		{
			get
			{
				return MembershipUser.LastName;
			}
		}

		public string FullName
		{
			get
			{
				return string.Format("{0} {1}", FirstName, LastName).TrimEnd();
			}
		}

		public string Email
		{
			get
			{
				return MembershipUser.Email;
			}
		}

		public bool IsLocked
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsApproved
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public DateTime? LastLoginDate
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public int RandomSeed
		{
			get
			{
				return Convert.ToInt32(base["RandomSeed"]);
			}
			set
			{
				base["RandomSeed"] = value;
			}
		}

		public int ClientId
		{
			get
			{
				return MembershipUser.ClientId;
			}
		}

		public IEnumerable<MembershipRole> Roles
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}
