using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Framework.Core.Membership
{
    public interface IMembership
    {
        int? LoggedInUserId { get; }
        UserProfile? LoggedInUserEntity { get; }

        bool UserHasAccessToModule(BuncisModule module);
        bool Login(string username, string password);
    }
}
