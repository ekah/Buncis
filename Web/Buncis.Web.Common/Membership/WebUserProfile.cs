using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Membership;
using System.Web.Profile;
using Security = System.Web.Security;

namespace Buncis.Web.Common.Membership
{
    public class WebUserProfile : ProfileBase, IUserProfile
    {
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

        public int UserId
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

        public string FirstName
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

        public string LastName
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

        public string FullName
        {
            get { throw new NotImplementedException(); }
        }

        public string Email
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

    }
}
