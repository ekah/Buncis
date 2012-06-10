﻿using Buncis.Framework.Core.Infrastructure.IoC;
using Buncis.Framework.Core.Membership;

namespace Buncis.Web.Common.Membership
{
    public static class WebMembership
    {
        private static IMembership _membership;
        public static IMembership Instance
        {
            get
            {
                if (_membership == null)
                    _membership = IoC.Resolve<IMembership>();
                return _membership;
            }
        }
    }
}