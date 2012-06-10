using System;
using System.Linq;
using Buncis.Framework.Core.Membership;
using System.Web.Profile;
using Security = System.Web.Security;
using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Data.Domain.Membership;
using System.Collections.Generic;
using Buncis.Framework.Core.Repository.Membership;

namespace Buncis.Web.Common.Membership
{
    public class WebUserProfile : ProfileBase, IUserProfile
    {
        private IMembershipUserRepository _membershipUserRepository;
        private IMembershipRoleRepository _membershipRoleRepository;

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
        }

        private MembershipUser _membershipUser;
        private MembershipUser MembershipUser
        {
            get
            {
                // assuming the user is not deleted
                if (_membershipUser == null)
                {
                    var membershipUser = _membershipUserRepository.FindBy(o => o.ProfileUserId == (Guid)SystemMembershipUser.ProviderUserKey);
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
            set
            {
                throw new Exception("Cannot set this property");
            }
        }

        public string FirstName
        {
            get
            {
                return MembershipUser.FirstName;
            }
            set
            {
                throw new Exception("Cannot set this property");
            }
        }

        public string LastName
        {
            get
            {
                return MembershipUser.LastName;
            }
            set
            {
                throw new Exception("Cannot set this property");
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
            set
            {
                throw new Exception("Cannot set this property");
            }
        }

        public bool IsLocked
        {
            get
            {
                throw new NotImplementedException();
            }
            set
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
            set
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
            set
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
            set
            {
                throw new Exception("Cannot set this property");
            }
        }

        public IList<MembershipRole> Roles
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
