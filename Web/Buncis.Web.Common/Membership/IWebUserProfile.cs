using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Membership;
using Security = System.Web.Security;

namespace Buncis.Web.Common.Membership
{
    public interface IWebUserProfile : IUserProfile
    {
        Security.MembershipUser SystemMembershipUser { get; set; }
    }
}
