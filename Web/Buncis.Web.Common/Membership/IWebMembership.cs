using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Membership;

namespace Buncis.Web.Common.Membership
{
    public interface IWebMembership : IMembership
    {
        IWebUserProfile LoggedInWebUserProfile { get; }
    }
}
